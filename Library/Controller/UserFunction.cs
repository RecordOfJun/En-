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
        List<MemberVO> memberList;
        UI ui = new UI();
        private string id;
        private string password;
        private string identicalpassword;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        private bool isBack;
        public UserFunction(List<MemberVO> memberList)
        {
            this.memberList = memberList;
        }
        public void Login()
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.LoginForm();
            exceptionView.ClearLine(0);
            id = GetData(Constant.ID_PASSWORD_LENGTH);
            password = GetData(Constant.PASSWORD_LENGTH);
        }
        //private bool 
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
            ui.ConfirmAddForm();
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                return;
            CreateTable();
            foreach(MemberVO member in memberList)
            {
                Console.WriteLine(member.ToString());
            }

        }
        private void Insert(string type,int index)
        {
            type = SetData(index);
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
                        userInput = GetData(Constant.ID_PASSWORD_LENGTH);
                        isException = exception.IsIdException(userInput,memberList);
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
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH,memberList);
                        break;
                    case Constant.PHONE_ADD_INDEX:
                        userInput = GetData(Constant.PHONE_LENGTH);
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH,memberList);
                        break;
                    case Constant.ADDRESS_ADD_INDEX:
                        userInput = GetData(Console.WindowWidth-1);
                        isException = !Constant.IS_EXCEPTION;
                        break;
                }
                
            }
            return userInput;
        }
        private string GetData(int maximumLength)
        {
            string inputString = Constant.EMPTY;
            ConsoleKeyInfo key;
            string userinput;
            bool isEnter = false;
            while (!isEnter&&!isBack)
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
            memberList.Add(member);
        }
    }
}
