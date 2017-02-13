using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace AdvancedWindowsService
{
    class ConsoleLogger
    {
        FileSystemWatcher watcher;
        public DateTime LastCreatingDateTime { get; set; } = DateTime.Now;
        public string WatchingDirectory { get; } = "E:\\TestFolder";
        public string FilesDestinationDirectory { get; } = " E:\\TestFolder_2";
        public string ArchiveName { get; set; }
        public string FileEvent { get; set; }
        private bool isEnabled = true;
        private bool isChanging = true;


        public ConsoleLogger()
        {
            watcher = new FileSystemWatcher(WatchingDirectory);
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
        }


        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            FileEvent = "New file:   " + e.Name;
            Console.WriteLine(FileEvent);
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
                    Console.WriteLine("Archiving files...");
                    try
                    {
                        ZipFile.CreateFromDirectory(WatchingDirectory, ArchiveName);
                        Console.WriteLine("Archive created successfully!");
                        Console.WriteLine("Archive Name:  " + ArchiveName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Archiving failed");
                        Console.WriteLine(ex.Message);
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
                    stream= new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
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
