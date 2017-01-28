using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace MyTextService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        
        static void Main()
        {
#if DEBUG
            MyTextService first = new MyTextService();
            first.OnDebug();
            //В методе OnDebug происходит вызов метода OnStart(null)
            //Метод OnStart имеет следующую реализацию:
            //Debug.WriteLine("My first service works well");
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MyTextService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
