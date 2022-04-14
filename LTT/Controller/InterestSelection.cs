using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
namespace LTT.Controller
{
    class InterestSelection : WholeLecture
    {
        protected InterestLecture interestLecture;
        public InterestSelection(Instances instances):base (instances)
        {
            this.interestLecture = instances.InterestLecture;
        }


        public void SelectMenu()
        {
            Console.CursorVisible = false;
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                Console.Clear();
                basicView.InterestForm();
                selected = input.SwicthMenu(5);
                switch (selected)
                {
                    case 0://관심과목 담기
                        SearchLecture();
                        break;
                    case 1://관심과목 조회

                        break;
                    case 2://관심과목 시간표

                        break;
                    case 3://관심과목 삭제

                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    case Constant.ESCAPE_INT:
                        Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐
                        basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 1);
                        isNotEscape = false;
                        break;
                }
            }
        }


        public void SearchLecture()
        {
            Console.Clear();
            lectureView.SelectInterstForm();
            storage.Init();
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                selected = SwicthRow();
                switch (selected)
                {
                    case 0:
                        SelectMajor();
                        break;
                    case 1:
                        SelectDivision();
                        break;
                    case 2:
                        SelectLectureName();
                        break;
                    case 3:
                        SelectProfessor();
                        break;
                    case 4:
                        SelectCourse();
                        break;
                    case 5:
                        ShowLectures();

                        Console.Clear();
                        lectureView.SelectInterstForm();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }

        protected void SelectDivision()
        {
            Console.CursorVisible = true;
            storage.LectureNumber = "";
            storage.Division = "";
            Console.SetCursorPosition(70 + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 50);
            lectureView.SelectDivisionForm();
            while (storage.LectureNumber.Length < 2)
            {
                Console.SetCursorPosition(34, Console.CursorTop);
                storage.LectureNumber = input.GetUserString(6, 2);//예외처리 숫자만 입력 2글자 이상 입력
            }
            if (storage.LectureNumber == Constant.ESCAPE_STRING)
            {
                storage.LectureNumber = "";
                basicView.DeleteString(70 + 20, Console.CursorTop, 50);
            }
            while (storage.Division.Length < 2)
            {
                Console.SetCursorPosition(70 + 64, Console.CursorTop);
                storage.Division = input.GetUserString(3, 2);//예외처리 숫자만 입력 2글자 이상 입력
            }
            if (storage.Division == Constant.ESCAPE_STRING)
            {
                storage.LectureNumber = "";
                storage.Division = "";
                basicView.DeleteString(70 + 20, Console.CursorTop, 50);
            }
            Console.CursorVisible = false;
        }

        protected void AddInterest()
        {
            Console.SetCursorPosition(0, 6);
            Console.Write("신청가능 학점:{0}",interestLecture.MaximumGrades-interestLecture.CurrentGrades);
            //Console.SetCursorPosition(, Console.CursorTop);
            Console.Write("신청 학점:");
            Console.SetCursorPosition(70 + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 50);
            lectureView.SelectMore();
            int selected = SwitchColumn(2);
        }
    }
}
