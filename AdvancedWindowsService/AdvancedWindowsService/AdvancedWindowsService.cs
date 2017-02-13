using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace AdvancedWindowsService
{
    public partial class AdvancedWindowsService : ServiceBase
    {
        ServiceLogger serviceLogger;
        public AdvancedWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceLogger = new ServiceLogger();
            Thread loggerThread = new Thread(new ThreadStart(serviceLogger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            serviceLogger.Stop();
            Thread.Sleep(1000);
        }
    }
}
