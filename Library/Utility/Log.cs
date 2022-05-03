using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Library.View;
namespace Library.Utility
{
    class Log//로그 관리 클래스
    {
        private string logData;
        private static Log log;
        ExceptionView exceptionView;
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Log.txt";//로그 바탕화면 경로
        private Log()
        {
            exceptionView = new ExceptionView();
            logData = "";
        }
        public static Log GetLog()//싱글톤 사용
        {
            if (log == null)
                log = new Log();
            return log;
        }

        public void LogInit()//로그 초기화
        {
            logData="";
            exceptionView.LogComplete("(초기화를 완료했습니다!)");
        }
        public void LogAdd(string data)//로그 추가
        {
            logData+="["+DateTime.Now.ToString("yyyy-MM-dd HH:mm")+ data + "]\n";
        }
        public void ShowLog()//로그 조회
        {
            exceptionView.LogView(logData);
            KeyProcessing.GetInput().IsEscAndEnter();

        }
        public void DeleteLogFile()//로그파일 삭제
        {
            bool isExistFile = File.Exists(filePath);
            
            if (!isExistFile)//바탕화면에 없을 때 예외처리
            {
                exceptionView.LogException("(파일이 존재하지 않습니다!)");
                return;
            }
            File.Delete(filePath);
            exceptionView.LogComplete("(삭제를 완료했습니다!)");
        }
        public void SaveLogFile()//바탕화면에 저장
        {
            File.WriteAllText(filePath, logData);
            exceptionView.LogComplete("(저장을 완료했습니다!)");
        }
    }
}
