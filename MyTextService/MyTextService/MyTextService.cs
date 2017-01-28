using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace MyTextService
{
    public partial class MyTextService : ServiceBase
    {
        public MyTextService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            Debug.WriteLine("My first service works well");
        }

        protected override void OnStop()
        {
        }
    }
}
