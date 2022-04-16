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
        protected LectureStorage interestLecture;
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
                basicView.Label("관심과목 메뉴");
                basicView.InterestForm();
                selected = input.SwicthMenu(Constant.INTEREST_MENU_COUNT);
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU://관심과목 담기
                        SearchLecture(interestLecture,"관심과목 담기");
                        break;
                    case (int)Constant.Menu.SECOND_MENU://관심과목 조회
                        ShowInsertLectures(interestLecture.storeList, Constant.JUST_SEARCH_TYPE,"관심과목 조회");
                        break;
                    case (int)Constant.Menu.THIRD_MENU://관심과목 시간표
                        ShowTimeTable(interestLecture,"관심과목 시간표");
                        break;
                    case (int)Constant.Menu.FOURTH_MENU://관심과목 삭제
                        DeleteLectures(interestLecture, "관심과목 삭제");
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        exception.ExitProgramm();
                        break;
                    case Constant.ESCAPE_INT:
                        Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐
                        basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 1);
                        isNotEscape = false;
                        break;
                }
            }
        }
        private void SearchInit(string insert)
        {
            Console.Clear();
            basicView.Label(insert);
            lectureView.SelectInterstForm();
            storage.Init();
        }

        public void SearchLecture(LectureStorage extant,string insert)
        {
            SearchInit(insert);
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                Console.CursorVisible = false;
                selected = SwicthRow();
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        SelectMajor();
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        SelectDivision();
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        SelectLectureName();
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        SelectProfessor();
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        SelectCourse();
                        break;
                    case (int)Constant.Menu.SIXTH_MENU:
                        ShowRemainLectures(extant);
                        InsertInterest(extant);
                        SearchInit(insert);
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }

        protected void SelectDivision()
        {
            Console.CursorVisible = true;
            storage.LectureNumber = Constant.EMPTY;
            storage.Division = Constant.EMPTY;
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            lectureView.SelectDivisionForm();
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.DIVISION_FIRST_CUSOR, Console.CursorTop);
                storage.LectureNumber = input.GetUserString(6, 2);//예외처리 숫자만 입력 2글자 이상 입력
                if (storage.LectureNumber == Constant.ESCAPE_STRING)
                {
                    storage.LectureNumber = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    return;
                }
                isException =exception.IsLectureNumberForm(storage.LectureNumber);
            }
            isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.DIVISION_SECOND_CUSOR, Console.CursorTop);
                storage.Division = input.GetUserString(3, 2);//예외처리 숫자만 입력 2글자 이상 입력
                if (storage.Division == Constant.ESCAPE_STRING)
                {
                    storage.LectureNumber = Constant.EMPTY;
                    storage.Division = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    return;
                }
                isException =exception.IsDivision(storage.Division);
            }
            Console.CursorVisible = false;
        }

        protected void InsertInterest(LectureStorage extant)
        {
            string sequence;
            while (true)
            {
                basicView.DeleteString(0, Console.CursorTop, 150);
                Console.CursorVisible = true;
                lectureView.CheckGrades(extant.MaximumGrades, extant.CurrentGrades,Constant.GRADES_CUSOR);
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
                sequence =GetSequence(extant,searchTable);//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                AddInterest(sequence, extant,searchTable);
                Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
                lectureView.SelectMore();
                int selected = SwitchColumn(2);
                if (selected == 1 || selected == Constant.ESCAPE_INT)
                    break;
            }
            storage.Init();
        }
        protected string GetSequence(LectureStorage extant,List<LectureVO> lectures)//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
        {
            bool isException=true;
            string sequence="";
            while (isException)
            {
                isException = false;
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
                sequence = input.GetUserString(3, 2);
                if (sequence == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_STRING;
                if (exception.IsNotNumberForm(sequence))
                    isException = true;
                else if (!lectures.Exists(element => element.Sequence == sequence))//검색목록 혹은 관심과목에 없으면
                {
                    exception.NotExistException();
                    isException = true;
                }
                
                else
                {
                    LectureVO lecture=lectures.Find(element => element.Sequence == sequence);
                    string compare = lecture.LectureNumber;
                    if (extant.storeList.Exists(element => element.LectureNumber == compare))//과목명 즉 학수번호 일치하는 과목 안받기
                    {
                        exception.OverlapException();
                        isException = true;
                    }
                    else if (int.Parse(lecture.Grade) + extant.CurrentGrades > extant.MaximumGrades)//학점 초과시
                    {
                        exception.OverGrades();
                        isException = true;
                    }
                    //시간표 겹침 예외처리
                    else//깊이가 깊다고 들을 것 같다
                    {
                        foreach (TimeTable timeTable in lecture.timeTables)
                        {
                            foreach (LectureVO extantLecture in extant.storeList)
                            {
                                foreach (TimeTable extantTable in extantLecture.timeTables)
                                {
                                    if (timeTable.day == extantTable.day && timeTable.startTime < extantTable.finishTime && extantTable.startTime < timeTable.finishTime)
                                    {
                                        isException = true;
                                        exception.TimeOverlapException();
                                        break;
                                    }
                                }
                            }
                            if (isException == true)
                                break;
                        }
                    }


                }
            }
            return sequence;
        }
        protected void AddInterest(string sequence, LectureStorage extant,List<LectureVO> lectures)
        {
            LectureVO lecture = lectures.Find(element => element.Sequence == sequence);
            extant.storeList.Add(lecture);
            extant.CurrentGrades += int.Parse(lecture.Grade);
        }
        private void ShowRemainLectures(LectureStorage extant)
        {
            Console.SetCursorPosition(0, Constant.SHOW_LECTURE_CUSOR);
            searchTable.RemoveAll(element => true);
            foreach (LectureVO table in lectureTable)
            {
                if (table.Sequence == "NO" || !extant.storeList.Exists(element=>element.Sequence==table.Sequence)&&(table.Division.Contains(storage.Division) && table.LectureNumber.Contains(storage.LectureNumber) && table.Major.Contains(storage.Major) && table.Professor.ToUpper().Contains(storage.Professor.ToUpper()) && table.LectureName.ToUpper().Contains(storage.LectureName.ToUpper()) && table.Course.Contains(storage.Course)))
                {
                    if (table.Sequence != "NO")
                        searchTable.Add(table);
                    for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
                    {
                        lectureView.ShowLecture(column, table);
                    }
                    if (table.Sequence == "NO")
                    {
                        Console.WriteLine();
                        Console.Write(new string('=', Console.WindowWidth));
                    }
                    else
                        Console.WriteLine();
                }
            }
        }
        protected void ShowInsertLectures(List<LectureVO> insertList,int type,string insert)
        {
            Console.Clear();
            basicView.ShowLabelAndLine(insert);
            for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
            {
                lectureView.ShowLecture(column, lectureTable[0]);
            }
            Console.WriteLine();
            foreach (LectureVO table in insertList)
            {
                for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
                {
                    lectureView.ShowLecture(column, table);
                }
                Console.WriteLine();
            }
            Console.Write(new string('=', Console.WindowWidth));
            if (type == Constant.JUST_SEARCH_TYPE)//단순조회
            {
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
        protected void DeleteLectures(LectureStorage extant,string insert)
        {
            string sequence;
            while (true)
            {
                ShowInsertLectures(extant.storeList, Constant.CONTROLL_SEARCH_TYPE,insert);
                lectureView.CheckLectureNumber(extant.MaximumGrades,extant.CurrentGrades);
                sequence = GetDeleteSequence(extant.storeList);
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                LectureVO toDelete = extant.storeList.Find(element => element.Sequence == sequence);
                extant.CurrentGrades -= int.Parse(toDelete.Grade);
                extant.storeList.Remove(toDelete);
            }
            
        }
        protected string GetDeleteSequence(List<LectureVO> insertList)//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
        {
            bool isException = true;
            string sequence = "";
            while (isException)
            {
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 10);
                sequence = input.GetUserString(3, 2);
                if (sequence == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_STRING;
                if (exception.IsNotNumberForm(sequence))
                    isException = true;
                else if (!insertList.Exists(element => element.Sequence == sequence))//검색목록 혹은 관심과목에 없으면
                {
                    exception.NotExistException();
                    isException = true;
                }
                else if (insertList.Exists(element => element.Sequence == sequence))
                    break;
            }
            return sequence;
        }

        protected void ShowTimeTable(LectureStorage extant,string insert)
        {
            extant.Init();
            extant.InsetTime();
            Console.Clear();
            basicView.ShowLabelAndLine(insert);
            string[] days = { "", "", "", "월", "화", "수", "목", "금" };
            for (int column = 0; column < 8; column++)
            {
                lectureView.ShowTable(column, days[column]);
            }
            Console.WriteLine();
            for (int row = 0; row < 48; row++)
            {
                for(int column = 0; column < 8; column++)
                {
                    lectureView.ShowTable(column, extant.timeTable[column,row]);
                }
                Console.WriteLine();
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
