using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
namespace LTT.Controller
{
    class Login
    {
        BasicView basicView;
        ExceptionView exceptionView;
        Input input;
        MainMenu mainMenu;
        bool isEscape;
        public Login()
        {
            Console.SetWindowSize(178,30);
            this.basicView = new BasicView();
            this.exceptionView = new ExceptionView();
            this.input = new Input(basicView);
            this.mainMenu = new MainMenu(exceptionView, basicView, input);
        }
        public void GetInProgram()
        {
            bool isNotExited = true;
            while (isNotExited)
                CheckId();
        }
        public void CheckId()
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
