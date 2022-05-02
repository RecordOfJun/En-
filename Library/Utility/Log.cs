using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Library.Utility
{
    class Log
    {
        private string logData;
        private static Log log;
        private Log()
        {
            logData = "";
        }
        public static Log GetLog()
        {
            if (log == null)
                log = new Log();
            return log;
        }

        public void LogInit()
        {
            logData = "";
        }
        public void LogAdd(string data)
        {
            logData +="["+DateTime.Now.ToString("yyyy-MM-dd HH:mm")+ data + "]\n";
        }
        public void DeleteLogFile()
        {

        }
        public void SaveLogFile()
        {
            StreamWriter sw = new StreamWriter("Log.txt");
            sw.WriteLine(logData);
        }
    }
}
