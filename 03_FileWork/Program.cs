using System;
using System.IO;
using System.Windows.Forms;

namespace FileInfo_Copy
{
    class Program
    {
        static void Main()
        {
            string param = @"C:\Users\Vlad\Desktop\test.bin";

            var file = new FileInfo(param);

            try
            {
                file.Delete();
                Console.WriteLine("File deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
