using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class AdminFuncion: UserFunction
    {
        public AdminFuncion(VOList voList)
        {
            this.voList = voList;
            bookFunction = new BookFunction(voList, this);
        }
        public void AdminLogin()//id="11111111111" ,password="9999999999"
        {
            string id;
            string password;
            isBack = false;
            bool isCorrect = false;
            Console.Clear();
            ui.AdminLabel();
            ui.AdminLoginForm();
            while (!isCorrect)
            {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ID_LOGIN_INDEX);
                id= GetData(Constant.ID_LENGTH, Constant.EMPTY);
                if (isBack)
                    return;
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                password = GetData(Constant.PASSWORD_LENGTH, Constant.EMPTY);
                isCorrect = (id == Constant.ADMIN_ID && password == Constant.ADMIN_PASSWORD);
                if (isBack)
                    return;
                if (!isCorrect)
                    exceptionView.AdminError(password.Length);
            }
            AdminSelectMenu();
        }
        public void AdminSelectMenu()
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit)
            {
                selectedMenu = menuSelection.SelectAdminMenu();
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        
                        break;
                    case Constant.SECOND_MENU:
                        
                        break;
                    case Constant.THIRD_MENU:
                        isExit = exception.IsEscape();
                        break;
                    case Constant.FOURTH_MENU:
                        exception.ExitProgramm();
                        break;
                }
            }
        }
        //public void ShowUser
    }
}
