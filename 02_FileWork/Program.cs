using System;
using System.IO;

namespace _02_FileWork
{
    class Program
    {
        static void Main(string[] args)
        { 
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Drive: {drive.Name}\n" +
                    $"Type: {drive.DriveType}");

                if (drive.IsReady)
                    Console.WriteLine($"Total size: {drive.TotalSize}\n" +
                        $"Total free size: {drive.TotalFreeSpace}\n" +
                        $"Format size: {drive.DriveFormat}");
            }
            Console.ReadKey();
        }
    }
}
