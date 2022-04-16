using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
using Excel = Microsoft.Office.Interop.Excel;
namespace LTT.Controller
{
    class Instances
    {
        public BasicView basicView;
        public ExceptionView exceptionView;
        public LectureView lectureView;
        public Input input;
        public List<LectureVO> lectureTable;
        public LectureStorage InterestLecture;
        public LectureStorage myLecture;
        public Exception exception;
    }
    class Login
    {
        Instances instances;
        BasicView basicView;
        ExceptionView exceptionView;
        Input input;
        Exception exception;
        MainMenu mainMenu;
        Excel.Application application;
        Excel.Workbook workbook;
        Excel.Sheets sheets;
        Excel.Worksheet worksheet;
        Excel.Range cellRange;
        Array data;
        List<LectureVO> lectureTable;
        bool isEscape;
        public Login()
        {
            Console.SetWindowSize(178,30);
            instances = new Instances();
            this.basicView = new BasicView();
            this.exceptionView = new ExceptionView();
            this.input = new Input(basicView);
            this.lectureTable = new List<LectureVO>();
            this.exception = new Exception(exceptionView,basicView);
            instances.exception = this.exception;
            instances.basicView = this.basicView;
            instances.exceptionView = this.exceptionView;
            instances.input = this.input;
            instances.lectureTable = this.lectureTable;
            this.mainMenu = new MainMenu(instances);
        }


        private void LinkExcelData()//엑셀 데이터 연동 메소드
        {
            application = new Excel.Application();
            workbook = application.Workbooks.Open(Environment.CurrentDirectory + "\\2022년도 1학기 강의시간표.xlsx");
            sheets = workbook.Sheets;
            worksheet = sheets["전체강의"] as Excel.Worksheet;
            cellRange = worksheet.get_Range("A1", "L185") as Excel.Range;
            data = (Array)cellRange.Cells.Value2;
            object value;
            string content;
            for (int row = Constant.EXCEL_MINIMUM_ROW; row <= Constant.EXCEL_MAXIMUM_ROW; row++)
            {
                LectureVO lectureVO = new LectureVO();
                for (int column = Constant.EXCEL_MINIMUM_COLUMN; column <= Constant.EXCEL_MAXIMUM_COLUMN; column++)
                {
                    value = data.GetValue(row, column);
                    if (value == null)
                        content = Constant.EMPTY ;
                    else
                        content = value.ToString().Trim();
                    switch (column)
                    {
                        case (int)Constant.SECTOR.SEQUENCE:
                            lectureVO.Sequence = content;
                            break;
                        case (int)Constant.SECTOR.MAJOR:
                            lectureVO.Major = content;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NUMBER:
                            lectureVO.LectureNumber = content;
                            break;
                        case (int)Constant.SECTOR.DIVISION:
                            lectureVO.Division = content;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NAME:
                            lectureVO.LectureName = content;
                            break;
                        case (int)Constant.SECTOR.DISTRIBUTION:
                            lectureVO.Distribution = content;
                            break;
                        case (int)Constant.SECTOR.COURSE:
                            lectureVO.Course = content;
                            break;
                        case (int)Constant.SECTOR.GRADE:
                            lectureVO.Grade = content;
                            break;
                        case (int)Constant.SECTOR.DAY_AND_TIME:
                            lectureVO.Time = content;
                            break;
                        case (int)Constant.SECTOR.PLACE:
                            lectureVO.Place = content;
                            break;
                        case (int)Constant.SECTOR.PROFESSOR:
                            lectureVO.Professor = content;
                            break;
                        case (int)Constant.SECTOR.LANGUAGE:
                            lectureVO.Language = content;
                            break;
                    }                   
                }
                this.lectureTable.Add(lectureVO);
            }
        }
        public void GetInProgram()//프로그램 시작
        {
            LinkExcelData();//엑셀 데이터 불러오기
            bool isNotExited = true;
            while (isNotExited)
                CheckId();//아이디 비번 체크
        }


        private void CheckId()
        {
            isEscape = false;
            bool isNotCorrect= Constant.IS_NOT_CORRECT;
            //ui출력
            Console.Clear();
            basicView.Label();
            basicView.LoginGuide();
            Console.SetCursorPosition(Constant.MIDDLE_CUSOR, Constant.LOGIN_ID_INDEX);
            basicView.LoginView();
            while (isNotCorrect)
            {
                Console.CursorVisible = true;
                basicView.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX, Constant.ID_DELETE);
                basicView.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX, Constant.ID_DELETE);
                basicView.DeleteString(Constant.MIDDLE_CUSOR, Constant.LOGIN_ID_INDEX + 2, Constant.RETRY_DELETE);
                basicView.DeleteString(Constant.MIDDLE_CUSOR, Constant.LOGIN_ID_INDEX + 3, Constant.RETRY_DELETE);
                isNotCorrect = IsCorrectUser();//아이디 비번 입력 메소드
                if (isEscape == true)
                    return;
                if (isNotCorrect == false)
                    break;
                exceptionView.NotCorrecId("잘못된 로그인 정보입니다!");
                if (AskAgain() == Constant.EXIT_PROGRAM)//다시로그인 or 프로그램 종료
                    exception.ExitProgramm();//종료확인
            }
            mainMenu.SelectMenu();//로그인 성공 시 메인 메뉴 이동
        }


        private bool IsCorrectUser()
        {
            string id=Constant.EMPTY;
            string password;
            bool isNotId = true;
            while (isNotId)
            {
                Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX);
                basicView.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX, Constant.ID_DELETE);
                id = input.GetUserString(8, Constant.NOMARL_INPUT);//정해진 수 미만으로 입력받는 메소드 호출
                if (id == Constant.ESCAPE_STRING)
                {//esc예외처리
                    isEscape = true;
                    return isEscape; ;
                }
                if (exception.IsIDForm(id))//아이디 양식 예외처리
                    isNotId = false;
            }
            Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX);
            password = input.GetUserString(8, Constant.HIDE_INPUT);
            if (password == Constant.ESCAPE_STRING)
            {//esc예외처리
                isEscape = true;
                return isEscape; ;
            }
            if (id == Constant.ID && password == Constant.PASSWORD)//아이디 비번 일치 확인
                return Constant.IS_CORRECT;
            return Constant.IS_NOT_CORRECT;
        }


        private int AskAgain()//다시 로그인, 종료 질문
        {
            Console.CursorVisible = false;
            int index = 0;
            int selected = 0;
            bool isNotEnter = true;
            basicView.ShowAgain();
            while (isNotEnter)//커서 이동
            {
                basicView.DeleteString(Constant.MIDDLE_CUSOR,Console.CursorTop, Constant.CUSOR_DELETE);
                basicView.DeleteString(Constant.EXIT_CUSOR, Console.CursorTop, Constant.CUSOR_DELETE);
                switch (index)
                {
                    case Constant.RETRY:
                        Console.SetCursorPosition(Constant.MIDDLE_CUSOR, Console.CursorTop);
                        break;
                    case Constant.EXIT:
                        Console.SetCursorPosition(Constant.EXIT_CUSOR, Console.CursorTop);
                        break;
                }
                Console.Write(">");
                index = input.GetLeftRight(index,2);
                if (index == Constant.RETURN)
                    return selected;
                selected = index;
            }
            return selected;
        }
    }
}
