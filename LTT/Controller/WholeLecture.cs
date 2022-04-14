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
        LectureView lectureView = new LectureView();
        BasicView basicView = new BasicView();
        Input input;
        List<LectureVO> lectureTable;
        string major;
        string distribution;
        string professor;
        string lectureName;
        string course;
        public WholeLecture(List<LectureVO> lectureTable)
        {
            this.lectureTable = lectureTable;
            input = new Input(basicView);
        }
        public void SearchLecture()
        {
            Console.Clear();
            lectureView.SelectLectureForm();
            major = "";
            distribution = "";
            professor = "";
            lectureName = "";
            course="";
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

                        break;
                    case 3:

                        break;
                    case 4:
                        SelectCourse();
                        break;
                    case 5:
                        ShowLectures();
                        Console.ReadLine();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }
        private int SwicthRow()//함수로 뺄 여지가 있음
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
        private int SwitchColumn(int NumberOfChoice)//함수로 뺄 여지가 있음
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
        private void SelectLectureData()
        {


        }
        private void SelectMajor()
        {
            Console.SetCursorPosition(20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectMajorForm();
            int selected=SwitchColumn(5);
            switch (selected)
            {
                case 0:
                    major = "";
                    break;
                case 1:
                    major = "컴퓨터공학과";
                    break;
                case 2:
                    major = "소프트웨어학과";
                    break;
                case 3:
                    major = "지능기전공학부";
                    break;
                case 4:
                    major = "기계항공우주공학부";
                    break;
                case Constant.ESCAPE_INT:
                    major = "";
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
                    distribution = "";
                    break;
                case 1:
                    distribution = "교양필수";
                    break;
                case 2:
                    distribution = "전공필수";
                    break;
                case 3:
                    distribution = "전공선택";
                    break;
                case Constant.ESCAPE_INT:
                    distribution = "";
                    basicView.DeleteString(20, Console.CursorTop, 100);
                    break;
            }
        }
        private void SelectProfessor()
        {

        }
        private void SelectClassName()
        {

        }
        private void SelectCourse()
        {
            Console.SetCursorPosition(20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectCourseForm();
            int selected = SwitchColumn(4);
            switch (selected)
            {
                case 0:
                    course = "";
                    break;
                case 1:
                    course = "1";
                    break;
                case 2:
                    course = "2";
                    break;
                case 3:
                    course = "3";
                    break;
                case Constant.ESCAPE_INT:
                    course = "";
                    basicView.DeleteString(20, Console.CursorTop, 100);
                    break;
            }
        }
        public void ShowLectures()
        {
            Console.Clear();
            foreach (LectureVO table in lectureTable)
            {
                if (table.Major.Contains(major) && table.Distribution.Contains(distribution) && table.Professor.Contains(professor) && table.LectureNAME.Contains(lectureName) && table.Course.Contains(course))
                {
                    for (int column = 1; column <= 12; column++)
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
                                Console.Write(table.LectureNAME);
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
                    Console.WriteLine();
                }
            }
        }
    }
}
