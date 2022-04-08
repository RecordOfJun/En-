using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;

namespace Library.Controller
{
    class UserFunction
    {
        ExceptionView exceptionView = new ExceptionView();
        Exception exception = new Exception();
        VOList voList;
        UI ui = new UI();
        BookFunction bookFunction;
        MenuSelection menuSelection = new MenuSelection();
        private string id;
        private string password;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        private bool isBack;
        public UserFunction(VOList voList)
        {
            this.voList = voList;
            bookFunction = new BookFunction(voList.bookList,this);
        }
        //로그인 기능
        public void Login()
        {
            isBack = false;
            bool isCorrect = false;
            Console.Clear();
            ui.LibraryLabel();
            ui.LoginForm();
            while (!isCorrect)
            {
                isCorrect = ChekId();
                if (isBack)
                    return;
            }
            ConfirmKeep();
            UserSelectMenu();
        }
        private bool ChekId()
        {
            bool isException = false;
            while (!isException&&!isBack) {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                id = GetData(Constant.ID_LENGTH);
                isException = exception.IsExceptionIdPassword(id);
            }
            isException = false;
            while (!isException && !isBack)
            {
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                password = GetData(Constant.PASSWORD_LENGTH);
                isException = exception.IsExceptionIdPassword(password);
            }
            if (isBack)
                return Constant.IS_EXCEPTION;
            if (voList.memberList.Exists(element => element.Id == id)&& voList.memberList.Find(element => element.Id == id).Password==password)
            {
                return !Constant.IS_EXCEPTION;
            }
            
            exceptionView.CanNotLogin(password.Length);
            return Constant.IS_EXCEPTION;
        }

        //회원가입 기능
        public void AddMember()
        {
            isBack = false;
            Console.Clear();
            ui.LibraryLabel();
            ui.AddMemberForm();
            id=SetData(Constant.ID_ADD_INDEX);
            password = SetData(Constant.PASSWORD_ADD_INDEX);
            SetData(Constant.PASSWORD_CONFIRM_INDEX);
            name = SetData(Constant.NAME_ADD_INDEX);
            personalCode = SetData(Constant.PERSONAL_ADD_INDEX);
            phoneNumber = SetData(Constant.PHONE_ADD_INDEX);
            address = SetData(Constant.ADDRESS_ADD_INDEX);
            if (isBack)
                return;
            ConfirmKeep();
            CreateTable();
            foreach(MemberVO member in voList.memberList)
            {
                Console.WriteLine(member.ToString());
            }

        }
        private void ConfirmKeep()
        {
            ui.ConfirmAddForm();
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                return;
        }
        private string SetData(int index)
        {
            string userInput="";
            bool isException = Constant.IS_EXCEPTION;
            while (!isException&&!isBack)
            {
                exceptionView.ClearLine(index);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX:
                        userInput = GetData(Constant.ID_LENGTH);
                        isException = exception.IsIdException(userInput, voList.memberList);
                        break;
                    case Constant.PASSWORD_ADD_INDEX:
                        userInput = GetData(Constant.PASSWORD_LENGTH);
                        isException = exception.IsExceptionIdPassword(userInput);
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX:
                        userInput = GetData(Constant.PASSWORD_LENGTH);
                        isException = exception.IsIdentical(userInput,password);
                        break;
                    case Constant.NAME_ADD_INDEX:
                        userInput = GetData(Constant.NAME_LENGTH);
                        isException = exception.IsNameException(userInput);
                        break;
                    case Constant.PERSONAL_ADD_INDEX:
                        userInput = GetData(Constant.PERSONAL_LENGTH);
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH, voList.memberList);
                        break;
                    case Constant.PHONE_ADD_INDEX:
                        userInput = GetData(Constant.PHONE_LENGTH);
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH, voList.memberList);
                        break;
                    case Constant.ADDRESS_ADD_INDEX:
                        userInput = GetData(Console.WindowWidth-1);
                        isException = !Constant.IS_EXCEPTION;
                        break;
                }
                
            }
            return userInput;
        }
        public string GetData(int maximumLength)
        {
            string inputString = Constant.EMPTY;
            ConsoleKeyInfo key;
            string userinput;
            bool isEnter = false;
            while (!isEnter)
            {
                
                key = Console.ReadKey();
                bool isArrow = ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.DownArrow));
                userinput = key.KeyChar.ToString();
                if (key.Key == ConsoleKey.Escape)
                {
                    isBack = true;
                    return Constant.ESCAPE;
                }
                if (key.Key == ConsoleKey.Enter)
                    break;
                if (userinput == "\b")
                {
                    if (inputString.Length > 0)
                    {
                        inputString = inputString.Substring(0, inputString.Length-1);
                    }
                }
                else if (inputString.Length < maximumLength&&!isArrow)
                {
                    
                    inputString += userinput;
                }
                if (maximumLength == Constant.PASSWORD_LENGTH)
                    ui.WritePassword(inputString);
                else
                    ui.SetInputCursor(inputString);
            }
            return inputString;
        }
        private void CreateTable()
        {
            MemberVO member = new MemberVO();
            member.Id = id;
            member.Password = password;
            member.Name = name;
            member.PersonalCode = personalCode;
            member.PhoneNumber = phoneNumber;
            member.Address = address;
            voList.memberList.Add(member);
        }

        //로그인 후 메뉴 선택기능
        public void UserSelectMenu()
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit)
            {
                selectedMenu = menuSelection.SelectUserMenu();
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        bookFunction.SearchAndBrrow();
                        break;
                    case Constant.SECOND_MENU:
                        
                        break;
                    case Constant.THIRD_MENU:

                        break;
                    case Constant.FOURTH_MENU:
                        return;
                    case Constant.FIFTH_MENU:
                        Environment.Exit(0);
                        return;
                }
            }
        }
    }
}
