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
        public MainMenu(Instances instances)
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
        public void SelectMenu()
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

        private void UpdateExcel()
        {
            basicView.ExcelLoading();
            Excel.Worksheet worksheet = sheets["시간표"] as Excel.Worksheet;
            Excel.Range cellRanges = worksheet.get_Range("A2", "L12") as Excel.Range;
            cellRanges.Cells.Value2 = "";
            cellRanges = worksheet.get_Range("B14", "F61") as Excel.Range;
            cellRanges.Cells.Value2 = "";
            InsertLecture(worksheet);
            InsertTime(worksheet);
        }
        private void InsertLecture(Excel.Worksheet worksheet) {
            int row = Constant.EXCEL_MINIMUM_ROW+1;
            Excel.Range range;
            foreach (LectureVO lecture in myLecture.storeList)
            {
                for (int column = Constant.EXCEL_MINIMUM_COLUMN; column <= Constant.EXCEL_MAXIMUM_COLUMN; column++)
                {
                    range = worksheet.Cells[row, column];
                    switch (column)
                    {
                        case (int)Constant.SECTOR.SEQUENCE:
                            range.Value2 = lecture.Sequence;
                            break;
                        case (int)Constant.SECTOR.MAJOR:
                            range.Value2 = lecture.Major;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NUMBER:
                            range.Value2 = lecture.LectureNumber;
                            break;
                        case (int)Constant.SECTOR.DIVISION:
                            range.Value2 = lecture.Division;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NAME:
                            range.Value2 = lecture.LectureName;
                            break;
                        case (int)Constant.SECTOR.DISTRIBUTION:
                            range.Value2 = lecture.Distribution;
                            break;
                        case (int)Constant.SECTOR.COURSE:
                            range.Value2 = lecture.Course;
                            break;
                        case (int)Constant.SECTOR.GRADE:
                            range.Value2 = lecture.Grade;
                            break;
                        case (int)Constant.SECTOR.DAY_AND_TIME:
                            range.Value2 = lecture.Time;
                            break;
                        case (int)Constant.SECTOR.PLACE:
                            range.Value2 = lecture.Place;
                            break;
                        case (int)Constant.SECTOR.PROFESSOR:
                            range.Value2 = lecture.Professor;
                            break;
                        case (int)Constant.SECTOR.LANGUAGE:
                            range.Value2 = lecture.Language;
                            break;
                    }
                }
                row++;
            }
        }

        private void InsertTime(Excel.Worksheet worksheet)
        {
            string time;
            Excel.Range range;
            for (int row = Constant.MINIMUM_ROW; row < Constant.MAXIMUM_ROW; row++)
            {
                time = Constant.EMPTY;
                for (int column = Constant.MINIMUM_COLUMN; column < Constant.MAXIMUM_COLUMN; column++)
                {
                    if (column < 3)
                    {

                        time+= myLecture.timeTable[column, row];
                        if (column == 2)
                        {
                            range = worksheet.Cells[row + 14, 1];
                            range.Value2 = time;
                        }
                    }
                    else
                    {
                        range = worksheet.Cells[row + 14, column - 1];
                        range.Value2= myLecture.timeTable[column, row];
                    }
                }
            }
        }
    }
}
