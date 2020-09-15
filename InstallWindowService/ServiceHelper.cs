using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstallWindowService
{
    public class ServiceHelper
    {
        static string[] cmdline = { };

        public static string Install(string servicePath)
        {
            try
            {
                string serviceName = GetServiceNameByPath(servicePath);
                if (ExistsService(serviceName) == false)
                {
                    TransactedInstaller transactedInstaller = new TransactedInstaller();
                    AssemblyInstaller assemblyInstaller = new AssemblyInstaller(servicePath, cmdline);
                    transactedInstaller.Installers.Add(assemblyInstaller);
                    transactedInstaller.Install(new System.Collections.Hashtable());

                    while (ExistsService(serviceName) == false)
                    {
                        break;
                    }
                    return serviceName;
                }
                else
                {
                    throw new Exception(serviceName + " 服务已经存在");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static string InstallByCmd(string servicePath)
        {
            string cmdHead = "%SystemRoot%/Microsoft.NET/Framework/v4.0.30319/InstallUtil.exe ";
            return ExecuteCMD(cmdHead + servicePath);
        }
        public static void Delete(string servicePath)
        {
            var serviceName = GetServiceNameByPath(servicePath);
            ExecuteCMD($"sc delete {serviceName}");
        }

        public static string ExecuteCMD(string command, bool is_exec_then_exit = true)
        {
            try
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.UseShellExecute = false; // 是否使用操作系统shell启动
                myProcess.StartInfo.CreateNoWindow = true; // 不显示程序窗口
                myProcess.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
                myProcess.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
                myProcess.StartInfo.RedirectStandardError = true; //重定向标准错误输出
                myProcess.Start();

                StreamWriter sIn = myProcess.StandardInput;
                sIn.AutoFlush = true;
                StreamReader sOut = myProcess.StandardOutput;
                StreamReader sErr = myProcess.StandardError;
                sIn.Write(command + Environment.NewLine);
                if (is_exec_then_exit)
                {
                    sIn.Write("exit" + Environment.NewLine);
                }
                string result = sOut.ReadToEnd();
                string er = sErr.ReadToEnd();
                //myProcess.WaitForExit();

                if (!myProcess.HasExited)
                {
                    myProcess.Kill();
                }
                sIn.Close();
                sOut.Close();
                sErr.Close();
                myProcess.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("安装服务出错," + ex.Message);
            }
        }

        public static void UnInstallByServicePath(string servicePath)
        {
            try
            {
                string serviceName = GetServiceNameByPath(servicePath);
                if (ExistsService(serviceName))
                {
                    TransactedInstaller transactedInstaller = new TransactedInstaller();
                    AssemblyInstaller assemblyInstaller = new AssemblyInstaller(servicePath, cmdline);
                    transactedInstaller.Installers.Add(assemblyInstaller);
                    transactedInstaller.Uninstall(null);


                    while (ExistsService(serviceName) == true)
                    {
                        break;
                    }
                }
                else
                {
                    throw new Exception("卸载的服务不存在");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Start(string serviceName)
        {

            ServiceController service = new ServiceController(serviceName);
            if (service.Status != ServiceControllerStatus.Running && service.Status != ServiceControllerStatus.StartPending)
            {
                service.Start();
            }
        }
        public static void Stop(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            if (service.CanStop && service.Status == ServiceControllerStatus.Running)
            {
                service.Stop();
            }
        }

        public static string GetServiceNameByPath(string servicePath)
        {
            var serviceName = string.Empty;
            try
            {
                Assembly assembly = Assembly.LoadFrom(servicePath);
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
                                serviceName = serviceInstaller.ServiceName;
                            }
                        }
                    }
                }
                if (string.IsNullOrEmpty(serviceName))
                {
                    throw new Exception("指定的文件路径不是服务程序");
                }
                else
                {
                    return serviceName;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ExistsService(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            return services.Any(s => s.ServiceName == serviceName);
        }
    }
}
