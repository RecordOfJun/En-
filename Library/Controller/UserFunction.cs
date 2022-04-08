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
            id=SetIdPassword(Constant.ID_ADD_INDEX);
            password = SetIdPassword(Constant.PASSWORD_ADD_INDEX);
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.NAME_ADD_INDEX);
            name = Console.ReadLine();
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PERSONAL_ADD_INDEX);
            personalCode = Console.ReadLine();
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PHONE_ADD_INDEX);
            phoneNumber = Console.ReadLine();
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ADDRESS_ADD_INDEX);
            address = Console.ReadLine();
        }
        private string SetIdPassword(int index)
        {
            string userInput="";
            string id;
            bool isException = Constant.IS_EXCEPTION;
            while (!isException)
            {
                exceptionView.ClearLine(index);
                userInput = GetData(10);
                isException = exception.IsExceptionIdPassword(userInput);
            }
            return userInput;
        }
        private string GetData(int maximumLength)
        {
            int index = 0;// Constant.INDEX_MINIMUM;
            string[] inputString = { "", "", "", "", "", "", "", "", "", "" };
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
                    if (index > 0)
                    {
                        index--;
                        inputString[index] = Constant.EMPTY;
                    }
                }
                else if (index < maximumLength&&!isArrow)
                {
                    
                    inputString[index] = userinput;
                    index++;
                }
                ui.SetIdPasswordCursor(inputString);
            }
            return String.Join("",inputString);
        }
    }
}
