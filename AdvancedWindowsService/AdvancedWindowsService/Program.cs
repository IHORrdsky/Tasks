using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Reflection;

namespace AdvancedWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            if (args.Length == 0 && args.Length > 1)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new AdvancedWindowsService()
                };
                ServiceBase.Run(ServicesToRun);
            }
                //ServiceBase.Run(new AdvancedWindowsService());

            if (args.Length == 1 && (args[0].ToLower() == "/console" || args[0].ToLower() == "\\console" || args[0].ToLower() == "-console"))
            {
                Console.WriteLine("Starting service as a console application!");
                ConsoleLogger consoleLogger = new ConsoleLogger();
                Thread consoleThread = new Thread(consoleLogger.Start);
                consoleThread.Start();
            }

            if (args.Length == 1 && (args[0].ToLower() == "/gui" || args[0].ToLower() == "\\gui" || args[0].ToLower() == "gui"))
            {
                Console.WriteLine("Starting service with graphic interface!");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ServiceForm form = new ServiceForm();
                GUILogger guiLogger = new GUILogger();
                ServiceFormPresenter presenter = new ServiceFormPresenter(form, guiLogger);
                Application.Run(form);
            }
        }
    }
}
