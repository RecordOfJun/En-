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
                basicView.Label();
                basicView.InterestForm();
                Console.CursorVisible = false;
                selected = input.SwicthMenu(Constant.INTEREST_MENU_COUNT);
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU://관심과목 담기
                        SearchLecture(interestLecture);
                        break;
                    case (int)Constant.Menu.SECOND_MENU://관심과목 조회
                        ShowInsertLectures(interestLecture,Constant.JUST_SEARCH_TYPE,"관심과목 조회");
                        break;
                    case (int)Constant.Menu.THIRD_MENU://관심과목 시간표
                        ShowTimeTable(interestLecture,"관심과목 시간표");
                        break;
                    case (int)Constant.Menu.FOURTH_MENU://관심과목 삭제
                        DeleteLectures(interestLecture, "삭제할 과목의 번호를 입력하세요");
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
        private void SearchInit()//ui 및 검색정보 초기화
        {
            Console.Clear();
            basicView.Label();
            lectureView.SelectInterstForm();
            lectureView.SearchGuide();
            lectureView.SelectGuide();
            storage.Init();
        }

        public void SearchLecture(LectureStorage extant)
        {
            SearchInit();//초기화
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                Console.CursorVisible = false;
                selected = SwicthRow();//행 이동
                switch (selected)
                {//정보 선택 및 입력
                    case (int)Constant.Menu.FIRST_MENU:
                        SelectMajor();//전공
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        SelectDivision();//학수번호
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        SelectLectureName();//과목명
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        SelectProfessor();//교수명
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        SelectCourse();//학년
                        break;
                    case (int)Constant.Menu.SIXTH_MENU:
                        ShowRemainLectures(extant);//조회
                        InsertInterest(extant);//추가
                        SearchInit();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }

        protected void SelectDivision()//학수번호 입력
        {
            //ui
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
                //학수번호 입력
                storage.LectureNumber = input.GetUserString(6, 2);//예외처리 숫자만 입력 2글자 이상 입력
                if (storage.LectureNumber == Constant.ESCAPE_STRING)//esc예외처리
                {
                    storage.LectureNumber = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    return;
                }
                isException =exception.IsLectureNumberForm(storage.LectureNumber);//예외처리
            }
            isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.DIVISION_SECOND_CUSOR, Console.CursorTop);
                //분반 입력
                storage.Division = input.GetUserString(3, 2);//예외처리 숫자만 입력 2글자 이상 입력
                if (storage.Division == Constant.ESCAPE_STRING)//esc예외처리
                {
                    storage.LectureNumber = Constant.EMPTY;
                    storage.Division = Constant.EMPTY;
                    basicView.DeleteString(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    return;
                }
                isException =exception.IsDivision(storage.Division);//예외처리
            }
            Console.CursorVisible = false;
        }

        protected void InsertInterest(LectureStorage extant)//관심과목 추가
        {
            string sequence;
            while (true)
            {
                //ui
                basicView.DeleteString(0, Console.CursorTop, Constant.DELETE_LONG);
                Console.CursorVisible = true;
                lectureView.CheckGrades(extant.MaximumGrades, extant.CurrentGrades,Constant.GRADES_CUSOR);
                Console.SetCursorPosition(Constant.LECTURENUMBER_INSERT_CUSOR, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
                //추가하고싶은 강의 번호 입력
                sequence =GetSequence(extant,searchTable);//각종 예외처리
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                AddInterest(sequence, extant,searchTable);//추가
                Console.SetCursorPosition(Constant.COLUMN_PRINT_CUSOR, Console.CursorTop);
                lectureView.SelectMore();
                int selected = SwitchColumn(2);//계속입력,재검색 선택
                if (selected == (int)Constant.Menu.SECOND_MENU || selected == Constant.ESCAPE_INT)
                    break;
            }
            storage.Init();
        }
        protected string GetSequence(LectureStorage extant,List<LectureVO> lectures)//강의 번호 입력받기
        {
            bool isException=true;
            string sequence="";
            while (isException)
            {
                isException = false;
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
                sequence = input.GetUserString(3, 2);
                if (sequence == Constant.ESCAPE_STRING)//esc감지
                    return Constant.ESCAPE_STRING;
                if (exception.IsNotNumberForm(sequence))//숫자인지 확인
                    isException = true;
                else if (!lectures.Exists(element => element.Sequence == sequence))//검색목록 혹은 관심과목에 있는지
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
                    else if (int.Parse(lecture.Grade) + extant.CurrentGrades > extant.MaximumGrades)//학점 초과시 예외처리
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
            exception.InsertSucess();

            return sequence;
        }
        protected void AddInterest(string sequence, LectureStorage extant,List<LectureVO> lectures)//강의 추가
        {
            LectureVO lecture = lectures.Find(element => element.Sequence == sequence);
            extant.storeList.Add(lecture);
            extant.CurrentGrades += int.Parse(lecture.Grade);//신청 학점 추가
        }
        private void ShowRemainLectures(LectureStorage extant)//신청 과목 제외하고 조회결과 출력
        {
            Console.SetCursorPosition(0, Constant.SHOW_LECTURE_CUSOR);
            searchTable.RemoveAll(element => true);//조회 결과를 담을 리스트 초기화
            foreach (LectureVO table in lectureTable)
            {
                //관심과목 or 신청과목에 포함되는 강의 미포함
                if (table.Sequence == "NO" || !extant.storeList.Exists(element=>element.Sequence==table.Sequence)&&(table.Division.Contains(storage.Division) && table.LectureNumber.Contains(storage.LectureNumber) && table.Major.Contains(storage.Major) && table.Professor.ToUpper().Contains(storage.Professor.ToUpper()) && table.LectureName.ToUpper().Contains(storage.LectureName.ToUpper()) && table.Course.Contains(storage.Course)))
                {
                    if (table.Sequence != "NO")
                        searchTable.Add(table);//조회한 결과 리스트에 추가
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
        protected void ShowInsertLectures(LectureStorage extant,int type,string insert)//신청한 강의내역 확인
        {
            Console.Clear();
            basicView.Label();
            basicView.ShowLabelAndLine(insert);
            for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
            {
                lectureView.ShowLecture(column, lectureTable[0]);//데이터 유형 출력
            }
            Console.WriteLine();
            foreach (LectureVO table in extant.storeList)
            {
                for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
                {
                    lectureView.ShowLecture(column, table);
                }
                Console.WriteLine();
            }
            Console.Write(new string('=', Console.WindowWidth));
            lectureView.ShowReaminNumber(extant.MaximumGrades, extant.CurrentGrades);
            if(type==Constant.JUST_SEARCH_TYPE)
                input.IsEscAndEnter();
        }
        protected void DeleteLectures(LectureStorage extant,string insert)//강의 삭제 메소드
        {
            Console.CursorVisible = true;
            string sequence;
            while (true)
            {
                ShowInsertLectures(extant,Constant.CONTROLL_SEARCH_TYPE,insert);
                lectureView.CheckLectureNumber(extant.MaximumGrades,extant.CurrentGrades);
                sequence = GetDeleteSequence(extant.storeList);//삭제할 강의 번호 입력
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                LectureVO toDelete = extant.storeList.Find(element => element.Sequence == sequence);
                extant.CurrentGrades -= int.Parse(toDelete.Grade);//신청학점 최신화
                extant.storeList.Remove(toDelete);//삭제
            }
            
        }
        protected string GetDeleteSequence(List<LectureVO> insertList)//삭제할 강의 번호 입력
        {
            bool isException = true;
            string sequence = Constant.EMPTY;
            while (isException)
            {
                Console.SetCursorPosition(Constant.LECTURENUMBER_INSERT_CUSOR, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 10);
                sequence = input.GetUserString(3, Constant.NOT_PASSWORD_TYPE);
                if (sequence == Constant.ESCAPE_STRING)//esc확인
                    return Constant.ESCAPE_STRING;
                if (exception.IsNotNumberForm(sequence))//숫자 확인
                    isException = true;
                else if (!insertList.Exists(element => element.Sequence == sequence))//관심목록 혹은 수강신청 목록에 있는지 확인
                {
                    exception.NotExistException();
                    isException = true;
                }
                else if (insertList.Exists(element => element.Sequence == sequence))
                    break;
            }
            exception.DeleteSucess();
            return sequence;
        }

        public bool ShowTimeTable(LectureStorage extant,string insert)//시간표 출력 메소드
        {
            extant.Init();
            extant.InsertTime();
            Console.Clear();
            basicView.Label();
            basicView.ShowLabelAndLine(insert);
            string[] days = { "", "", "", "월", "화", "수", "목", "금" };
            for (int column = 0; column < 8; column++)
            {
                lectureView.ShowTable(column, days[column]);//첫번째 줄 출력(날짜)
            }
            Console.WriteLine();
            for (int row = Constant.MINIMUM_ROW; row < Constant.MAXIMUM_ROW; row++)
            {
                for(int column = Constant.MINIMUM_COLUMN; column < Constant.MAXIMUM_COLUMN; column++)
                {
                    lectureView.ShowTable(column, extant.timeTable[column,row]);//이후 데이터 출력
                }
                Console.WriteLine();
            }
            return input.IsEscAndEnter();
        }
    }
}
