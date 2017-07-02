/*
*  MIT License
*  Copyright (c) 2017 Igor Babic
*/
using System.Configuration.Install;
using System.ServiceProcess;
using System.ComponentModel;

namespace WinStartStop
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public ProjectInstaller()
        {
            // Instantiate installer for process and service.
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // The service runs under the service account.
            processInstaller.Account = ServiceAccount.LocalSystem;

            // The service is started manually.
            serviceInstaller.StartType = ServiceStartMode.Manual;

            // ServiceName must equal those on ServiceBase derived classes.
            serviceInstaller.ServiceName = "Windows Startup Shutdown Service";

            // Add installer to collection. Order is not important if more than one service.
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
