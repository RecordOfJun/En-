using System;
using System.Collections.Generic;
using System.Text;
using Library.View;

namespace Library.Controller
{
    class Exception
    {
        ExceptionView exceptionView = new ExceptionView();
        string[] number = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] alphabat = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public Exception()
        {
        }
        public bool IsExceptionIdPassword(string userInput)
        {
            int length = userInput.Length;
            int deletedLength;
            if (length < 6 || length > 10) {
                exceptionView.IdPasswordLength(length);
                return Constant.IS_EXCEPTION;
            }
            foreach (string element in number)//인풋에서 숫자 제거
            {
                userInput = userInput.Replace(element, "");
            }
            bool isDeleteInt = userInput.Length < length;
            deletedLength = userInput.Length;
            foreach(string element in alphabat)
            {
                userInput = userInput.Replace(element, "");
                userInput = userInput.Replace(element.ToUpper(), "");
            }
            bool isDeletechar = userInput.Length < deletedLength;
            if (userInput != "")
            {
                exceptionView.IdPasswordContain(length);
                return Constant.IS_EXCEPTION;
            }
            if (!isDeleteInt || !isDeletechar)
            {
                exceptionView.IdPasswordNotContain(length);
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
    }
}
