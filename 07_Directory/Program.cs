using System.IO;
using static System.Console;
namespace SimpleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Test";
            if (Directory.Exists(path))
            {
                WriteLine($"Date and time of catalog creation: { Directory.GetCreationTime(path)}");

                WriteLine($"\nSubdirectories in the specified directory: ");
                foreach (string item in Directory.GetDirectories(path))
                {
                    WriteLine($"\t{item}");
                }

                WriteLine($"\nLogical devices of this computer: ");
                foreach (string item in Directory.GetLogicalDrives())
                {
                    WriteLine($"\t{item}");
                }

                // удаляем каталог, все подкаталоги и файлы
                Directory.Delete(path, true);
            }
            if (!Directory.Exists(path))
            {
                WriteLine($"\nSpecified directory does not exist.\n");
            }
        }
    }
}