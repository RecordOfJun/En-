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
        public Excel.Sheets sheets;
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
        public Login()//로그인과 엑셀데이터를 리스트에 연동해주는 클래스
        {
            Console.SetWindowSize(178,30);
            instances = new Instances();
            this.basicView = new BasicView();
            this.exceptionView = new ExceptionView();
            this.input = new Input(basicView);
            this.lectureTable = new List<LectureVO>();
            this.exception = new Exception(exceptionView,basicView);
            application = new Excel.Application();
            workbook = application.Workbooks.Open(Environment.CurrentDirectory + "\\2022년도 1학기 강의시간표.xlsx");
            sheets = workbook.Sheets;
            instances.exception = this.exception;
            instances.basicView = this.basicView;
            instances.exceptionView = this.exceptionView;
            instances.input = this.input;
            instances.lectureTable = this.lectureTable;
            instances.sheets = sheets;
            this.mainMenu = new MainMenu(instances);
        }


        private void LinkExcelData()//엑셀 데이터 연동 메소드
        {
            //엑셀 데이터 불러오기
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
                    {//엑섹의 컬럼별로 강의 객체 속 각기 다른 변수에 값을 넣어줌
                        case (int)Constant.SECTOR.SEQUENCE://순서
                            lectureVO.Sequence = content;
                            break;
                        case (int)Constant.SECTOR.MAJOR://전공
                            lectureVO.Major = content;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NUMBER://학수번호
                            lectureVO.LectureNumber = content;
                            break;
                        case (int)Constant.SECTOR.DIVISION://분반
                            lectureVO.Division = content;
                            break;
                        case (int)Constant.SECTOR.LECTURE_NAME://강의명
                            lectureVO.LectureName = content;
                            break;
                        case (int)Constant.SECTOR.DISTRIBUTION://이수구분
                            lectureVO.Distribution = content;
                            break;
                        case (int)Constant.SECTOR.COURSE://학년
                            lectureVO.Course = content;
                            break;
                        case (int)Constant.SECTOR.GRADE://학점
                            lectureVO.Grade = content;
                            break;
                        case (int)Constant.SECTOR.DAY_AND_TIME://시간
                            lectureVO.Time = content;
                            break;
                        case (int)Constant.SECTOR.PLACE://장소
                            lectureVO.Place = content;
                            break;
                        case (int)Constant.SECTOR.PROFESSOR://교수명
                            lectureVO.Professor = content;
                            break;
                        case (int)Constant.SECTOR.LANGUAGE://언어
                            lectureVO.Language = content;
                            break;
                    }                   
                }
                this.lectureTable.Add(lectureVO);//정보가 다 들어간 객체 리스트에 추가
            }
        }

        public void GetInProgram()//프로그램 시작
        {
            LinkExcelData();//엑셀 데이터 불러오기
            bool isNotExited = true;
            while (isNotExited)
                CheckId();//아이디 비번 체크
        }


        private void CheckId()//아이디와 비밀번호를 체크해주는 메소드
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
                //기존에 입력한 아이디 비밀번호와 예외 구문 지워주기
                basicView.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX, Constant.ID_DELETE);
                basicView.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX, Constant.ID_DELETE);
                basicView.DeleteString(Constant.MIDDLE_CUSOR, Constant.LOGIN_ID_INDEX + 2, Constant.RETRY_DELETE);
                basicView.DeleteString(Constant.MIDDLE_CUSOR, Constant.LOGIN_ID_INDEX + 3, Constant.RETRY_DELETE);
                isNotCorrect = IsCorrectUser();//아이디 비번 입력 메소드
                if (isEscape == true)
                    return;
                if (isNotCorrect == false)//로그인 성공 시 반복문 빠져나오기
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
            while (isNotEnter)
            {
                //이전 커서 위치 지워주기
                basicView.DeleteString(Constant.MIDDLE_CUSOR,Console.CursorTop, Constant.CUSOR_DELETE);
                basicView.DeleteString(Constant.EXIT_CUSOR, Console.CursorTop, Constant.CUSOR_DELETE);
                switch (index)//좌우 방향키에 따라 인덱스 변화 &커서위치 최신화
                {
                    case Constant.RETRY:
                        Console.SetCursorPosition(Constant.MIDDLE_CUSOR, Console.CursorTop);
                        break;
                    case Constant.EXIT:
                        Console.SetCursorPosition(Constant.EXIT_CUSOR, Console.CursorTop);
                        break;
                }
                Console.Write(">");
                index = input.GetLeftRight(index,2);//좌우 입력받기
                if (index == Constant.RETURN)
                    return selected;//엔터 입력 시 선택한 항목 리턴
                selected = index;
            }
            return selected;
        }
    }
}
