using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class BasicView
    {
        public void LoginView(){
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("PW:");
        }
        public void DeleteString(int startCursorIndexOfX, int startCursorIndexOfY,int maximumLength)
        {
            Console.SetCursorPosition(startCursorIndexOfX, startCursorIndexOfY);
            Console.Write(new string(' ', maximumLength+1));
            Console.SetCursorPosition(startCursorIndexOfX, startCursorIndexOfY);

        }
        public void SetInputCursor(string inputString)
        {
            Console.Write(inputString);
        }
        public void WritePassword(string inputString)
        {
            Console.Write(new string('*', inputString.Length));
        }
        public void ShowAgain()
        {
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.Write("  다시 로그인  프로그램 종료");
        }
        public void MainMenuForm()
        {
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  강의 시간표 조회");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  관심과목 담기");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  수강신청");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  프로그램 종료");
        }
        public void InterestForm()
        {
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  관심과목 담기");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  관심과목 조회");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  관심과목 시간표");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  관심과목 삭제");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  프로그램 종료");
        }
        public void MyLectureForm()
        {
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  검색으로 수강신청");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  관심과목 수강신청");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  수강신청 내역조회");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  시간표 조회");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  수강내역 삭제");
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("  프로그램 종료");
        }
        public void ShowLabelAndLine(string insert)
        {
            Console.SetCursorPosition(70, 0);
            Console.Write(insert);
            Console.SetCursorPosition(140, 0);
            Console.WriteLine("뒤로가기:ESC");
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
