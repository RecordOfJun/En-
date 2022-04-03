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
        public bool IsOccurException(string userInput)
        {
            bool exceptionOccur = false;
            if (IsEmpty(userInput) == true)
            {
                Console.WriteLine("공백을 입력했습니다!");
                return exceptionOccur;
            }
            else if (IsContainChar(userInput) == true)
            {
                Console.WriteLine("숫자를 입력해주세요!");
                return exceptionOccur;
            }
            //실수 음수 int범위 외의 숫자 들어오면 어떻게 구분할거임?
            else return true;
        }
        public bool IsContainChar(string userInput)
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
        private bool IsEmpty(string userInput)
        {
            if (userInput == "")
                return true;
            else
                return false;
        }
    }
}
