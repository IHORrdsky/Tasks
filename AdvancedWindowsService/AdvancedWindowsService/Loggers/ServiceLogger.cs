using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace AdvancedWindowsService
{

    class ServiceLogger
    {
        FileSystemWatcher watcher;
        public DateTime LastCreatingDateTime { get; set; } = DateTime.Now;
        public string WatchingDirectory { get; } = "E:\\TestFolder";
        public string FilesDestinationDirectory { get; } = " E:\\TestFolder_2";
        public string ArchiveName { get; set; }
        public string FileEvent { get; set; }
        private bool isEnabled = true;
        private bool isChanging = true;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }
        

        public ServiceLogger()
        {
            watcher = new FileSystemWatcher(WatchingDirectory);
            watcher.Created += Watcher_Created;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }


        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            FileEvent = "New file:   " + e.Name;
            if (!IsFileLocked(e.FullPath))
            {
                LastCreatingDateTime = DateTime.Now;
                ArchiveName = FilesDestinationDirectory + "\\" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.Hour.ToString() + "h " + DateTime.Now.Minute.ToString() + "m " + DateTime.Now.Second.ToString() + "s " + ".zip";
                isChanging = false;
            }
        }

        public void Start()
        {
            while (isEnabled)
            {
                Thread.Sleep(1000);
                if (DateTime.Now.Subtract(LastCreatingDateTime).TotalSeconds > 5 && !isChanging)
                {         
                    try
                    {
                        ZipFile.CreateFromDirectory(WatchingDirectory, ArchiveName);
                    }
                    catch (Exception)
                    {

                    }
                    isChanging = true;
                }
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            isEnabled = false;
        }



        //
        //Checking file copied
        // 

        private bool IsFileLocked(string filePath)
        {
            FileStream stream = null;
            bool isFileEnabled = false;
            bool space = false;
            while (!isFileEnabled)
            {
                try
                {
                    stream = File.Open(filePath, FileMode.Open);
                }
                catch (IOException)
                {

                }
                catch(UnauthorizedAccessException)
                {
                    space = true;
                }
                finally
                {
                    if (stream != null || space)
                    {
                        isFileEnabled = true;
                        stream?.Dispose();
                    }
                }
            }
            return false;
        }
    }
}
