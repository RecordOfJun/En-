using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Library.View
{
    class ExceptionView
    {
        BasicView basicView = new BasicView();
        DBConnection dBConnection;
        public ExceptionView()
        {
            dBConnection = DBConnection.GetDBConnection();
        }
        private void ReadAndErase(int leftCusor, int eraseLength)//예외 안내문 제거 함수
        {
            Console.ReadKey();
            basicView.DeleteString(leftCusor, Console.CursorTop, eraseLength);
        }
        public void SearchException(int inputLength,string insert)
        {
            int printLocation = inputLength + Constant.DATA_INSERT_CURSOR;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
            ReadAndErase(Constant.DATA_INSERT_CURSOR, 60);
            basicView.DeleteString(printLocation, Console.CursorTop, 30);
        }
        public void InsertException(int inputLength, string insert)
        {
            int printLocation = inputLength + Constant.ADD_INDEX+2;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
            ReadAndErase(printLocation, 50);
        }
        public void SearchComplete(int inputLength, string insert)
        {
            int printLocation = inputLength + Constant.DATA_INSERT_CURSOR;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
            ReadAndErase(printLocation, 50);
        }
        public void InsertComplete(int inputLength, string insert)
        {
            int printLocation = inputLength + Constant.ADD_INDEX+2;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void CanNotLogin(int length)
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            InsertException(0, "(아이디와 비밀번호를 확인해 주세요!)");

        }
        public void AdminError(int length)
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            InsertException(0, "(틀렸습니다! 다시 입력해 주세요!)");
        }
        public void ClearLine(int index)
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
        }
        public void AskEscape()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("뒤          뒤로 돌아가면 자동으로 로그아웃이 됩니다. 정말 돌아가시겠습니까?");
            Console.WriteLine("  메뉴로 가길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
        public void AskExit()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                            정말 종료하시겠습니까?");
            Console.WriteLine("    종료하길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
        public void AskDelete(string name)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                   {0}을 정말 삭제하시겠습니까?",name);
            Console.WriteLine("    삭제하길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
        public void AskRevise(string name)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                   {0}의 수량을 정말 수정하시겠습니까?", name);
            Console.WriteLine("    수정하길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
    }
}
