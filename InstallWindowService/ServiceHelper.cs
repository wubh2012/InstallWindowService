using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
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
