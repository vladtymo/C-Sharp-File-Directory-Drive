using System;
using System.IO;
using System.Windows.Forms;

namespace FileInfoDemo
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            string path = @"C:\Windows\notepad.exe";

            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
            }

            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                Console.WriteLine("FileName   : {0}", file.Name);
                Console.WriteLine("Ext        : {0}", file.Extension);
                Console.WriteLine("Path       : {0}", file.FullName);
                Console.WriteLine("Dir        : {0}", file.Directory);
                Console.WriteLine("Size(MB)   : {0}", ToMegabytes(file.Length));
                Console.WriteLine("Last Access: {0}", file.LastAccessTime);
            }
            else
            {
                Console.WriteLine("File not existed.");
            }

            Console.ReadKey();
        }
        static double ToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}

