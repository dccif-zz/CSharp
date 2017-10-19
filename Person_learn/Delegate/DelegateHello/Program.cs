using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DelegateHello
{
    class PrintString
    {
        private static FileStream fs;
        private static StreamWriter sw;

        public delegate void printString(string s);

        public static void WriteToScreen(string str)
        {
            Console.WriteLine("The String is:{0}",str);
        }

        public static void WriteToFile(string s)
        {
            fs = new FileStream("D:\\Hello.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void sendString(printString ps)
        {
            ps("Hello,World");
        }

        static void Main(string[] args)
        {
            printString ps1 = new printString(WriteToScreen);
            printString ps2 = new printString(WriteToFile);
            sendString(ps1);
            sendString(ps2);
            Console.ReadKey();
        }
    }
}
