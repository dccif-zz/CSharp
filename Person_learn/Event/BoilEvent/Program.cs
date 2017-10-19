using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BoilEvent
{
    class Boiler
    {
        private int temp;
        private int pressure;

        public Boiler(int t, int p)
        {
            temp = t;
            pressure = p;
        }

        public int getTemp()
        {
            return temp;
        }

        public int getPressure()
        {
            return pressure;
        }
    }

    class DelegateBoilerEvent
    {
        public delegate void BoilerLogHangler(string status);

        public event BoilerLogHangler BoilerEventLog;

        public void LogProcess()
        {
            string remarks = "O.K";
            Boiler b = new Boiler(100, 12);
            int t = b.getTemp();
            int p = b.getPressure();
            if (t > 150 || t < 80 || p < 12 || p > 15)
            {
                remarks = "Need Maintenance";
            }
            OnBoilerEventLog("Logging info:\n");
            OnBoilerEventLog("Temperature " + t + "\nPressure: " + p);
            OnBoilerEventLog("\nMessage; " + remarks);
        }

        public void OnBoilerEventLog(string message)
        {
            if(BoilerEventLog != null)
            {
                BoilerEventLog(message);
            }
        }
    }

    class BoilerInfoLogger
    {
        private FileStream fs;
        private StreamWriter sw;

        public BoilerInfoLogger(string filename)
        {
            fs = new FileStream(filename,FileMode.Append,FileAccess.Write);           
            sw = new StreamWriter(fs);
        }

        public void Logger(string info)
        {
            sw.WriteLine(info);
        }

        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }


    public class RecordBoilerInfo
    {
        static void Logger(string info)
        {
            Console.WriteLine(info);
        }

        static void Main(string[] args)
        {
            BoilerInfoLogger filelog = new BoilerInfoLogger("E:\\Boiler.txt");
            DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHangler(Logger);
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHangler(filelog.Logger);
            boilerEvent.LogProcess();
            Console.ReadLine();
            filelog.Close();
        }
    }
}
