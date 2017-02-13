using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace AdvancedWindowsService
{
    
        public interface IGUILogger
        {
            void Start();
            void Stop();
            string WatchingDirectory { get; }
            string FilesDestinationDirectory { get; }
            string ArchiveName { get; set; }
            string FileEvent { get; set; }
            string ArchivingErrorMessage { get; set; }
            event EventHandler DirectoryChanged;
            event EventHandler FilesArchiving;
            bool IsEnabled { get; set; }
        }

        class GUILogger : IGUILogger
        {
            FileSystemWatcher watcher;
            public event EventHandler DirectoryChanged;
            public event EventHandler FilesArchiving;
            public DateTime LastWriteTime { get; set; } = DateTime.Now;
            public string WatchingDirectory { get; } = "E:\\TestFolder";
            public string FilesDestinationDirectory { get; } = " E:\\TestFolder_2";
            public string ArchiveName { get; set; }
            public string FileEvent { get; set; }
            public string ArchivingErrorMessage { get; set; } = null;
            private bool isEnabled = true;
            private bool isChanging = true;

            public bool IsEnabled
            {
                get { return isEnabled; }
                set { isEnabled = value; }
            }


            public GUILogger()
            {
                watcher = new FileSystemWatcher(WatchingDirectory);
                watcher.Created += Watcher_Created;
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
            }


            private void Watcher_Created(object sender, FileSystemEventArgs e)
            {
                watcher.EnableRaisingEvents = true;
                FileEvent = "New file:   " + e.Name;
                if (!IsFileLocked(e.FullPath))
                {
                    LastWriteTime = DateTime.Now;
                    ArchiveName = FilesDestinationDirectory + "\\" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.Hour.ToString() + "h " + DateTime.Now.Minute.ToString() + "m " + DateTime.Now.Second.ToString() + "s " + ".zip";
                    isChanging = false;
                    DirectoryChanged?.Invoke(this, EventArgs.Empty);
                }
            }

            public void Start()
            {
                watcher.EnableRaisingEvents = true;
                while (isEnabled)
                {
                    Thread.Sleep(1000);
                    ArchivingErrorMessage = null;
                    if (DateTime.Now.Subtract(LastWriteTime).TotalSeconds > 5 && !isChanging)
                    {
                        try
                        {
                            ZipFile.CreateFromDirectory(WatchingDirectory, ArchiveName);
                        }
                        catch (Exception ex)
                        {
                            ArchivingErrorMessage = ex.Message;
                        }
                        isChanging = true;
                        FilesArchiving?.Invoke(this, EventArgs.Empty);
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
