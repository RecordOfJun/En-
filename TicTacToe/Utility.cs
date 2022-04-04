using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Utility
    {
        public Utility()
        {

        }
        public bool IsParseException(string userInput,int startNumber,int endNumber)//
        {
            bool exceoptionOccur = true;
            bool exceptionReturn = false;
            Console.ForegroundColor = ConsoleColor.Red;
            if (IsEmpty(userInput) == exceoptionOccur)
            {
                Console.WriteLine("공백을 입력했습니다!");
                return exceptionReturn;
            }
            else if (IsContainChar(userInput) == exceoptionOccur)
            {
                Console.WriteLine("자연수를 입력해주세요!");
                return exceptionReturn;
            }
            else if (IsTooLong(userInput) == exceoptionOccur)
            {
                Console.WriteLine("숫자가 너무 큽니다!");
                return exceptionReturn;
            }
            else if (int.Parse(userInput) < startNumber || int.Parse(userInput) > endNumber)
            {
                Console.WriteLine(startNumber + "~" + endNumber + "에서 숫자를 선택해 주세요!");
                return exceptionReturn;
            }
            //실수 음수 int범위 외의 숫자 들어오면 어떻게 구분할거임?
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
        }
        private bool IsContainChar(string userInput)
        {
            string needToCheck = userInput;
            string[] numberToRemove = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach(var number in numberToRemove)
            {
                needToCheck = needToCheck.Replace(number, "");
            }
            if (needToCheck == "")
                return false;
            else
                return true;
        }
        private bool IsTooLong(string userInput)
        {
            int integerBoundary = 9;
            if (userInput.Length >= integerBoundary)
                return true;
            else return false;
        }
        private bool IsEmpty(string userInput)
        {
            if (userInput == "")
                return true;
            else
                return false;
        }
    }
}
