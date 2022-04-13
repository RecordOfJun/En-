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
        Exception exception;
        Input input;
        public Login()
        {
            this.ui = new BasicView();
            this.exception = new Exception();
            this.input = new Input(ui);
        }
        public void GetInProgram()
        {
            bool isNotCorrect= Constant.IS_NOT_CORRECT;
            ui.LoginView();
            while (isNotCorrect)
            {
                Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX);
                ui.DeleteSting(Constant.LOGIN_INDEX, 8);
                Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX);
                ui.DeleteSting(Constant.LOGIN_INDEX, 8);
                isNotCorrect = IsCorrectUser();
            }

        }
        private bool IsCorrectUser()
        {
            string id;
            string password;
            Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_ID_INDEX);
            id = input.GetUserInput(8,Constant.NOMARL_INPUT);
            Console.SetCursorPosition(Constant.LOGIN_INDEX, Constant.LOGIN_PASSWORD_INDEX);
            password = input.GetUserInput(8, Constant.HIDE_INPUT);
            if (id == Constant.ID && password == Constant.PASSWORD)
                return Constant.IS_CORRECT;
            return Constant.IS_NOT_CORRECT;
        }
    }
}
