using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
namespace LTT.Controller
{
    class WholeLecture
    {
        protected LectureView lectureView ;
        protected BasicView basicView;
        protected Exception exception;
        protected Input input;
        protected List<LectureVO> lectureTable;
        protected List<LectureVO> searchTable;
        protected LectureVO storage;
        public WholeLecture(Instances instances)
        {
            storage = new LectureVO();
            searchTable = new List<LectureVO>();
            this.lectureTable = instances.lectureTable;
            this.lectureView = instances.lectureView;
            this.basicView = instances.basicView;
            input = new Input(basicView);
            this.exception = instances.exception;
        }
        public void SearchLecture()
        {
            Console.Clear();
            lectureView.SelectLectureForm();
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
                        SelectDistribution();
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
                        ShowAllLectures();
                        Console.Clear();
                        lectureView.SelectLectureForm();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }
        protected int SwicthRow()//함수로 뺄 여지가 있음
        {
            int index = 0;
            int selected = 0;
            bool isNotEnter = true;
            while (isNotEnter)
            {
                basicView.DeleteString(Constant.SEARCH_LEFT, 0, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, 1, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, 2, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, 3, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, 4, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, 5, 1);
                switch (index)//
                {
                    case 0:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, 0);
                        break;
                    case 1:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, 1);
                        break;
                    case 2:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, 2);
                        break;
                    case 3:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, 3);
                        break;
                    case 4:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, 4);
                        break;
                    case 5:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, 5);
                        break;
                }
                Console.Write(">");
                index = input.GetUpDown(index, 6);
                if (index == Constant.RETURN)
                    return selected;
                if (index == Constant.ESCAPE_INT)
                    return Constant.ESCAPE_INT;
                selected = index;
            }
            return selected;
        }
        protected int SwitchColumn(int NumberOfChoice)//함수로 뺄 여지가 있음
        {
            int index = 0;
            int selected = 0;
            bool isNotEnter = true;
            while (isNotEnter)
            {
                basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT + 33, Console.CursorTop, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT + 50, Console.CursorTop, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT + 69, Console.CursorTop, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT + 87, Console.CursorTop, 1);
                switch (index)//
                {
                    case 0:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT+20, Console.CursorTop);
                        break;
                    case 1:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT + 33, Console.CursorTop);
                        break;
                    case 2:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT + 50, Console.CursorTop);
                        break;
                    case 3:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT + 69, Console.CursorTop);
                        break;
                    case 4:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT + 87, Console.CursorTop);
                        break;
                }
                Console.Write(">");
                index = input.GetLeftRight(index, NumberOfChoice);
                if (index == Constant.RETURN)
                    return selected;
                if (index == Constant.ESCAPE_INT)
                    return Constant.ESCAPE_INT;
                selected = index;
            }
            return selected;
        }
        protected void SelectMajor()
        {
            Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectMajorForm();
            int selected=SwitchColumn(5);
            switch (selected)
            {
                case 0:
                    storage.Major = "";
                    break;
                case 1:
                    storage.Major = "컴퓨터공학과";
                    break;
                case 2:
                    storage.Major = "소프트웨어학과";
                    break;
                case 3:
                    storage.Major = "지능기전공학부";
                    break;
                case 4:
                    storage.Major = "기계항공우주공학부";
                    break;
                case Constant.ESCAPE_INT:
                    storage.Major = "";
                    basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                    break;
            }

        }
        private void SelectDistribution()
        {
            Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectDistributionForm();
            int selected = SwitchColumn(4);
            switch (selected)
            {
                case 0:
                    storage.Distribution = "";
                    break;
                case 1:
                    storage.Distribution = "교양필수";
                    break;
                case 2:
                    storage.Distribution = "전공필수";
                    break;
                case 3:
                    storage.Distribution = "전공선택";
                    break;
                case Constant.ESCAPE_INT:
                    storage.Distribution = "";
                    basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                    break;
            }
        }
        protected void SelectProfessor()
        {
            Console.CursorVisible = true;
            storage.Professor = "";
            Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectProfessorForm();
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.SEARCH_LEFT + 32, Console.CursorTop);
                storage.Professor = input.GetUserString(10, 2);
                if (storage.Professor == Constant.ESCAPE_STRING)
                {
                    storage.Professor = "";
                    basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                    break;
                }
                isException = exception.IsProfessorAndLectureNameCheck(storage.Professor);
            }
            Console.CursorVisible = false;
        }
        protected void SelectLectureName()
        {
            Console.CursorVisible = true;
            storage.LectureName = "";
            Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectClassNameForm();
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.SEARCH_LEFT + 34, Console.CursorTop);
                storage.LectureName = input.GetUserString(10, 2);
                if (storage.LectureName == Constant.ESCAPE_STRING)
                {
                    storage.LectureName = "";
                    basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                    break;
                }
                isException = exception.IsProfessorAndLectureNameCheck(storage.LectureName);
            }
            Console.CursorVisible = false;
        }
        protected void SelectCourse()
        {
            Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectCourseForm();
            int selected = SwitchColumn(4);
            switch (selected)
            {
                case 0:
                    storage.Course = "";
                    break;
                case 1:
                    storage.Course = "1";
                    break;
                case 2:
                    storage.Course = "2";
                    break;
                case 3:
                    storage.Course = "3";
                    break;
                case Constant.ESCAPE_INT:
                    storage.Course = "";
                    basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                    break;
            }
        }
        private void ShowAllLectures()
        {
            Console.SetCursorPosition(0, 7);
            foreach (LectureVO table in lectureTable)
            {
                if (table.Sequence=="NO"|| (table.Distribution.Contains(storage.Distribution) && table.Major.Contains(storage.Major) && table.Professor.ToUpper().Contains(storage.Professor.ToUpper()) && table.LectureName.ToUpper().Contains(storage.LectureName.ToUpper()) && table.Course.Contains(storage.Course)))
                {
                    for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
                    {
                        lectureView.ShowLecture(column, table);
                    }
                    if(table.Sequence == "NO")
                    {
                        Console.WriteLine();
                        Console.Write(new string('=',Console.WindowWidth));
                    }
                    else
                        Console.WriteLine();
                }
            }
            bool isNotESC = true;
            while (isNotESC)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                basicView.DeleteString(Console.CursorLeft - 1, Console.CursorTop, 2);
                if (key.Key == ConsoleKey.Escape)
                    isNotESC = false;
            }
        }
    }
}
