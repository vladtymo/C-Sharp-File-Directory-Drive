using System;
using System.IO;
using System.Text;
using static System.Console;
namespace SimpleProject
{
    class Program
    {
        static void WriteFile(FileInfo f)
        {
            using (FileStream fs = f.Open(FileMode.Create, FileAccess.Write, FileShare.None))
            {
                WriteLine("\nEnter the data to write to the file:");
                string writeText = ReadLine();
                byte[] writeBytes = Encoding.Default.GetBytes(writeText);
                fs.Write(writeBytes, 0, writeBytes.Length);
                WriteLine("\nData recorded!\n");
            }
        }
        static string ReadFile(FileInfo f)
        {
            using (FileStream fs = f.OpenRead())
            {
                byte[] readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                return Encoding.Default.GetString(readBytes);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Test");

            if (!dir.Exists) // если каталог не существует
            {
                dir.Create(); // создаем каталог
            }

            WriteLine($"Last access time to the directory:{ dir.LastAccessTime}");

            // создаем подкаталог
            DirectoryInfo dir1 = dir.CreateSubdirectory("Subdir1");

            WriteLine($"Full path to the directory:\n{ dir1.FullName}");

            FileInfo fInfo = new FileInfo(dir1 + @"\Test.bin");
            WriteFile(fInfo);

            Console.WriteLine(ReadFile(fInfo));

            WriteLine($"\n\tOnly files with the extension '.bin':");
            FileInfo[] files = dir1.GetFiles("*.bin");
            foreach (FileInfo f in files)
            {
                WriteLine(f.Name);
            }
            WriteLine();
        }
    }
}