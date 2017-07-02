/*
*  MIT License
*  Copyright (c) 2017 Igor Babic
*/
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace WinStartStop
{
    class StartStopService : ServiceBase
    {
        private String folderName = "C:\\WinStartStop";
        private String startupName = "startup.bat";
        private String shutdownName = "shutdown.bat";
        private EventLog eventLog;
        private String scriptFile;

        public StartStopService(){
            eventLog = new EventLog();
            if (!EventLog.SourceExists("WidowsStartStop"))
            {
                EventLog.CreateEventSource("WidowsStartStop", "Application");
            }
            eventLog.Source = "WidowsStartStop";
            eventLog.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Windows Startup On");
            folderName = args.Length > 0 ? args[0] : folderName;
            scriptFile = Path.Combine(folderName, startupName);
            if (File.Exists(scriptFile))
            {
                RunScript(scriptFile);
                eventLog.WriteEntry(String.Format("Windows Startup run {0} script.", scriptFile));
            }

        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Windows Shutdown On.");
            scriptFile = Path.Combine(folderName, shutdownName);
            if (File.Exists(scriptFile))
            {
                RunScript(scriptFile);
                eventLog.WriteEntry(String.Format("Windows Shutdown run {0} script.", scriptFile));
            }
        }

        private void RunScript(String scriptFilePath)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = String.Format("/C {0}", scriptFilePath),
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var process = new Process();
            process.StartInfo = startInfo;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message);
                eventLog.WriteEntry(ex.InnerException.Message);
            }
        }
    }
}
