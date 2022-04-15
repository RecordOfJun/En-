using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Model;
namespace LTT.View
{
    class LectureView
    {
        public void ShowLecture(int column,LectureVO table)
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
        public void SelectLectureForm()
        {
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  개설학과전공");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  이수구분");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  교과목명");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  교수명");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  학년");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  조회");
        }
        public void SelectMajorForm()
        {
            Console.Write("  전체         컴퓨터공학과     소프트웨어공학과   지능기전공학부    기계항공우주공학부");

        }
        public void SelectDistributionForm()
        {
            Console.Write("  전체         교양필수         전공필수           전공선택");
        }
        public void SelectProfessorForm()
        {
            Console.Write("교수명 입력:");
        }
        public void SelectClassNameForm()
        {
            Console.Write("교과목명 입력:");
        }
        public void SelectDivisionForm()
        {
            Console.Write("학수번호 입력:                    분반 입력:");
        }
        public void SelectCourseForm()
        {
            Console.Write("  전체         1학년            2학년              3학년");
        }
        public void SelectInterstForm()
        {
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  개설학과전공");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  학수번호");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  교과목명");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  교수명");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  학년");
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine("  조회");
        }
        public void SelectMore()
        {
            Console.Write("  계속 입력    재검색");
        }
        public void CheckGrades(int maximumGrades,int currentGrades)
        {
            Console.SetCursorPosition(0, 6);
            Console.Write("신청가능 학점:{0}", maximumGrades - currentGrades);
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.Write("신청 학점:{0}", currentGrades);
            Console.SetCursorPosition(34, Console.CursorTop);
            Console.Write("강의 NO:");
        }
        public void CheckLectureNumber(int maximumGrades, int currentGrades)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("신청가능 학점:{0}", maximumGrades - currentGrades);
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.Write("신청 학점:{0}", currentGrades);
            Console.SetCursorPosition(34, Console.CursorTop);
            Console.Write("강의 NO:");
        }
        public void InterestLabel()
        {
            Console.Clear();
            Console.SetCursorPosition(70, 0);
            Console.WriteLine("관심과목 조회");
        }
    }
}
