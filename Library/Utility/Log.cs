using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Library.View;
namespace Library.Utility
{
    class Log
    {
        private string logData;
        private static Log log;
        ExceptionView exceptionView;
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Log.txt";
        private Log()
        {
            exceptionView = new ExceptionView();
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
            Console.SetCursorPosition(0, 20);
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine(logData);
            KeyProcessing.GetInput().IsEscAndEnter();

        }
        public void DeleteLogFile()
        {
            bool isExistFile = File.Exists(filePath);
            
            if (!isExistFile)
            {
                exceptionView.LogException("(파일이 존재하지 않습니다!)");
                return;
            }
            File.Delete(filePath);
            exceptionView.LogComplete("(삭제를 완료했습니다!)");
        }
        public void SaveLogFile()
        {
            File.WriteAllText(filePath, logData);
            exceptionView.LogComplete("(저장을 완료했습니다!)");
        }
    }
}
