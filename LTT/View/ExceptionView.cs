using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class ExceptionView
    {
        public void NotCorrecId(string insert)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine(insert);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowException(string insert)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowSucess(string insert)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowInsertSucess()
        {
            ShowSucess("신청을 성공했습니다.");
        }
        public void ShowDeleteSucess()
        {
            ShowSucess("삭제를 성공했습니다.");
        }
        public void IdException()
        {
            ShowException("8자리 숫자를 입력해주세요");
        }
        public void SearchException()
        {
            ShowException("목록에 있는 숫자를 입력해주세요");
        }
        public void OverlapException()
        {
            ShowException("이미 신청한 과목입니다");
        }
        public void TimeOverlapException()
        {
            ShowException("기존의 신청과목과 시간이 겹칩니다");
        }
        public void OverGradesException()
        {
            ShowException("신청 가능학점을 초과했습니다");
        }
        public void NumberException()
        {
            ShowException("숫자를 입력해주세요");
        }
        public void LectureNumberException()
        {
            ShowException("6자리 숫자를 입력해 주세요");
        }
        public void DivisionException()
        {
            ShowException("3자리 숫자를 입력해 주세요");
        }
        public void StringException()
        {
            ShowException("2자리 이상의 영어나 한글을 입력해 주세요");
        }
        public void AskExit()
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write(new string('=',Console.WindowWidth));
            Console.SetCursorPosition(70, Console.CursorTop);
            Console.WriteLine("정말 종료하시겠습니까?");
            Console.SetCursorPosition(45, Console.CursorTop);
            Console.WriteLine("종료하길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
    }
}
