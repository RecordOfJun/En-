using System;
using System.Collections.Generic;
using System.Text;
using Library.View;
using Library.Model;
using System.Text.RegularExpressions;

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
        public bool IsIdException(string userInput, List<MemberVO> memberList)
        {
            if (memberList.Exists(element => element.Id == userInput))
            {
                exceptionView.ExistedId(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            return IsExceptionIdPassword(userInput);
        }
        public bool IsExceptionIdPassword(string userInput)
        {
            int length = userInput.Length;
            int deletedLength;
            if(userInput==Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            if (length < Constant.ID_PASSWORD_MINIMUM_LENGTH ) {
                exceptionView.IdPasswordLength(length);
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
        public bool IsIdentical(string userInput,string password)
        {
            if (userInput != password)
            {
                exceptionView.NotIdentical(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsNameException(string userInput)
        {
            bool isContainKorean;
            if (userInput == Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            Regex name = new Regex(@"^[가-힣]{1,4}");
            if (!name.IsMatch(userInput))
            {
                exceptionView.NameContain(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsPersnoalAndPhoneException(string userInput,int length,List<MemberVO> memberList)
        {
            bool isContainNumber;
            if (userInput == Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            if (length != userInput.Length)
            {
                exceptionView.PersonalAndPhoneLength(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            foreach(char letter in userInput)
            {
                isContainNumber = (Constant.NUMBER_START <= letter && letter <= Constant.NUMBER_END);
                if (!isContainNumber)
                {
                    exceptionView.NumberContain(userInput.Length);
                    return Constant.IS_EXCEPTION;
                }

            }
            if (length == Constant.PHONE_LENGTH)
                return IsPhoneException(userInput);

            else if (length == Constant.PERSONAL_LENGTH)
                return IsPersnolException(userInput,memberList);
            return !Constant.IS_EXCEPTION;
        }
        public bool IsPersnolException(string userInput,List<MemberVO> memberList)
        {
            string month = userInput.Substring(Constant.MONTH_INDEX, 2);//매직넘버
            string date= userInput.Substring(Constant.DAY_INDEX, 2);
            string gender = userInput.Substring(Constant.GENDER_INDEX, 1);
            if (int.Parse(month)>Constant.MONTH_LENGTH||int.Parse(date)>Constant.DAY_LENGTH)//매직넘버
            {
                exceptionView.CheckDate(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            if(int.Parse(gender) > Constant.GENDER_LAST || int.Parse(gender) < Constant.GENDER_FIRST)//매직넘버
            {
                exceptionView.CheckGender(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            if (memberList.Exists(member => member.PersonalCode == userInput))
            {
                exceptionView.ExistedCode(userInput.Length);
                return Constant.IS_EXCEPTION;
            }

            return !Constant.IS_EXCEPTION;
        }
        public bool IsPhoneException(string userInput)
        {
            if (userInput.Substring(0, 3) != "010")
            {
                exceptionView.StartWith010(userInput.Length);
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
        public bool IsNumber(string input)
        {
            if (input == Constant.EMPTY)
            {
                exceptionView.EmptyString();
                return false;
            }
            foreach (string element in number)//인풋에서 숫자 제거
            {
                input = input.Replace(element, Constant.EMPTY);
            }
            if (input != Constant.EMPTY)
            {
                exceptionView.NumberContain(input.Length);
                return false;
            }
            return true;
        }
        public bool IsBookIdException(string userInput, int length, List<BookVO> bookList)
        {
            bool isContainNumber;
            if (userInput == Constant.ESCAPE)
                return Constant.IS_EXCEPTION;
            if (length != userInput.Length)//8
            {
                exceptionView.PersonalAndPhoneLength(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            foreach (char letter in userInput)
            {
                isContainNumber = (Constant.NUMBER_START <= letter && letter <= Constant.NUMBER_END);
                if (!isContainNumber)
                {
                    exceptionView.NumberContain(userInput.Length);
                    return Constant.IS_EXCEPTION;
                }

            }
            if (bookList.Exists(book => book.Id == userInput))
            {
                exceptionView.ExistedBookId(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
        public bool IsAdress(string userInput)
        {
            Regex roadName = new Regex(@"^[가-힣]+[도|시](\s?)[가-힣]+[시|구](\s?)[가-힣a-zA-Z]+로(\s?)[0-9]{1,3}번?길(\s?)([0-9]+-?[0-9]*)?(,?\s?)(([0-9]+동)?(\s?)[0-9]+호)?$");
            Regex adress = new Regex(@"^[가-힣]+[도|시](\s?)([가-힣]+[시|구|군])+(\s?)[가-힣]+[읍|면|동](\s?)([가-힣]+리)?(\s?)([0-9]+-?[0-9]*)(,?\s?)(([0-9]+동)?(\s?)[0-9]+호)?$");
            if (!roadName.IsMatch(userInput)&& !adress.IsMatch(userInput))
            {
                exceptionView.ValidAdress(userInput.Length);
                return Constant.IS_EXCEPTION;
            }
            return !Constant.IS_EXCEPTION;
        }
    }
}
