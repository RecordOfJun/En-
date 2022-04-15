using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LTT.View;
namespace LTT.Controller
{
    class Exception
    {
        ExceptionView exceptionView;
        BasicView basicView;
        public Exception(ExceptionView exceptionView, BasicView basicView)
        {
            this.exceptionView = exceptionView;
            this.basicView = basicView;
        }
        private void ReadAndErase(int leftCusor,int eraseLength)
        {
            Console.ReadKey();
            basicView.DeleteString(leftCusor, Console.CursorTop, eraseLength);
        }
        public void ExitProgramm()
        {
            ConsoleKeyInfo key;
            exceptionView.AskExit();
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Environment.Exit(0);
            }
            return;
        }
        public bool IsNotNumberForm(string number)
        {
            Regex numberForm = new Regex(@"^[0-9]+$");//강의 넘버체크
            if (numberForm.IsMatch(number))
                return false;
            Console.SetCursorPosition(48, Console.CursorTop);
            exceptionView.NumberException();
            ReadAndErase(48, 20);
            return true;
        }
        public bool IsIDForm(string id)
        {
            Regex idForm = new Regex(@"^[0-9]{8}$");//아이디 체크
            if (idForm.IsMatch(id))
                return true;
            Console.SetCursorPosition(Constant.LOGIN_INDEX+16, Constant.LOGIN_ID_INDEX);
            exceptionView.IdException();
            ReadAndErase(Constant.LOGIN_INDEX + 16, 25);
            return false;
        }
        public void NotExistException()
        {
            Console.SetCursorPosition(48, Console.CursorTop);
            exceptionView.SearchException();
            ReadAndErase(48, 32);
        }
        public void OverlapException()
        {
            Console.SetCursorPosition(48, Console.CursorTop);
            exceptionView.OverlapException();
            ReadAndErase(48, 20);
        }
        public void TimeOverlapException()
        {
            Console.SetCursorPosition(48, Console.CursorTop);
            exceptionView.TimeOverlapException();
            ReadAndErase(48, 35);
        }
        public void OverGrades()
        {
            Console.SetCursorPosition(48, Console.CursorTop);
            exceptionView.OverGradesException();
            ReadAndErase(48, 35);
        }
        public bool IsLectureNumberForm(string lectureNumber)
        {
            Regex lectureNumberForm = new Regex(@"^[0-9]{6}$");
            if (lectureNumberForm.IsMatch(lectureNumber))
                return false;
            Console.SetCursorPosition(100, Console.CursorTop);
            exceptionView.LectureNumberException();
            ReadAndErase(100, 25);
            return true;
        }
        public bool IsDivision(string division)
        {
            Regex divisionForm = new Regex(@"^[0-9]{3}$");
            if (divisionForm.IsMatch(division))
                return false;
            Console.SetCursorPosition(100, Console.CursorTop);
            exceptionView.LectureNumberException();
            ReadAndErase(100, 26);
            return true;
        }
        public bool IsProfessorAndLectureNameCheck(string userInput)
        {
            Regex check = new Regex(@"^[가-힣|a-zA-Z]{2,}$");
            if (check.IsMatch(userInput))
                return false;
            Console.SetCursorPosition(82, Console.CursorTop);
            exceptionView.StringException();
            ReadAndErase(82, 40);
            return true;
        }
    }
}
