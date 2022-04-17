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
        public WholeLecture(Instances instances)//전체 조회 클래스
        {
            storage = new LectureVO();
            searchTable = new List<LectureVO>();
            this.lectureTable = instances.lectureTable;
            this.lectureView = instances.lectureView;
            this.basicView = instances.basicView;
            input = new Input(basicView);
            this.exception = instances.exception;
        }
        private void SearchInit()//ui,검색정보 초기화 메소드
        {
            Console.Clear();
            basicView.Label();
            lectureView.SelectLectureForm();
            lectureView.SearchGuide();
            storage.Init();
        }
        public void SearchLecture()//정보 검색 메소드
        {
            SearchInit();
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                selected = SwicthRow();//검색 정보 행 이동 메소드
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        SelectMajor();//전공 선택
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        SelectDistribution();//이수구분 선택
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        SelectLectureName();//과목명 선택
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        SelectProfessor();//교수명 선택
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        SelectCourse();//학년 선택
                        break;
                    case (int)Constant.Menu.SIXTH_MENU:
                        ShowAllLectures();//조회
                        SearchInit();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }
        protected int SwicthRow()//검생 정보 행(세로) 이동 함수
        {
            int index = 0;
            int selected = 0;
            bool isNotEnter = true;
            while (isNotEnter)
            {
                //기존 커서 삭제
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FIRST_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.SECOND_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.THIRD_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FOURTH_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.FIFTH_MENU_CUSOR, 1);
                basicView.DeleteString(Constant.SEARCH_LEFT, (int)Constant.MenuCursor.SIXTH_MENU_CUSOR, 1);
                switch (index)//
                {//커서 위치 최신화
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
                index = input.GetUpDown(index, 6);//위 아래 입력 감지
                if (index == Constant.RETURN)
                    return selected;
                if (index == Constant.ESCAPE_INT)
                    return Constant.ESCAPE_INT;
                selected = index;
            }
            return selected;
        }
        protected int SwitchColumn(int NumberOfChoice)//검색 정보 열(가로) 이동
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
            //ui
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectMajorForm();
            int selected=SwitchColumn(5);//열 이동
            switch (selected)
            {//전공 선택 정보 저장
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
            //ui
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectDistributionForm();
            int selected = SwitchColumn(4);//열 이동
            switch (selected)
            {//선택 정보 저장
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
        protected void SelectProfessor()//교수명 입력
        {
            //ui
            Console.CursorVisible = true;
            storage.Professor = Constant.EMPTY;
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectProfessorForm();
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.PROFESSOR_CUSOR, Console.CursorTop);
                //교수명 입력
                storage.Professor = input.GetUserString(Constant.STRING_INPUT_LENGTH, Constant.NOT_PASSWORD_TYPE);
                if (storage.Professor == Constant.ESCAPE_STRING)//esc감지
                {
                    storage.Professor = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
                }
                isException = exception.IsProfessorAndLectureNameCheck(storage.Professor);//교수명 예외처리
            }
            Console.CursorVisible = false;
        }
        protected void SelectLectureName()//과목명 입력
        {
            //ui
            Console.CursorVisible = true;
            storage.LectureName = Constant.EMPTY;
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectClassNameForm();
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.LECTURENAME_CUSOR, Console.CursorTop);
                //과목명 입력
                storage.LectureName = input.GetUserString(Constant.STRING_INPUT_LENGTH, Constant.NOT_PASSWORD_TYPE);
                if (storage.LectureName == Constant.ESCAPE_STRING)
                {
                    storage.LectureName = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
                }
                isException = exception.IsProfessorAndLectureNameCheck(storage.LectureName);//과목명 예외처리
            }
            Console.CursorVisible = false;
        }
        protected void SelectCourse()//학년 선택
        {
            //ui
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectCourseForm();
            int selected = SwitchColumn(5);//열 이동
            switch (selected)
            {//선택정보 저장
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
                case (int)Constant.Menu.FIFTH_MENU:
                    storage.Course = "4";
                    break;
                case Constant.ESCAPE_INT://esc감지
                    storage.Course = "";
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
            }
        }
        private void ShowAllLectures()//선택정보 기반 데이터 출력
        {
            Console.SetCursorPosition(Constant.INDEX_MINIMUM, Constant.SHOW_LECTURE_CUSOR); //출력 위치 조정
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
            while (isNotESC)//esc입력으로 빠져나오기
            {
                Console.SetCursorPosition(Constant.MIDDLE_CUSOR, Console.CursorTop);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter)
                    break;
                basicView.DeleteString(Console.CursorLeft - 1, Console.CursorTop, 2);
            }
        }
    }
}
