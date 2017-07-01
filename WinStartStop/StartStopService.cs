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

        public StartStopService(){}

        protected override void OnStart(string[] args)
        {
            folderName = args.Length > 0 ? args[0] : folderName;
            if (File.Exists(Path.Combine(folderName, startupName)))
            {
                RunScript(startupName);
            }

        }

        protected override void OnStop()
        {
            if (File.Exists(Path.Combine(folderName, shutdownName)))
            {
                RunScript(shutdownName);
            }
        }

        private void RunScript(string processFileName)
        {
            string scriptFileName = System.IO.Path.Combine(folderName, processFileName);

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C " + scriptFileName,
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
