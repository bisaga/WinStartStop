/*
*  MIT License
*  Copyright (c) 2017 Igor Babic
*/

using System;
using System.ServiceProcess;

namespace WinStartStop
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(String[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new StartStopService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
