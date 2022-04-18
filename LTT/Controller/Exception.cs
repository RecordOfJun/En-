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
        private void ReadAndErase(int leftCusor,int eraseLength)//예외 안내문 제거 함수
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
        public bool IsNotNumberForm(string number)//강의 추가 시 숫자 예외
        {
            Regex numberForm = new Regex(@"^[0-9]+$");
            if (numberForm.IsMatch(number))
                return false;
            Console.SetCursorPosition(48, Console.CursorTop);
            exceptionView.NumberException();
            ReadAndErase(Constant.NUMBER_EXCEPTION, Constant.NUMBER_EXCEPTION_LENGTH);
            return true;
        }
        public bool IsIDForm(string id)//아이디 예외처리
        {
            Regex idForm = new Regex(@"^[0-9]{8}$");//아이디 체크
            if (idForm.IsMatch(id))
                return true;
            Console.SetCursorPosition(Constant.ID_EXCEPTION, Constant.LOGIN_ID_INDEX);
            exceptionView.IdException();
            ReadAndErase(Constant.ID_EXCEPTION, Constant.ID_EXCEPTION_LENGTH);
            return false;
        }
        public void NotExistException()//목록에 존재하지 않음 예외처리
        {
            Console.SetCursorPosition(Constant.NUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.SearchException();
            ReadAndErase(Constant.NUMBER_EXCEPTION, Constant.EXIST_EXCEPTION_LENGTH);
        }
        public void OverlapException()//중복과목 예외처리
        {
            Console.SetCursorPosition(Constant.NUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.OverlapException();
            ReadAndErase(Constant.NUMBER_EXCEPTION, Constant.NUMBER_EXCEPTION_LENGTH);
        }
        public void TimeOverlapException()//시간표 겹침 예외처리
        {
            Console.SetCursorPosition(Constant.NUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.TimeOverlapException();
            ReadAndErase(Constant.NUMBER_EXCEPTION, Constant.TIME_EXCEPTION_LENGTH);
        }
        public void OverGrades()//학점초과 예외처리
        {
            Console.SetCursorPosition(Constant.NUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.OverGradesException();
            ReadAndErase(Constant.NUMBER_EXCEPTION, Constant.TIME_EXCEPTION_LENGTH);
        }
        public bool IsLectureNumberForm(string lectureNumber)//학수번호 예외처리
        {
            Regex lectureNumberForm = new Regex(@"^[0-9]{6}$");
            if (lectureNumberForm.IsMatch(lectureNumber))
                return false;
            Console.SetCursorPosition(Constant.LECTRUENUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.LectureNumberException();
            ReadAndErase(Constant.LECTRUENUMBER_EXCEPTION, Constant.ID_EXCEPTION_LENGTH);
            return true;
        }
        public bool IsDivision(string division)//분반 예외처리
        {
            Regex divisionForm = new Regex(@"^[0-9]{3}$");
            if (divisionForm.IsMatch(division))
                return false;
            Console.SetCursorPosition(Constant.LECTRUENUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.DivisionException();
            ReadAndErase(Constant.LECTRUENUMBER_EXCEPTION, Constant.DIVISION_EXCEPTION_LENGTH);
            return true;
        }
        public bool IsProfessorAndLectureNameCheck(string userInput)//교수,과목명 예외처리
        {
            Regex check = new Regex(@"^[가-힣|a-zA-Z]{2,}$");
            if (check.IsMatch(userInput))
                return false;
            Console.SetCursorPosition(Constant.PROFESSOR_EXCEPTION, Console.CursorTop);
            exceptionView.StringException();
            ReadAndErase(Constant.PROFESSOR_EXCEPTION, Constant.PROFESSOR_EXCEPTION_LENGTH);
            return true;
        }
        public void InsertSucess()//추가 성공
        {
            Console.SetCursorPosition(Constant.NUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.ShowInsertSucess();
            ReadAndErase(Constant.NUMBER_EXCEPTION, Constant.NUMBER_EXCEPTION_LENGTH);
        }
        public void DeleteSucess()//삭제 성공
        {
            Console.SetCursorPosition(Constant.NUMBER_EXCEPTION, Console.CursorTop);
            exceptionView.ShowDeleteSucess();
            ReadAndErase(Constant.NUMBER_EXCEPTION, Constant.NUMBER_EXCEPTION_LENGTH);
        }
    }
}
