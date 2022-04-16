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
        private void SearchInit()
        {
            Console.Clear();
            basicView.Label();
            lectureView.SelectLectureForm();
            lectureView.SearchGuide();
            storage.Init();
        }
        public void SearchLecture()
        {
            SearchInit();
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
                        SearchInit();
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
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FIRST_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.SECOND_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.THIRD_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FOURTH_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FIFTH_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.SIXTH_MENU_CUSOR, 1);
                switch (index)//
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FIRST_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.SECOND_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.THIRD_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FOURTH_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FIFTH_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.SIXTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.SIXTH_MENU_CUSOR);
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
                basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.CUSOR_DELETE);
                basicView.DeleteString(Constant.COLUMN_SECOND_CUSOR, Console.CursorTop, Constant.CUSOR_DELETE);
                basicView.DeleteString(Constant.COLUMN_THIRD_CUSOR, Console.CursorTop, Constant.CUSOR_DELETE);
                basicView.DeleteString(Constant.COLUMN_FOURTH_CUSOR, Console.CursorTop, Constant.CUSOR_DELETE);
                basicView.DeleteString(Constant.COLUMN_FIFTH_CUSOR, Console.CursorTop, Constant.CUSOR_DELETE);
                switch (index)//
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        Console.SetCursorPosition(Constant.COLUMN_SECOND_CUSOR, Console.CursorTop);
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        Console.SetCursorPosition(Constant.COLUMN_THIRD_CUSOR, Console.CursorTop);
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        Console.SetCursorPosition(Constant.COLUMN_FOURTH_CUSOR, Console.CursorTop);
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        Console.SetCursorPosition(Constant.COLUMN_FIFTH_CUSOR, Console.CursorTop);
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
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectMajorForm();
            int selected=SwitchColumn(5);
            switch (selected)
            {
                case (int)Constant.Menu.FIRST_MENU:
                    storage.Major = "";
                    break;
                case (int)Constant.Menu.SECOND_MENU:
                    storage.Major = "컴퓨터공학과";
                    break;
                case (int)Constant.Menu.THIRD_MENU:
                    storage.Major = "소프트웨어학과";
                    break;
                case (int)Constant.Menu.FOURTH_MENU:
                    storage.Major = "지능기전공학부";
                    break;
                case (int)Constant.Menu.FIFTH_MENU:
                    storage.Major = "기계항공우주공학부";
                    break;
                case Constant.ESCAPE_INT:
                    storage.Major = "";
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
            }

        }
        private void SelectDistribution()
        {
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectDistributionForm();
            int selected = SwitchColumn(4);
            switch (selected)
            {
                case (int)Constant.Menu.FIRST_MENU:
                    storage.Distribution = "";
                    break;
                case (int)Constant.Menu.SECOND_MENU:
                    storage.Distribution = "교양필수";
                    break;
                case (int)Constant.Menu.THIRD_MENU:
                    storage.Distribution = "전공필수";
                    break;
                case (int)Constant.Menu.FOURTH_MENU:
                    storage.Distribution = "전공선택";
                    break;
                case Constant.ESCAPE_INT:
                    storage.Distribution = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
            }
        }
        protected void SelectProfessor()
        {
            Console.CursorVisible = true;
            storage.Professor = Constant.EMPTY;
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectProfessorForm();
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.PROFESSOR_CUSOR, Console.CursorTop);
                storage.Professor = input.GetUserString(Constant.STRING_INPUT_LENGTH, Constant.NOT_PASSWORD_TYPE);
                if (storage.Professor == Constant.ESCAPE_STRING)
                {
                    storage.Professor = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
                }
                isException = exception.IsProfessorAndLectureNameCheck(storage.Professor);
            }
            Console.CursorVisible = false;
        }
        protected void SelectLectureName()
        {
            Console.CursorVisible = true;
            storage.LectureName = Constant.EMPTY;
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectClassNameForm();
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.LECTURENAME_CUSOR, Console.CursorTop);
                storage.LectureName = input.GetUserString(Constant.STRING_INPUT_LENGTH, Constant.NOT_PASSWORD_TYPE);
                if (storage.LectureName == Constant.ESCAPE_STRING)
                {
                    storage.LectureName = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
                }
                isException = exception.IsProfessorAndLectureNameCheck(storage.LectureName);
            }
            Console.CursorVisible = false;
        }
        protected void SelectCourse()
        {
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectCourseForm();
            int selected = SwitchColumn(4);
            switch (selected)
            {
                case (int)Constant.Menu.FIRST_MENU:
                    storage.Course = "";
                    break;
                case (int)Constant.Menu.SECOND_MENU:
                    storage.Course = "1";
                    break;
                case (int)Constant.Menu.THIRD_MENU:
                    storage.Course = "2";
                    break;
                case (int)Constant.Menu.FOURTH_MENU:
                    storage.Course = "3";
                    break;
                case Constant.ESCAPE_INT:
                    storage.Course = "";
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
            }
        }
        private void ShowAllLectures()
        {
            Console.SetCursorPosition(Constant.INDEX_MINIMUM, Constant.SHOW_LECTURE_CUSOR);
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
