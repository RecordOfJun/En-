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
                        ManageBook();
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
        private void ManageBook()
        {
            bool isInsert = false;
            Console.Clear();
            ui.AdminLabel();
            ui.BookManage();
            while (!isInsert)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        isInsert = true;
                        bookFunction.SearchAndChoice(4);
                        break;
                    case ConsoleKey.D2:
                        isInsert = true;
                        bookFunction.SearchAndChoice(3);
                        break;
                    case ConsoleKey.D3:
                        AddBook();
                        isInsert = true;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
        public void AddBook()
        {
            isBack = false;
            bool isException = false;
            string id="";
            string name="";
            string publisher="";
            string author="";
            string price="";
            string quantity="";
            Console.Clear();
            ui.AdminLabel();
            ui.AddBook();
            exceptionView.ClearLine(Constant.ID_ADD_INDEX);
            while (!isBack&&!isException)
            {
                id = GetData(8, Constant.EMPTY);
                isException = exception.IsBookIdException(id,8,voList.bookList);
            }
            exceptionView.ClearLine(Constant.PASSWORD_ADD_INDEX);
            if (isBack)
                return;
            name = GetData(20, Constant.EMPTY);
            if (isBack)
                return;
            exceptionView.ClearLine(Constant.PASSWORD_CONFIRM_INDEX);
            
            publisher = GetData(20, Constant.EMPTY);
            if (isBack)
                return;
            exceptionView.ClearLine(Constant.NAME_ADD_INDEX);
            author = GetData(20, Constant.EMPTY);
            if (isBack)
                return;
            exceptionView.ClearLine(Constant.PERSONAL_ADD_INDEX);
            isException = false;
            while (!isBack && !isException)
            {
                price = GetData(6, Constant.EMPTY);
                isException = exception.IsNumber(price);
            }
            isException = false;
            exceptionView.ClearLine(Constant.PHONE_ADD_INDEX);
            while (!isBack && !isException)
            {
                quantity = GetData(2, Constant.EMPTY);
                isException = exception.IsNumber(quantity);
            }
            if (isBack)
                return;
            if (IsConfirm(1)) {
                BookVO book = new BookVO(id, name, publisher, author, price, int.Parse(quantity));
                voList.bookList.Add(book);
            }
        }
        //public void ShowUser
    }
}
