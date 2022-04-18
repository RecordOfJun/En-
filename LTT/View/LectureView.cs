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
        public void ShowTable(int column, string time)
        {
            switch (column)
            {
                case (int)Constant.TimeTableIndex.START_TIME:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.START_TIME_CURSOR, Console.CursorTop);
                    break;
                case (int)Constant.TimeTableIndex.SPECIAL_CHAR:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.SPECIAL_CHAR_CURSOR, Console.CursorTop);
                    break;
                case (int)Constant.TimeTableIndex.FINISH_TIME:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.FINISH_TIME_CURSOR, Console.CursorTop);
                    break;
                case (int)Constant.TimeTableIndex.MONDAY:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.MONDAY_CURSOR, Console.CursorTop);
                    break;
                case (int)Constant.TimeTableIndex.TUESDAY:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.TUESDAY_CURSOR, Console.CursorTop);
                    break;
                case (int)Constant.TimeTableIndex.WEDNESDAY:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.WEDNESDAY_CURSOR, Console.CursorTop);
                    break;
                case (int)Constant.TimeTableIndex.THURSDAY:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.THURSDAY_CURSOR, Console.CursorTop);
                    break;
                case (int)Constant.TimeTableIndex.FRIDAY:
                    Console.SetCursorPosition((int)Constant.TimeTableIndex.FRIDAY_CURSOR, Console.CursorTop);
                    break;
            }
            Console.Write(time);
        }
        private void ShowSelection(string insert)
        {
            Console.SetCursorPosition(Constant.SEARCH_LEFT, Console.CursorTop);
            Console.WriteLine(insert);
            Console.WriteLine();
        }
        public void SelectLectureForm()
        {
            ShowSelection("  개설학과전공");
            ShowSelection("  이수구분");
            ShowSelection("  교과목명");
            ShowSelection("  교수명");
            ShowSelection("  학년");
            ShowSelection("  조회");
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
            Console.Write("교수명 입력:(문자 2개이상)");
        }
        public void SelectClassNameForm()
        {
            Console.Write("교과목명 입력:(문자 2개이상)");
        }
        public void SelectDivisionForm()
        {
            Console.Write("학수번호 입력:(6자리 숫자)       분반 입력: (3자리 숫자)");
        }
        public void SelectCourseForm()
        {
            Console.Write("  전체         1학년            2학년              3학년             4학년");
        }
        public void SelectInterstForm()
        {
            ShowSelection("  개설학과전공");
            ShowSelection("  학수번호");
            ShowSelection("  교과목명");
            ShowSelection("  교수명");
            ShowSelection("  학년");
            ShowSelection("  조회");
        }
        public void SelectMore()
        {
            Console.Write("  계속 입력    재검색");
        }
        public void CheckGrades(int maximumGrades,int currentGrades,int cursor)
        {
            Console.SetCursorPosition(Constant.CAN_INSERT_CUSOR, cursor);
            Console.Write("신청가능 학점:{0}", maximumGrades - currentGrades);
            Console.SetCursorPosition(Constant.INSERT_CUSOR, Console.CursorTop);
            Console.Write("신청 학점:{0}", currentGrades);
            Console.SetCursorPosition(Constant.NUMBER_INSERT_CUSOR, Console.CursorTop);
            Console.Write("강의 NO:");
        }
        public void CheckLectureNumber(int maximumGrades, int currentGrades)
        {
            Console.SetCursorPosition(Constant.NUMBER_INSERT_CUSOR, Console.CursorTop);
            Console.Write("강의 NO:");
        }
        public void ShowReaminNumber(int maximumGrades, int currentGrades)
        {
            Console.SetCursorPosition(Constant.CAN_INSERT_CUSOR, Console.CursorTop);
            Console.Write("신청가능 학점:{0}", maximumGrades - currentGrades);
            Console.SetCursorPosition(Constant.INSERT_CUSOR, Console.CursorTop);
            Console.Write("신청 학점:{0}", currentGrades);
        }
        public void SearchGuide()
        {
            Console.SetCursorPosition(0, (int)Constant.MenuCursor.FIRST_MENU_CUSOR);
            Console.Write("          조회방법");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("방향키로 검색분야 및 내용이동");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("엔터키로 정보선택 OR 입력완료");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("원하는 정보 전부 선택 시 조회");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("       (뒤로가기 ESC)");
        }
        public void SelectGuide()
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("          신청방법");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("조회 결과 중 원하는 번호 입력");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("  계속입력 혹은 재검색 선택");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("(중복과목,중복시간 선택불가)");
        }
        public void DeleteGuide()
        {

        }
    }
}
