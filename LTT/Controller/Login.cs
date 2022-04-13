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
        BasicView ui;
        ExceptionView exceptionView;
        Input input;
        public Login()
        {
            this.ui = new BasicView();
            this.exceptionView = new ExceptionView();
            this.input = new Input(ui);
        }
        public void GetInProgram()
        {
            bool isNotCorrect= Constant.IS_NOT_CORRECT;
            ui.LoginView();
            while (isNotCorrect)
            {
                ui.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX, 8);
                ui.DeleteString(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX, 8);
                ui.DeleteString(0, Constant.LOGIN_ID_INDEX + 2, 25);
                ui.DeleteString(0, Constant.LOGIN_ID_INDEX + 3, 28);
                isNotCorrect = IsCorrectUser();
                if (isNotCorrect == false)
                    break;
                exceptionView.ShowException("잘못된 로그인 정보입니다!");
                if(AskAgain()==1)
                    Environment.Exit(0);
            }

        }
        private bool IsCorrectUser()
        {
            string id;
            string password;
            Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX);
            id = input.GetUserString(8,Constant.NOMARL_INPUT);
            Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX);
            password = input.GetUserString(8, Constant.HIDE_INPUT);
            if (id == Constant.ID && password == Constant.PASSWORD)
                return Constant.IS_CORRECT;
            return Constant.IS_NOT_CORRECT;
        }
        private int AskAgain()
        {
            int index = 0;
            int selected = 0;
            bool isNotEnter = true;
            ui.ShowAgain();
            while (isNotEnter)
            {
                ui.DeleteString(0,Console.CursorTop, 1);
                ui.DeleteString(0+13, Console.CursorTop, 1);
                switch (index)
                {
                    case 0:
                        Console.SetCursorPosition(0, Console.CursorTop);
                        break;
                    case 1:
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
