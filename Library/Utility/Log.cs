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
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Log.txt";
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
            logData="";
        }
        public void LogAdd(string data)
        {
            logData+="["+DateTime.Now.ToString("yyyy-MM-dd HH:mm")+ data + "]\n";
        }
        public void ShowLog()
        {

        }
        public void DeleteLogFile()
        {
            bool isExistFile = File.Exists(filePath);
            
            if (!isExistFile)
            {
                return;
            }
            File.Delete(filePath);

        }
        public void SaveLogFile()
        {
            File.WriteAllText(filePath, logData);
        }
    }
}
