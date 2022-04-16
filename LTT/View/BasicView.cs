using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class BasicView
    {
        private void PrintMiddle(string insert)
        {
            Console.SetCursorPosition(Constant.MIDDLE_CUSOR, Console.CursorTop);
            Console.WriteLine(insert);
        }
        private void PrintMiddleLine(string insert)
        {
            Console.SetCursorPosition(Constant.MIDDLE_CUSOR, Console.CursorTop);
            Console.WriteLine(insert);
            Console.WriteLine();
        }
        private void SetCusorLeft(int Left,string insert)
        {
            Console.SetCursorPosition(Left, Console.CursorTop);
            Console.WriteLine(insert);
        }
        public void Label(string insert) 
        {
            ShowLabelAndLine(insert);
            //SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR,"==============================================================================================================");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR,"                                                                                                             ");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR,"              ####                       ####################                #################### ");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "              ####                       ####################                ####################");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "              ####                             ########                            ######## ");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "              ####                             ########                            ########");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "              ####                             ########                            ########");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "              ####                             ########                            ########        ");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "              ############                     ########                            ########            ");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "              ############                     ########                            ########             ");
            Console.WriteLine();
            Console.Write(new string('=', Console.WindowWidth));
            //SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "==============================================================================================================");

        }
        public void LoginView(){
            PrintMiddle("ID:");
            PrintMiddle("PW:");
        }
        public void LoginGuide()
        {
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "수강신청 프로그램에 오신것을 환영합니다.");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "     ID로 8자리의 학번을 입력해 주세요");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "           패스워드를 입력해 주세요");
            SetCusorLeft(Constant.LOGIN_GUIDE_CUSOR, "      (입력완료 혹은 메뉴선택 => Enter)");
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
            PrintMiddleLine("  전체 강의 조회");
            PrintMiddleLine("  관심과목 담기");
            PrintMiddleLine("  수강 신청");
            PrintMiddleLine("  프로그램 종료");
        }
        public void InterestForm()
        {
            PrintMiddleLine("  관심과목 담기");
            PrintMiddleLine("  관심과목 조회");
            PrintMiddleLine("  관심과목 시간표");
            PrintMiddleLine("  관심과목 삭제");
            PrintMiddleLine("  프로그램 종료");
        }
        public void MyLectureForm()
        {
            PrintMiddleLine("  검색으로 수강신청");
            PrintMiddleLine("  관심과목 수강신청");
            PrintMiddleLine("  수강신청 내역조회");
            PrintMiddleLine("  시간표 조회");
            PrintMiddleLine("  수강내역 삭제");
            PrintMiddleLine("  프로그램 종료");
        }
        public void ShowLabelAndLine(string insert)
        {
            Console.SetCursorPosition(Constant.MIDDLE_CUSOR, 0);
            Console.Write(insert);
            Console.SetCursorPosition(Constant.ESC_CUSOR, 0);
            Console.WriteLine("뒤로가기:ESC");
            Console.Write(new string('=', Console.WindowWidth));
        }
    }
}
