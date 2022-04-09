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
                        ManageMember();
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
        private void ManageMember()
        {
            bool isInsert = false;
            Console.Clear();
            ui.AdminLabel();
            ui.MemberManage();
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
                        SearchAndChoiceMember(1);//매직넘버
                        break;
                    case ConsoleKey.D2:
                        isInsert = true;
                        SearchAndChoiceMember(2);//매직넘버
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
        private void ShowMemberList(string name)
        {
            foreach (MemberVO member in voList.memberList.FindAll(element => element.Name.Contains(name)))
            {
                ui.MemberInformation(member);
            }
        }
        public void SearchAndChoiceMember(int type)
        {
            string userInput = Constant.EMPTY;//매직넘버
            Refresh(userInput);
            while (userInput != Constant.ESCAPE)
            {
                userInput = InsertNameAndPersonal(userInput, type);
                if (userInput == Constant.ESCAPE)
                    return;
                switch (type)
                {
                    case 1://매직넘버
                        ReviseMember(userInput);
                        break;
                    case 2:
                        DeleteMember(userInput);
                        break;
                }
                Refresh(Constant.EMPTY);
            }
        }
        private string InsertNameAndPersonal(string userInput,int type)
        {
            bool isException = false;
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX);
            while (!isException)
            {
                userInput = GetData(4, Constant.EMPTY);//매직넘버
                if (userInput == Constant.ESCAPE)
                    return userInput;
                isException = exception.IsNameException(userInput);
            }
            Refresh(userInput);
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.CODE_INDEX);
            userInput = GetData(13, Constant.EMPTY);//매직넘버
            return userInput;
        }
        private void ReviseMember(string code)
        {
            if (code == "")
                return;
            MemberVO member = voList.memberList.Find(member => member.PersonalCode == code);
            if (member != null)
            {
                this.LoginMember = member;
                ReviseMember();
            }
            else
                exceptionView.NotExistedMember(code.Length);
        }
        private void DeleteMember(string code)
        {
            if (code == "")
                return;
            MemberVO member = voList.memberList.Find(member => member.PersonalCode == code);
            if (member != null)
            {
                if (exception.IsDelete(code))
                {
                    foreach (MyBook myBook in member.borrowedBook)
                    {
                        myBook.book.Borrowed--;
                        member.borrowedBook.Remove(myBook);
                    }
                    voList.memberList.Remove(member);
                }
            }
            else
                exceptionView.NotExistedMember(code.Length);
        }
        private void Refresh(string userInput)
        {
            Console.Clear();
            ui.AdminLabel();
            ui.MemberSearchGuide();
            ShowMemberList(userInput);
        }
    }
}
