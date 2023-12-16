using System;
using System.Diagnostics;
using System.IO;

// Отслеживание изменений в системе.

namespace FileSystemWatcherDemo
{
    class Program
    {
        static void Main()
        {

            var watcher = new FileSystemWatcher 
            { 
                Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
            };
          
            //watcher.Created += new FileSystemEventHandler(WatcherChanged);
            //watcher.Deleted += WatcherChanged;
            //watcher.Renamed += WatcherChanged;
            //watcher.Changed += WatcherChanged;
            watcher.EnableRaisingEvents = true; // enable monitoring
            Console.WriteLine("Monitoring...");

            var change = watcher.WaitForChanged(WatcherChangeTypes.Deleted);
            Console.WriteLine(change.ChangeType);            
            Console.ReadKey();
        }
        
        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Directory changed({0}): {1}", e.ChangeType, e.FullPath);
        }
    }
}
