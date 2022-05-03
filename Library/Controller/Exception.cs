using System;
using System.Collections.Generic;
using System.Text;
using Library.View;
using Library.Model;
using System.Text.RegularExpressions;

namespace Library.Controller
{
    class Exception//예외처리 클래스
    {
        ExceptionView exceptionView = new ExceptionView();
        string[] number = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] alphabat = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public bool IsIdException(string userInput)
        {
            if (DBConnection.GetDBConnection().IsExistedId(userInput))
            {
                exceptionView.InsertException(userInput.Length, "  (이미 존재하는 아이디 입니다!)");
                return Constant.IS_EXCEPTION;
            }
            return IsExceptionIdPassword(userInput,Constant.INSERT_TYPE);
        }
        public bool IsExceptionIdPassword(string userInput,int type)
        {
            int length = userInput.Length;
            int deletedLength;
            if(userInput==Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            if (length < Constant.ID_PASSWORD_MINIMUM_LENGTH ) {
                if (type == Constant.INSERT_TYPE)
                    exceptionView.InsertException(userInput.Length, "  (6~10 글자로 입력해 주세요!)");
                else
                    exceptionView.SearchException(userInput.Length, "  (6~10 글자로 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            foreach (string element in number)//인풋에서 숫자 제거
            {
                userInput = userInput.Replace(element, Constant.EMPTY);
            }
            bool isDeleteInt = userInput.Length < length;//숫자가 지워졌는지 확인
            deletedLength = userInput.Length;
            foreach(string element in alphabat)//문자제거
            {
                userInput = userInput.Replace(element, Constant.EMPTY);
                userInput = userInput.Replace(element.ToUpper(), Constant.EMPTY);
            }
            bool isDeletechar = userInput.Length < deletedLength;
            if (userInput != Constant.EMPTY)
            {
                if(type==Constant.INSERT_TYPE)
                    exceptionView.InsertException(userInput.Length, "  (영어와 숫자만 입력해 주세요!)");
                else
                    exceptionView.SearchException(userInput.Length, "  (영어와 숫자만 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            if (!isDeleteInt || !isDeletechar)
            {
                if (type == Constant.INSERT_TYPE)
                    exceptionView.InsertException(userInput.Length, "  (영어와 숫자를 혼합해 입력해 주세요!)");
                else
                    exceptionView.SearchException(userInput.Length, "  (영어와 숫자를 혼합해 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsIdentical(string userInput,string password)
        {
            if (userInput != password)
            {
                exceptionView.InsertException(userInput.Length, "  (비밀번호를 동일하게 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsNameException(string userInput,int type)
        {
            if (userInput == Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            Regex name = new Regex(Constant.NAME);
            if (!name.IsMatch(userInput))
            {
                if(type==Constant.INSERT_TYPE)
                    exceptionView.InsertException(userInput.Length, "  (한글만 입력해 주세요!)");
                else
                    exceptionView.SearchException(userInput.Length, "  (한글만 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsPersnoalAndPhoneException(string userInput,int length)
        {
            bool isContainNumber;
            if (userInput == Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            if (length != userInput.Length)
            {
                exceptionView.InsertException(userInput.Length, "  (양식에 맞는 글자수를 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            foreach(char letter in userInput)
            {
                isContainNumber = (Constant.NUMBER_START <= letter && letter <= Constant.NUMBER_END);
                if (!isContainNumber)
                {
                    exceptionView.InsertException(userInput.Length, "  (숫자만 입력해 주세요!)");
                    return Constant.IS_EXCEPTION;
                }

            }
            if (length == Constant.PHONE_LENGTH)
                return IsPhoneException(userInput);

            if (length == Constant.PERSONAL_LENGTH)
                return IsPersnolException(userInput);
            return !Constant.IS_EXCEPTION;
        }
        public bool IsPersnolException(string userInput)
        {
            string month = userInput.Substring(Constant.MONTH_INDEX, 2);
            string date= userInput.Substring(Constant.DAY_INDEX, 2);
            string gender = userInput.Substring(Constant.GENDER_INDEX, 1);
            if (int.Parse(month)>Constant.MONTH_LENGTH||int.Parse(date)>Constant.DAY_LENGTH)
            {
                exceptionView.InsertException(userInput.Length, "  (생년월일을 다시 확인해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            if(int.Parse(gender) > Constant.GENDER_LAST || int.Parse(gender) < Constant.GENDER_FIRST)
            {
                exceptionView.InsertException(userInput.Length, "  (7번째 자리를 다시 확인해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            if (DBConnection.GetDBConnection().IsExistedPersonal(userInput))
            {
                exceptionView.InsertException(userInput.Length, "  (이미 가입이 완료된 사용자 입니다!)");
                return Constant.IS_EXCEPTION;
            }

            return !Constant.IS_EXCEPTION;
        }
        public bool IsPhoneException(string userInput)
        {
            Regex phone = new Regex(Constant.PHONE);
            if (!phone.IsMatch(userInput))
            {
                exceptionView.InsertException(userInput.Length, "(올바르지 않은  휴대전화번호 입니다.)");
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsEscape()
        {
            ConsoleKeyInfo key;
            exceptionView.AskEscape();
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            return false;
        }
        public void ExitProgramm()
        {
            ConsoleKeyInfo key;
            exceptionView.AskExit();
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Environment.Exit(0);
            }
            return;
        }
        public bool IsDelete(string name)
        {
            ConsoleKeyInfo key;
            exceptionView.AskDelete(name);
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            return false;
        }
        public bool IsRevise(string name)
        {
            ConsoleKeyInfo key;
            exceptionView.AskRevise(name);
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            return false;
        }
        public bool IsNumber(string input,int type)
        {
            if (input == Constant.EMPTY)
            {
                exceptionView.InsertException(0, "(아무것도 입력하지 않았습니다!)");
                return false;
            }
            foreach (string element in number)//인풋에서 숫자 제거
            {
                input = input.Replace(element, Constant.EMPTY);
            }
            if (input != Constant.EMPTY)
            {
                if (type == Constant.INSERT_TYPE)
                    exceptionView.InsertException(input.Length, "  (숫자만 입력해 주세요!)");
                else
                    exceptionView.SearchException(input.Length, "  (숫자만 입력해 주세요!)");
                return false;
            }
            return true;
        }
        public bool IsBookIdException(string userInput, int length)
        {
            bool isContainNumber;
            if (userInput == Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            if (length != userInput.Length)//8
            {
                exceptionView.InsertException(userInput.Length, "  (양식에 맞는 글자수를 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            foreach (char letter in userInput)
            {
                isContainNumber = (Constant.NUMBER_START <= letter && letter <= Constant.NUMBER_END);
                if (!isContainNumber)
                {
                    exceptionView.InsertException(userInput.Length, "  (숫자만 입력해 주세요!)");
                    return Constant.IS_EXCEPTION;
                }

            }
            if (DBConnection.GetDBConnection().IsExistedBookId(userInput))
            {
                exceptionView.InsertException(userInput.Length, "(이미 존재하는 도서번호 입니다!)");
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsAdress(string userInput)
        {
            Regex roadName = new Regex(Constant.ADRESS_FIRST);
            Regex adress = new Regex(Constant.ADRESS_SECOND);
            if (!roadName.IsMatch(userInput)&& !adress.IsMatch(userInput))
            {
                exceptionView.InsertException(userInput.Length * 2, "(주소 양식을 확인해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsInsertNaver(string query,string display)
        {
            if (query == "" || display == "")
            {
                exceptionView.SearchException(0, "(정보를 다 입력해 주세요!)");
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
    }
}
