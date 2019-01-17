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
                string[] cmdline = { };
                string serviceFileName = txtPath.Text.Trim();
                string serviceName = GetServiceName(serviceFileName);
                if (string.IsNullOrEmpty(serviceName))
                {
                    txtTip.Text = "指定文件不是Windows服务！";
                    return;
                }
                if (ServiceIsExisted(serviceName))
                {
                    txtTip.Text = "要安装的服务已经存在！";
                    return;
                }

                TransactedInstaller transactedInstaller = new TransactedInstaller();
                AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);
                transactedInstaller.Installers.Add(assemblyInstaller);
                transactedInstaller.Install(new System.Collections.Hashtable());
                txtTip.Text = "服务安装成功！";
            }
            catch (Exception ex)
            {
                txtTip.Text = ex.Message.ToString();
            }


        }

        /// <summary>
        /// 获取Windows服务的名称
        /// </summary>
        /// <param name="serviceFileName">文件路径</param>
        /// <returns>服务名称</returns>
        private string GetServiceName(string serviceFileName)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(serviceFileName);
                Type[] types = assembly.GetTypes();
                foreach (Type myType in types)
                {
                    if (myType.IsClass && myType.BaseType == typeof(System.Configuration.Install.Installer))
                    {
                        FieldInfo[] fieldInfos = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Default | BindingFlags.Instance | BindingFlags.Static);
                        foreach (FieldInfo myFieldInfo in fieldInfos)
                        {
                            if (myFieldInfo.FieldType == typeof(System.ServiceProcess.ServiceInstaller))
                            {
                                ServiceInstaller serviceInstaller = (ServiceInstaller)myFieldInfo.GetValue(Activator.CreateInstance(myType));
                                return serviceInstaller.ServiceName;
                            }
                        }
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ServiceIsExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cmdline = { };
                string serviceFileName = txtPath.Text.Trim();
                string serviceName = GetServiceName(serviceFileName);
                if (string.IsNullOrEmpty(serviceName))
                {
                    txtTip.Text = "指定文件不是Windows服务！";
                    return;
                }
                if (!ServiceIsExisted(serviceName))
                {
                    txtTip.Text = "要卸载的服务不存在！";
                    return;
                }
                TransactedInstaller transactedInstaller = new TransactedInstaller();
                AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);
                transactedInstaller.Installers.Add(assemblyInstaller);
                transactedInstaller.Uninstall(null);
                txtTip.Text = "服务卸载成功！";

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
                string serviceName = GetServiceName(txtPath.Text.Trim());
                if (string.IsNullOrEmpty(serviceName))
                {
                    txtTip.Text = "指定文件不是Windows服务！";
                    return;
                }
                if (!ServiceIsExisted(serviceName))
                {
                    txtTip.Text = "要运行的服务不存在！";
                    return;
                }
                ServiceController service = new ServiceController(serviceName);
                if (service.Status != ServiceControllerStatus.Running && service.Status != ServiceControllerStatus.StartPending)
                {
                    service.Start();
                    txtTip.Text = "服务运行成功！";
                }
                else
                {
                    txtTip.Text = "服务正在运行！";
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
                string[] cmdline = { };
                string serviceFileName = txtPath.Text.Trim();
                string serviceName = GetServiceName(serviceFileName);
                if (string.IsNullOrEmpty(serviceName))
                {
                    txtTip.Text = "指定文件不是Windows服务！";
                    return;
                }
                if (!ServiceIsExisted(serviceName))
                {
                    txtTip.Text = "要停止的服务不存在！";
                    return;
                }
                ServiceController service = new ServiceController(serviceName);
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    txtTip.Text = "服务停止成功！";
                }
                else
                {
                    txtTip.Text = "服务已经停止！";
                }

            }
            catch (Exception ex)
            {
                txtTip.Text = ex.Message;
            }
        }
    }
}
