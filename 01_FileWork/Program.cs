using System;
using System.Diagnostics;
using System.IO;


namespace _01_FileWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process.Start("notepad.exe", @"C:\Users\ТимощукВладиславВале\Desktop\bla.txt");

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"[{i+1}] drive: {drives[i].Name}");
            }
            int drive = int.Parse(Console.ReadLine()) - 1;

            //@"C:\Users\Vlad\Desktop"
            string path = drives[drive].Name; //Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            do
            {
                Console.Clear();
                DirectoryInfo dir = new DirectoryInfo(path);

                Console.WriteLine("Directory: \t{0}", dir.FullName);
                Console.WriteLine("CreationTime: {0}", dir.CreationTime);
                Console.WriteLine("Extension: {0}", dir.Extension);
                Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);
                Console.WriteLine("LastWriteTime: {0}", dir.LastWriteTime);
                Console.WriteLine("Name: {0}", dir.Name);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Directories ----------------------");
                foreach (var d in dir.GetDirectories())
                {
                    Console.WriteLine($"Directory: {d.Name}  time:  {d.CreationTime} atr: {d.Attributes}");
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Files --------------------------");
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine($"File: {file.Name}  time:  {file.CreationTime} atr: {file.Attributes}");
                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(path + @"\");
                string next = Console.ReadLine();
                Console.ResetColor();

                string nextPath = Path.Combine(path, next);

                Console.WriteLine("1 - Delete\n" +
                                  "2 - Rename\n" +
                                  "3 - Create\n" +
                                  "* - Open");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: Directory.Delete(nextPath); break;
                    case ConsoleKey.D2:
                        {
                            Console.Write("Enter a new folder name:");
                            string newName = Console.ReadLine();
                            Directory.Move(nextPath, Path.Combine(path, newName));
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Directory.CreateDirectory(nextPath);
                            break;
                        }
                    default:
                        path = nextPath;
                        break;
                }

            } while (true);
        }
    }
}
