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
        public MemberVO LoginMember;
        private string id;
        private string password;
        private string temporalpassword;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        private bool isBack;
        public UserFunction(VOList voList)
        {
            this.voList = voList;
            bookFunction = new BookFunction(voList, this);
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
            ConfirmKeep(1);//수정필요
            LinkData();
            UserSelectMenu();
        }
        private void LinkData()
        {
            this.id = LoginMember.Id;
            this.password = LoginMember.Password;
            this.name = LoginMember.Name;
            this.phoneNumber = LoginMember.PhoneNumber;
            this.personalCode = LoginMember.PersonalCode;
            this.address = LoginMember.Address;
        }
        private bool ChekId()
        {
            bool isException = false;
            while (!isException && !isBack) {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                id = GetData(Constant.ID_LENGTH, Constant.EMPTY);
                isException = exception.IsExceptionIdPassword(id);
            }
            isException = false;
            while (!isException && !isBack)
            {
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                password = GetData(Constant.PASSWORD_LENGTH, Constant.EMPTY);
                isException = exception.IsExceptionIdPassword(password);
            }
            if (isBack)
                return Constant.IS_EXCEPTION;
            if (voList.memberList.Exists(element => element.Id == id) && voList.memberList.Find(element => element.Id == id).Password == password)
            {
                LoginMember = voList.memberList.Find(element => element.Id == id);
                return !Constant.IS_EXCEPTION;
            }

            exceptionView.CanNotLogin(password.Length);
            return Constant.IS_EXCEPTION;
        }
        private void InitString()
        {
            id = "";
            password = "";
            temporalpassword = "";
            name = "";
            personalCode = "";
            phoneNumber = "";
            address = "";
        }
        //회원가입 기능
        public void AddMember()
        {
            isBack = false;
            InitString();
            Console.Clear();
            ui.LibraryLabel();
            ui.AddMemberForm();
            id = SetData(Constant.ID_ADD_INDEX, id);
            temporalpassword = SetData(Constant.PASSWORD_ADD_INDEX, password);
            SetData(Constant.PASSWORD_CONFIRM_INDEX, "");
            password = temporalpassword;
            name = SetData(Constant.NAME_ADD_INDEX, name);
            personalCode = SetData(Constant.PERSONAL_ADD_INDEX, personalCode);
            phoneNumber = SetData(Constant.PHONE_ADD_INDEX, phoneNumber);
            address = SetData(Constant.ADDRESS_ADD_INDEX, address);
            if (isBack)
                return;
            ConfirmKeep(1);
            CreateTable();

        }
        public void ReviseMember()
        {
            isBack = false;
            LinkData();
            Console.Clear();
            ui.LibraryLabel();
            ui.ReviseForm();
            WriteData(Constant.ID_ADD_INDEX, id);
            WriteData(Constant.PASSWORD_ADD_INDEX, password);
            WriteData(Constant.NAME_ADD_INDEX, name);
            WriteData(Constant.PERSONAL_ADD_INDEX, personalCode);
            WriteData(Constant.PHONE_ADD_INDEX, phoneNumber);
            WriteData(Constant.ADDRESS_ADD_INDEX, address);
            temporalpassword = SetData(Constant.PASSWORD_ADD_INDEX, password);
            SetData(Constant.PASSWORD_CONFIRM_INDEX, password);
            password = temporalpassword;
            name = SetData(Constant.NAME_ADD_INDEX, name);
            phoneNumber = SetData(Constant.PHONE_ADD_INDEX, phoneNumber);
            address = SetData(Constant.ADDRESS_ADD_INDEX, address);
            if (isBack)
                return;
            ConfirmKeep(2);
            ReviseData();

        }
        private void ReviseData()
        {
            LoginMember.Id = this.id;
            LoginMember.Password = this.password;
            LoginMember.Name = this.name;
            LoginMember.PhoneNumber = this.phoneNumber;
            LoginMember.PersonalCode = this.personalCode;
            LoginMember.Address = this.address;
        }
        private void WriteData(int index, string data){
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
            Console.Write(data);
        }
        private void ConfirmKeep(int type)
        {   if (type == 1)
                ui.ConfirmAddForm();
            else
                ui.ReviseDone();
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                return;
        }
        private string SetData(int index,string userInput)
        {
            bool isException = Constant.IS_EXCEPTION;
            string nullCheck = userInput;
            while (!isException&&!isBack)
            {
                userInput = nullCheck;
                exceptionView.ClearLine(index);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX:
                        userInput = GetData(Constant.ID_LENGTH,userInput);
                        isException = exception.IsIdException(userInput, voList.memberList);
                        break;
                    case Constant.PASSWORD_ADD_INDEX:
                        userInput = GetData(Constant.PASSWORD_LENGTH, userInput);
                        isException = exception.IsExceptionIdPassword(userInput);
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX:
                        userInput = GetData(Constant.PASSWORD_LENGTH, userInput);
                        isException = exception.IsIdentical(userInput,temporalpassword);
                        break;
                    case Constant.NAME_ADD_INDEX:
                        userInput = GetData(Constant.NAME_LENGTH, userInput);
                        isException = exception.IsNameException(userInput);
                        break;
                    case Constant.PERSONAL_ADD_INDEX:
                        userInput = GetData(Constant.PERSONAL_LENGTH, userInput);
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH, voList.memberList);
                        break;
                    case Constant.PHONE_ADD_INDEX:
                        userInput = GetData(Constant.PHONE_LENGTH, userInput);
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH, voList.memberList);
                        break;
                    case Constant.ADDRESS_ADD_INDEX:
                        userInput = GetData(Console.WindowWidth-1, userInput);
                        isException = !Constant.IS_EXCEPTION;
                        break;
                }
                
            }
            if (nullCheck != "" && index != Constant.PASSWORD_ADD_INDEX&&!isBack)
                ui.Revised(userInput.Length);
            return userInput;
        }
        public string GetData(int maximumLength,string inputString)
        {
            ConsoleKeyInfo key;
            string userinput;
            bool isEnter = false;
            if (maximumLength == Constant.PASSWORD_LENGTH)
                ui.WritePassword(inputString);
            else
                ui.SetInputCursor(inputString);
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
                        bookFunction.ReturnBook();
                        break;
                    case Constant.THIRD_MENU:
                        ReviseMember();
                        break;
                    case Constant.FOURTH_MENU:
                        isExit = exception.IsEscape();
                        break;
                    case Constant.FIFTH_MENU:
                        exception.ExitProgramm();
                        break;
                }
            }
        }
    }
}
