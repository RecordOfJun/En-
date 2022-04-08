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
        UI ui = new UI();
        private string id;
        private string password;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        public UserFunction()
        {

        }
        public void Login()
        {

        }
        public void AddMember()
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.AddMemberForm();
            id=SetData(Constant.ID_ADD_INDEX);
            password = SetData(Constant.PASSWORD_ADD_INDEX);
            name = SetData(Constant.NAME_ADD_INDEX);
            personalCode = SetData(Constant.PERSONAL_ADD_INDEX);
            phoneNumber = SetData(Constant.PHONE_ADD_INDEX);
            address = SetData(Constant.ADDRESS_ADD_INDEX);
        }
        private string SetData(int index)
        {
            string userInput="";
            bool isException = Constant.IS_EXCEPTION;
            while (!isException)
            {
                exceptionView.ClearLine(index);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX: case Constant.PASSWORD_ADD_INDEX:
                        userInput = GetData(Constant.ID_PASSWORD_LENGTH);
                        isException = exception.IsExceptionIdPassword(userInput);
                        break;
                    case Constant.NAME_ADD_INDEX:
                        userInput = GetData(Constant.NAME_LENGTH);
                        isException = exception.IsNameException(userInput);
                        break;
                    case Constant.PERSONAL_ADD_INDEX:
                        userInput = GetData(Constant.PERSONAL_LENGTH);
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH);
                        break;
                    case Constant.PHONE_ADD_INDEX:
                        userInput = GetData(Constant.PHONE_LENGTH);
                        isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH);
                        break;
                    case Constant.ADDRESS_ADD_INDEX:
                        userInput = GetData(Console.WindowWidth-1);
                        isException = exception.IsNameException(userInput);
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
            while (!isEnter)
            {
                
                key = Console.ReadKey();
                bool isArrow = ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.DownArrow));
                userinput = key.KeyChar.ToString();
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
                ui.SetInputCursor(inputString);
            }
            return inputString;
        }
    }
}
