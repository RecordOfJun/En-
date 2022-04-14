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
                        ShowLectures();
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
                basicView.DeleteString(0, 0, 1);
                basicView.DeleteString(0, 1, 1);
                basicView.DeleteString(0, 2, 1);
                basicView.DeleteString(0, 3, 1);
                basicView.DeleteString(0, 4, 1);
                basicView.DeleteString(0, 5, 1);
                switch (index)//
                {
                    case 0:
                        Console.SetCursorPosition(0, 0);
                        break;
                    case 1:
                        Console.SetCursorPosition(0, 1);
                        break;
                    case 2:
                        Console.SetCursorPosition(0, 2);
                        break;
                    case 3:
                        Console.SetCursorPosition(0, 3);
                        break;
                    case 4:
                        Console.SetCursorPosition(0, 4);
                        break;
                    case 5:
                        Console.SetCursorPosition(0, 5);
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
                basicView.DeleteString(20, Console.CursorTop, 1);
                basicView.DeleteString(33, Console.CursorTop, 1);
                basicView.DeleteString(50, Console.CursorTop, 1);
                basicView.DeleteString(69, Console.CursorTop, 1);
                basicView.DeleteString(87, Console.CursorTop, 1);
                switch (index)//
                {
                    case 0:
                        Console.SetCursorPosition(20, Console.CursorTop);
                        break;
                    case 1:
                        Console.SetCursorPosition(33, Console.CursorTop);
                        break;
                    case 2:
                        Console.SetCursorPosition(50, Console.CursorTop);
                        break;
                    case 3:
                        Console.SetCursorPosition(69, Console.CursorTop);
                        break;
                    case 4:
                        Console.SetCursorPosition(87, Console.CursorTop);
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
            Console.SetCursorPosition(20, Console.CursorTop);
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
                    basicView.DeleteString(20, Console.CursorTop, 100);
                    break;
            }

        }
        private void SelectDistribution()
        {
            Console.SetCursorPosition(20, Console.CursorTop);
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
                    basicView.DeleteString(20, Console.CursorTop, 100);
                    break;
            }
        }
        protected void SelectProfessor()
        {
            Console.CursorVisible = true;
            storage.Professor = "";
            Console.SetCursorPosition(20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectProfessorForm();
            while (storage.Professor.Length < 2)
            {
                Console.SetCursorPosition(32, Console.CursorTop);
                storage.Professor = input.GetUserString(20, 2);
            }
            if (storage.Professor == Constant.ESCAPE_STRING)
            {
                storage.Professor = "";
                basicView.DeleteString(20, Console.CursorTop, 100);
            }
            Console.CursorVisible = false;
        }
        protected void SelectLectureName()
        {
            Console.CursorVisible = true;
            storage.LectureName = "";
            Console.SetCursorPosition(20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectClassNameForm();
            while (storage.LectureName.Length < 2)
            {
                Console.SetCursorPosition(34, Console.CursorTop);
                storage.LectureName = input.GetUserString(20, 2);
            }
            if (storage.LectureName == Constant.ESCAPE_STRING)
            {
                storage.LectureName = "";
                basicView.DeleteString(20, Console.CursorTop, 100);
            }
            Console.CursorVisible = false;
        }
        protected void SelectCourse()
        {
            Console.SetCursorPosition(20, Console.CursorTop);
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
                    basicView.DeleteString(20, Console.CursorTop, 100);
                    break;
            }
        }
        protected void ShowLectures()
        {
            Console.SetCursorPosition(0, 7);
            searchTable.RemoveAll(element=>true);
            foreach (LectureVO table in lectureTable)
            {
                if (table.Sequence=="NO"|| table.Distribution.Contains(storage.Distribution) && table.LectureNumber.Contains(storage.LectureNumber) && table.Division.Contains(storage.Division) && (table.Major.Contains(storage.Major) && table.Professor.ToUpper().Contains(storage.Professor.ToUpper()) && table.LectureName.ToUpper().Contains(storage.LectureName.ToUpper()) && table.Course.Contains(storage.Course)))
                {
                    if (table.Sequence != "NO")
                        searchTable.Add(table);
                    for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
                    {
                        switch (column)
                        {
                            case (int)Constant.SECTOR.SEQUENCE:
                                Console.Write(table.Sequence);
                                break;
                            case (int)Constant.SECTOR.MAJOR:
                                Console.SetCursorPosition((int)Constant.SECTOR.MAJOR_INDEX, Console.CursorTop);
                                Console.Write(table.Major);
                                break;
                            case (int)Constant.SECTOR.LECTURE_NUMBER:
                                Console.SetCursorPosition((int)Constant.SECTOR.LECTURE_NUMBER_INDEX, Console.CursorTop);
                                Console.Write(table.LectureNumber);
                                break;
                            case (int)Constant.SECTOR.DIVISION:
                                Console.SetCursorPosition((int)Constant.SECTOR.DIVISION_INDEX, Console.CursorTop);
                                Console.Write(table.Division);
                                break;
                            case (int)Constant.SECTOR.LECTURE_NAME:
                                Console.SetCursorPosition((int)Constant.SECTOR.LECTURE_NAME_INDEX, Console.CursorTop);
                                Console.Write(table.LectureName);
                                break;
                            case (int)Constant.SECTOR.DISTRIBUTION:
                                Console.SetCursorPosition((int)Constant.SECTOR.DISTRIBUTION_INDEX, Console.CursorTop);
                                Console.Write(table.Distribution);
                                break;
                            case (int)Constant.SECTOR.COURSE:
                                Console.SetCursorPosition((int)Constant.SECTOR.COURSE_INDEX, Console.CursorTop);
                                Console.Write(table.Course);
                                break;
                            case (int)Constant.SECTOR.GRADE:
                                Console.SetCursorPosition((int)Constant.SECTOR.GRADE_INDEX, Console.CursorTop);
                                Console.Write(table.Grade);
                                break;
                            case (int)Constant.SECTOR.DAY_AND_TIME:
                                Console.SetCursorPosition((int)Constant.SECTOR.DAY_AND_TIME_INDEX, Console.CursorTop);
                                Console.Write(table.Time);
                                break;
                            case (int)Constant.SECTOR.PLACE:
                                Console.SetCursorPosition((int)Constant.SECTOR.PLACE_INDEX, Console.CursorTop);
                                Console.Write(table.Place);
                                break;
                            case (int)Constant.SECTOR.PROFESSOR:
                                Console.SetCursorPosition((int)Constant.SECTOR.PROFESSOR_INDEX, Console.CursorTop);
                                Console.Write(table.Professor);
                                break;
                            case (int)Constant.SECTOR.LANGUAGE:
                                Console.SetCursorPosition((int)Constant.SECTOR.LANGUAGE_INDEX, Console.CursorTop);
                                Console.Write(table.Language);
                                break;
                        }
                    }
                    if(table.Sequence == "NO")
                    {
                        Console.WriteLine();
                        Console.WriteLine(new string('=',Console.WindowWidth));
                    }
                    Console.WriteLine();
                }
            }
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                    return;
            }
        }
    }
}
