using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;

namespace AdvancedWindowsService
{

    class ServiceFormPresenter
    {

        private IServiceForm view;
        private IGUILogger guiLogger;

        public ServiceFormPresenter(IServiceForm _view, IGUILogger _guiLogger)
        {
            view = _view;
            guiLogger = _guiLogger;
            view.WatchingDirectory = guiLogger.WatchingDirectory;
            view.ArchiveFileDirectory = guiLogger.FilesDestinationDirectory;
            view.StartServiceClick += View_StartServiceClick;
            view.StopServiceClick += View_StopServiceClick;
            guiLogger.DirectoryChanged += Logger_DirectoryChanged;
            guiLogger.FilesArchiving += Logger_FilesArchiving;
            Thread loggerThread = new Thread(guiLogger.Start);
            loggerThread.Start();
        }

        private void Logger_FilesArchiving(object sender, EventArgs e)
        {
            
            view.WorkingPanelContent ="Archiving files...";
            if (guiLogger.ArchivingErrorMessage == null)
            {
                view.WorkingPanelContent =
                    "Archive created successfully!" + "   \n" +
                    "Archive name: " + guiLogger.ArchiveName;
            }
            else
                view.WorkingPanelContent = 
                    "Archiving failed" + "\n" +
                    "Error message: " + guiLogger.ArchivingErrorMessage;


        }

        private void Logger_DirectoryChanged(object sender, EventArgs e)
        {
            view.WorkingPanelContent = view.WorkingPanelContent + "\n"+ "\n" + "\n" + guiLogger.FileEvent;
        }

        private void View_StopServiceClick(object sender, EventArgs e)
        {
            guiLogger.Stop();
        }

        private void View_StartServiceClick(object sender, EventArgs e)
        {
            guiLogger.IsEnabled = true;
            Thread loggerThread = new Thread(guiLogger.Start);
            loggerThread.Start();
        }
    }
}
