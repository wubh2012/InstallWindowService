using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace InstallWindowService
{
    public partial class frmMain : Form
    {
        string ServiceName = string.Empty;
        public frmMain()
        {
            InitializeComponent();
        }

        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".exe")  //判断文件类型，只接受txt文件
                {
                    txtPath.Text += file + "\r\n";
                }
            }
        }

        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            txtPath.Text = "";
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceFilePath = txtPath.Text.Trim();
                ServiceName = ServiceHelper.Install(serviceFilePath);
                printLog($"{ServiceName} 服务安装成功");
            }
            catch (Exception ex)
            {
                printLog(ex.Message);
            }

        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceFilePath = txtPath.Text.Trim();
                ServiceHelper.UnInstallByServicePath(serviceFilePath);
                printLog("服务卸载成功");
                ServiceName = null;

            }
            catch (Exception ex)
            {
                printLog(ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ServiceName))
                {
                    ServiceHelper.Start(ServiceName);
                    printLog("服务启动成功！");
                }
                else
                {
                    printLog("请先安装服务！");
                }
            }
            catch (Exception ex)
            {
                printLog(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ServiceName))
                {
                    ServiceHelper.Stop(ServiceName);
                    printLog("服务停止成功！");
                }
                else
                {
                    printLog("请先安装服务！");
                }
            }
            catch (Exception ex)
            {
                printLog(ex.Message);
            }
        }

        private void btnInstallByCmd_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceFilePath = txtPath.Text.Trim();
                string result = ServiceHelper.InstallByCmd(serviceFilePath);
                printLog(result);
            }
            catch (Exception ex)
            {
                printLog(ex.Message);
            }
        }

        private void btnGetServiceName_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceFilePath = txtPath.Text.Trim();
                var serviceName = ServiceHelper.GetServiceNameByPath(serviceFilePath);
                var msg = $"获取的服务名是 {serviceName}";
                printLog(msg);
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                printLog(ex.Message);
            }

        }

        private void printLog(string msg)
        {
            txtTip.Text = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {msg}";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ServiceHelper.Delete(txtPath.Text.Trim());
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            var result = ServiceHelper.ExecuteCMD(txtCommand.Text.Trim());
            printLog(result);
        }
    }
}
