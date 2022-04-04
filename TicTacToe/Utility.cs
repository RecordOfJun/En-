using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Utility//게임 진행과 사용자 입력에 대한 여러가지 상황을 처리해주는 클래스
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
        public int CheckResult(List<string> indexOfSquare)
        {
            int leftComponent = -1;
            int rightComponent = 1;
            int upComponent = -3;
            int downComponent = 3;
            int result=3;
            for(int secondColumnIndex=1; secondColumnIndex <= 7; secondColumnIndex += 3)
            {
                if(indexOfSquare[secondColumnIndex]== indexOfSquare[secondColumnIndex+leftComponent] && indexOfSquare[secondColumnIndex] == indexOfSquare[secondColumnIndex + rightComponent])
                {
                    result = CheckOX(indexOfSquare[secondColumnIndex]);
                }
            }
            for (int secondRowIndex =3 ; secondRowIndex <=5; secondRowIndex ++)
            {
                if (indexOfSquare[secondRowIndex] == indexOfSquare[secondRowIndex + upComponent] && indexOfSquare[secondRowIndex] == indexOfSquare[secondRowIndex + downComponent])
                {
                    result = CheckOX(indexOfSquare[secondRowIndex]);
                }
            }
            if ((indexOfSquare[4] == indexOfSquare[0] && indexOfSquare[4] == indexOfSquare[8]) || (indexOfSquare[4] == indexOfSquare[2] && indexOfSquare[4] == indexOfSquare[6]))
                result = CheckOX(indexOfSquare[4]);
            return result;
        }
        private int CheckOX(string square)
        {
            int firstWin = 1;
            int secondWin = 0;
            if (square == "X")
                return firstWin;
            else
                return secondWin;

        }
    }
}
