using System;
using System.Collections.Generic;
using System.Text;
using Library.View;
using System.IO;
using MySql.Data.MySqlClient;
namespace Library.Model
{
    class LogDAO//로그 관리 클래스
    {
        private string query;
        private string logData;
        List<int> numberList;
        List<string> dataList;
        private static LogDAO log;
        MySqlConnection connection;
        MySqlCommand command;
        ExceptionView exceptionView;
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Log.txt";//로그 바탕화면 경로
        private LogDAO()
        {
            connection = new MySqlConnection(Constant.SERVER_DATA);
            exceptionView = new ExceptionView();
            numberList = new List<int>();
            dataList = new List<string>();
        }
        public static LogDAO GetLog()//싱글톤 사용
        {
            if (log == null)
                log = new LogDAO();
            return log;
        }

        public void LogInit()//로그 초기화
        {
            connection.Open();
            query = "";
            query += Constant.INIT_LOG;
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            exceptionView.LogComplete("(초기화를 완료했습니다!)");
        }
        public void LogAdd(string data)//로그 추가
        {
            logData = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + data + "]";
            connection.Open();
            query = "";
            query += string.Format(Constant.INSERT_LOG,logData);
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        private void LoadLog()
        {
            numberList.RemoveAll(element => element > 0);
            dataList.RemoveAll(element=>element.Length>0);
            connection.Open();
            query = "";
            query += Constant.SELECT_LOG;
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            logData = Constant.EMPTY;
            while (reader.Read())
            {
                numberList.Add(int.Parse(reader["LOG_NUM"].ToString()));
                dataList.Add(reader["data"].ToString());
            }
            connection.Close();
        }
        public void ShowLog()//로그 조회
        {
            LoadLog();
            exceptionView.LogView(numberList,dataList);         
        }
        public string Revise()
        {
            string logNumber="";
            bool isContinue = true;
            while (isContinue)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX, 22);
                logNumber = KeyProcessing.GetInput().GetUserString(3, Constant.NOT_PASSWORD_TYPE);
                if (logNumber == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_STRING;
                if (numberList.Exists(element => element.ToString() == logNumber))
                    break;
                else
                    exceptionView.InsertException(logNumber.Length, " (정확한 로그번호를 입력하세요!)");
            }
            connection.Open();
            query = "";
            query += string.Format(Constant.DELETE_LOG,logNumber);
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return Constant.EMPTY;
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
            LoadLog();
            for (int count = 0; count < numberList.Count; count++)
            {
                logData+=new string('-', Console.WindowWidth)+"\n";
                logData += "로그번호:" + numberList[count] + "\n";
                logData += "내용:" + dataList[count] + "\n";
                logData += new string('-', Console.WindowWidth) + "\n";
            }
            File.WriteAllText(filePath, logData);
            exceptionView.LogComplete("(저장을 완료했습니다!)");
        }
    }
}
