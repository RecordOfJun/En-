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
        public InterestSelection(Instances instances):base (instances)
        {
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

        private void SelectDivision()
        {
            Console.CursorVisible = true;
            storage.LectureNumber = "";
            storage.Division = "";
            Console.SetCursorPosition(20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectDivisionForm();
            while (storage.LectureNumber.Length < 2)
            {
                Console.SetCursorPosition(34, Console.CursorTop);
                storage.LectureNumber = input.GetUserString(6, 2);//예외처리
            }
            if (storage.LectureNumber == Constant.ESCAPE_STRING)
            {
                storage.LectureNumber = "";
                basicView.DeleteString(20, Console.CursorTop, 100);
            }
            while (storage.Division.Length < 2)
            {
                Console.SetCursorPosition(64, Console.CursorTop);
                storage.Division = input.GetUserString(3, 2);//예외처리
            }
            if (storage.Division == Constant.ESCAPE_STRING)
            {
                storage.LectureNumber = "";
                storage.Division = "";
                basicView.DeleteString(20, Console.CursorTop, 100);
            }
            Console.CursorVisible = false;
        }


    }
}
