using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using LTT.View;
using LTT.Model;
namespace LTT.Controller
{
    class MainMenu
    {
        BasicView basicView;
        Input input;
        WholeLecture wholeLecture;
        InterestSelection interestSelection;
        LectureSelection lectureSelection;
        Exception exception;
        Excel.Sheets sheets;
        LectureStorage myLecture;
        public MainMenu(Instances instances)//메인메뉴를 보여주고 선택을 받아주는 클래스
        {
            this.basicView = instances.basicView;
            this.input = instances.input;
            this.exception = instances.exception;
            this.sheets = instances.sheets;
            instances.lectureView = new LectureView();
            instances.myLecture = new LectureStorage(Constant.MY_MAX);
            this.myLecture = instances.myLecture;
            instances.InterestLecture = new LectureStorage(Constant.INTEREST_MAX);
            wholeLecture = new WholeLecture(instances) ;
            interestSelection = new InterestSelection(instances);
            lectureSelection = new LectureSelection(instances);
        }
        public void SelectMenu()//메인메뉴 출력 및 선택
        {
            Console.CursorVisible = false;
            int selected;
            bool isNotEscape = true;
            while (isNotEscape) {
                Console.Clear();
                basicView.Label();
                basicView.MainMenuForm();
                selected = input.SwicthMenu(Constant.MAIN_MENU_COUNT);//위아래 커서이동 함수 호출
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        wholeLecture.SearchLecture();//전체 시간표 조회
                        break;
                    case (int)Constant.Menu.SECOND_MENU://관심과목 메뉴 이동
                        interestSelection.SelectMenu();
                        break;
                    case (int)Constant.Menu.THIRD_MENU://수강신청 메뉴 이동
                        lectureSelection.SelectMenu();
                        break;
                    case (int)Constant.Menu.FOURTH_MENU://
                        if(interestSelection.ShowTimeTable(myLecture, "엔터 입력 시 엑셀을 저장합니다."))
                            UpdateExcel();
                        break;
                    case (int)Constant.Menu.FIFTH_MENU://프로그램 종료
                        exception.ExitProgramm();
                        break;
                    case Constant.ESCAPE_INT:
                        Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐 방지
                        basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.CUSOR_DELETE);
                        isNotEscape = false;
                        break;
                }
            }
        }

        private void UpdateExcel()//엑셀 저장 함수
        {
            basicView.ExcelLoading();//로딩중이라는 표시 보여줌=> 엑셀에 데이터가 다 들어가면 자동으로 화면 내려감
            Excel.Worksheet worksheet = sheets["시간표"] as Excel.Worksheet;
            //신청과목 인덱스 범위 가져와 초기화
            Excel.Range cellRanges = worksheet.get_Range("A2", "L12") as Excel.Range;
            cellRanges.Cells.Value2 = "";
            //시간표 인덱스 범위 가져와 초기화
            cellRanges = worksheet.get_Range("B14", "F61") as Excel.Range;
            cellRanges.Cells.Value2 = "";
            InsertLecture(worksheet);//신청과목 엑셀에 넣어주는 메소드
            InsertTime(worksheet);//시간표 엑셀에 넣어주는 메소드
        }
        private void InsertLecture(Excel.Worksheet worksheet) {
            
            int row = Constant.EXCEL_MINIMUM_ROW+1;
            Excel.Range range;
            foreach (LectureVO lecture in myLecture.storeList)//신청한 리스트들을 가져온다
            {
                for (int column = Constant.EXCEL_MINIMUM_COLUMN; column <= Constant.EXCEL_MAXIMUM_COLUMN; column++)
                {
                    range = worksheet.Cells[row, column];//몇번째 열인지에 따라서 엑셀의 인덱스를 지정해준다
                    switch (column)//인덱스별로 정보 다르게 저장
                    {
                        case (int)Constant.SECTOR.SEQUENCE://순서
                           range.Value2 = lecture.Sequence;
                            break;
                        case (int)Constant.SECTOR.MAJOR://전공
                            range.Value2 = lecture.Major;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NUMBER://학수번호
                            range.Value2 = lecture.LectureNumber;
                            break;
                        case (int)Constant.SECTOR.DIVISION://분반
                            range.Value2 = lecture.Division;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NAME://과목명
                            range.Value2 = lecture.LectureName;
                            break;
                        case (int)Constant.SECTOR.DISTRIBUTION://이수구분
                            range.Value2 = lecture.Distribution;
                            break;
                        case (int)Constant.SECTOR.COURSE://학년
                            range.Value2 = lecture.Course;
                            break;
                        case (int)Constant.SECTOR.GRADE://학점
                            range.Value2 = lecture.Grade;
                            break;
                        case (int)Constant.SECTOR.DAY_AND_TIME://시간
                            range.Value2 = lecture.Time;
                            break;
                        case (int)Constant.SECTOR.PLACE://장소
                            range.Value2 = lecture.Place;
                            break;
                        case (int)Constant.SECTOR.PROFESSOR://교수명
                            range.Value2 = lecture.Professor;
                            break;
                        case (int)Constant.SECTOR.LANGUAGE://언어
                            range.Value2 = lecture.Language;
                            break;
                    }
                   
                }
                row++;//다음 행으로 이동
            }
        }

        private void InsertTime(Excel.Worksheet worksheet)//시간표 저장 메소드
        {
            string time;
            Excel.Range range;
            for (int row = Constant.MINIMUM_ROW; row < Constant.MAXIMUM_ROW; row++)
            {
                time = Constant.EMPTY;
                for (int column = Constant.MINIMUM_COLUMN; column < Constant.MAXIMUM_COLUMN; column++)
                {
                    if (column < (int)Constant.TimeTableIndex.MONDAY)
                    {
                        time+= myLecture.timeTable[column, row];//배열에서 시간을 저장한 스트링 더해주기 EX)"04:00"+"~"+"04:30"
                        if (column == (int)Constant.TimeTableIndex.FINISH_TIME)
                        {
                            range = worksheet.Cells[row + Constant.EXCEL_TIME_INDEX, column - 1];
                            range.Value2= time;
                            //더해진 스트링값 엑셀의 시간 인덱스에 넣어주기 EX)"04:00~04:30"
                        }
                    }
                    else
                    {
                        range = worksheet.Cells[row + Constant.EXCEL_TIME_INDEX, column - 1];
                        range.Value2 = myLecture.timeTable[column, row];
                        //날짜와 시간별 과목과 강의실 정보 넣어주기
                    }
                }
            }
        }
    }
}
