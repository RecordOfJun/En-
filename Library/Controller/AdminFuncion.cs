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
        public void AdminLogin()
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
                id= GetData(Constant.ID_LENGTH, Constant.EMPTY);
                password = GetData(Constant.PASSWORD_LENGTH, Constant.EMPTY);
                isCorrect = (id == Constant.ADMIN_ID && password == Constant.ADMIN_PASSWORD);
                ConfirmKeep(1);
            }
        }
        //public void ShowUser
    }
}
