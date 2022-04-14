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
        public MainMenu mainMenu;
        public List<LectureVO> lectureTable;
    }
    class Login
    {
        Instances instances;
        BasicView basicView;
        ExceptionView exceptionView;
        Input input;
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
            instances.basicView = this.basicView;
            instances.exceptionView = this.exceptionView;
            instances.input = this.input;
            instances.lectureTable = this.lectureTable;
            this.mainMenu = new MainMenu(instances);
        }
        private void LinkExcelData()
        {
            application = new Excel.Application();
            workbook = application.Workbooks.Open(Environment.CurrentDirectory + "\\2022년도 1학기 강의시간표.xlsx");
            sheets = workbook.Sheets;
            worksheet = sheets["전체강의"] as Excel.Worksheet;
            cellRange = worksheet.get_Range("A1", "L185") as Excel.Range;
            data = (Array)cellRange.Cells.Value2;
            object value;
            string content;
            for (int row = 1; row <= 185; row++)
            {
                LectureVO lectureVO = new LectureVO();
                for (int column = 1; column <= 12; column++)
                {
                    value = data.GetValue(row, column);
                    if (value == null)
                        content = "";
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
        public void GetInProgram()
        {
            LinkExcelData();
            bool isNotExited = true;
            while (isNotExited)
                CheckId();
        }
        private void CheckId()
        {
            isEscape = false;
            bool isNotCorrect= Constant.IS_NOT_CORRECT;
            Console.Clear();
            basicView.LoginView();
            while (isNotCorrect)
            {
                basicView.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX, 8);
                basicView.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX, 8);
                basicView.DeleteString(0, Constant.LOGIN_ID_INDEX + 2, 25);
                basicView.DeleteString(0, Constant.LOGIN_ID_INDEX + 3, 28);
                isNotCorrect = IsCorrectUser();
                if (isEscape == true)
                    return;
                if (isNotCorrect == false)
                    break;
                exceptionView.ShowException("잘못된 로그인 정보입니다!");
                if(AskAgain()==1)
                    Environment.Exit(0);
            }
            mainMenu.SelectMenu();
        }
        private bool IsCorrectUser()
        {
            string id;
            string password;
            Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX);
            id = input.GetUserString(8,Constant.NOMARL_INPUT);
            if (id == Constant.ESCAPE_STRING)
            {
                isEscape = true;
                return isEscape; ;
            }
            Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX);
            password = input.GetUserString(8, Constant.HIDE_INPUT);
            if (password == Constant.ESCAPE_STRING)
            {
                isEscape = true;
                return isEscape; ;
            }
            if (id == Constant.ID && password == Constant.PASSWORD)
                return Constant.IS_CORRECT;
            return Constant.IS_NOT_CORRECT;
        }
        private int AskAgain()//함수로 뺄 여지가 있음
        {
            int index = 0;
            int selected = 0;
            bool isNotEnter = true;
            basicView.ShowAgain();
            while (isNotEnter)
            {
                basicView.DeleteString(0,Console.CursorTop, 1);
                basicView.DeleteString(0+13, Console.CursorTop, 1);
                switch (index)
                {
                    case Constant.RETRY:
                        Console.SetCursorPosition(0, Console.CursorTop);
                        break;
                    case Constant.EXIT:
                        Console.SetCursorPosition(0+13, Console.CursorTop);
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
