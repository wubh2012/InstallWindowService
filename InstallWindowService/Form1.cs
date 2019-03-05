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
    public partial class Form1 : Form
    {
        string ServiceName = string.Empty;
        public Form1()
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
                txtTip.Text = string.Format("{0} {1} 服务安装成功!", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ServiceName);
            }
            catch (Exception ex)
            {
                txtTip.Text = ex.Message.ToString();
            }

        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceFilePath = txtPath.Text.Trim();
                ServiceHelper.UnInstallByServicePath(serviceFilePath);
                txtTip.Text = "服务卸载成功！";
                ServiceName = null;

            }
            catch (Exception ex)
            {
                txtTip.Text = ex.Message;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ServiceName))
                {
                    ServiceHelper.Start(ServiceName);
                    txtTip.Text = "服务启动成功！";
                }
                else
                {
                    txtTip.Text = "请先安装服务！";
                }
            }
            catch (Exception ex)
            {
                txtTip.Text = ex.Message;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ServiceName))
                {
                    ServiceHelper.Stop(ServiceName);
                    txtTip.Text = "服务停止成功！";
                }
                else
                {
                    txtTip.Text = "请先安装服务！";
                }
            }
            catch (Exception ex)
            {
                txtTip.Text = ex.Message;
            }
        }
    }
}
