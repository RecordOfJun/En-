using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

namespace Library.Controller
{
    class LibraryProgram
    {
        VOList listData = new VOList();
        MenuSelection menuSelection = new MenuSelection();
        Exception exception = new Exception();
        UserFunction userFunction;
        AdminFuncion adminFuncion;
        public LibraryProgram()
        {
            userFunction= new UserFunction(listData);
            adminFuncion=new AdminFuncion(listData);
        }
        public void start()
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit) {
                selectedMenu = menuSelection.SelectMenu();
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        userFunction.Login();
                        break;
                    case Constant.SECOND_MENU:
                        userFunction.AddMember();
                        break;
                    case Constant.THIRD_MENU:
                        adminFuncion.AdminLogin();
                        break;
                    case Constant.FOURTH_MENU:
                        exception.ExitProgramm();
                        break;
                }
            }
        }
    }
}
