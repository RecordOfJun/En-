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
        public int SelectNumber(int endNumber)// 정해진 숫자 범위를 인자로 받는 사용자 입력받기 메소드
        {
            string userInput;
            userInput = Console.ReadLine();
            while (IsParseException(userInput, endNumber) == Constant.ISEXCEPTION)//예외 발생하는 동안 계속해서 새로 입력 받기
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("다시 입력해 주세요!:");
                userInput = Console.ReadLine();
                //라인 세개 매직넘버
                ClearConsoleLine(3);
            }
            return int.Parse(userInput);//예외가 없을 경우 사용자가 입력한 숫자를 리턴
        }
        public bool IsParseException(string userInput,int endNumber)//int.Parse 예외처리를 위한 메소드
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (IsEmpty(userInput) == Constant.ISEXCEPTION)//무입력시==Enter
            {
                Console.WriteLine("공백을 입력했습니다!");
                return Constant.ISEXCEPTION;
            }
            else if (IsContainChar(userInput) == Constant.ISEXCEPTION)//문자 포함시
            {
                Console.WriteLine("자연수를 입력해주세요!");
                return Constant.ISEXCEPTION;
            }
            else if (IsTooLong(userInput) == Constant.ISEXCEPTION)//범위 초과시
            {
                Console.WriteLine("숫자가 너무 큽니다!");
                return Constant.ISEXCEPTION;
            }
            else if (int.Parse(userInput) < 1 || int.Parse(userInput) > endNumber)//전달받은 숫자 선택 범위를 벗어날 때
            {
                Console.WriteLine("1~" + endNumber + "에서 숫자를 선택해 주세요!");
                return Constant.ISEXCEPTION;
            }
            //위 경우에 한해 예외발생 리턴
            else//예외 없을 시
            {
                Console.ForegroundColor = ConsoleColor.White;
                return !Constant.ISEXCEPTION;
            }
        }

        //아래 예외처리 메소드에서 true값을 예외발생으로 일괄처리
        private bool IsContainChar(string userInput)
        {
            string[] numberToRemove = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach(var number in numberToRemove)//인풋에서 숫자 제거
            {
                userInput = userInput.Replace(number, "");//남는게 있으면 음수,실수,문자열 중에 하나임
            }
            if (userInput == "")//남는게 없으면 숫자였을 것=>enter일 수도 있기에 enter예외 먼저 따로 처리
                return !Constant.ISEXCEPTION;
            else
                return Constant.ISEXCEPTION;
        }
        private bool IsTooLong(string userInput)
        {
            int integerBoundary = 9;//int범위는 약 2x 10의 8제곱=>대략 9자리 수
            if (userInput.Length >= integerBoundary)
                return Constant.ISEXCEPTION;
            else return !Constant.ISEXCEPTION;
        }
        private bool IsEmpty(string userInput)
        {
            if (userInput == "")//공백 입력 시
                return Constant.ISEXCEPTION;
            else
                return !Constant.ISEXCEPTION;
        }
        public int CheckResult(List<string> indexOfSquare)//틱택토 게임결과 판정
        {

            int result=3;//게임 결과를 계속 진행으로 초기화
            for(int secondColumnIndex=1; secondColumnIndex <= 7; secondColumnIndex += 3)
            {//하나의 행씩 게임결과 판정
                if(indexOfSquare[secondColumnIndex]== indexOfSquare[secondColumnIndex+Constant.LEFTINDEX] && indexOfSquare[secondColumnIndex] == indexOfSquare[secondColumnIndex + Constant.RIGHTINDEX])
                {
                    result = CheckOX(indexOfSquare[secondColumnIndex]);//승패 발생 시 누구 승리인지 판별
                }
            }
            for (int secondRowIndex =3 ; secondRowIndex <=5; secondRowIndex ++)
            {//하나의 열씩 게임결과 판정
                if (indexOfSquare[secondRowIndex] == indexOfSquare[secondRowIndex + Constant.UPINDEX] && indexOfSquare[secondRowIndex] == indexOfSquare[secondRowIndex + Constant.DOWNINDEX])
                {
                    result = CheckOX(indexOfSquare[secondRowIndex]);
                }
            }
            //대각선 요소들 결과 판정
            if ((indexOfSquare[4] == indexOfSquare[0] && indexOfSquare[4] == indexOfSquare[8]) || (indexOfSquare[4] == indexOfSquare[2] && indexOfSquare[4] == indexOfSquare[6]))
                result = CheckOX(indexOfSquare[4]);
            return result;//첫번째 플레이어 승리 시 1 리턴,두번째 플레이어 승리 시 2 리턴,계속해서 진행 시 3 리턴
        }
        private int CheckOX(string square)
        {
            if (square == "X")
                return Constant.FIRSTPLAYER;
            else
                return Constant.SECONDPLAYER;

        }
        public int CheckSelected(int selectedNumber, List<int> indexOfSquare)//선택한 영역이 이미 선택되었는지 확인해주는 메소드
        {
            while (!(indexOfSquare.Exists(element => element == selectedNumber - 1)))//이미 선택된 영역에 대해 예외처리
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("이미 선택된 영역입니다! 다시 선택해 주세요!:");
                Console.ForegroundColor = ConsoleColor.White;
                selectedNumber = SelectNumber(9);//선택되지 않았을때까지 계속 선택
                Console.WriteLine("----------------------------------------------------------------------------------------");
                
                ClearConsoleLine(2);
            }
            return selectedNumber;
        }
        private void ClearConsoleLine(int numberOfLine)
        {
            Console.SetCursorPosition(0, Console.CursorTop - numberOfLine);
            int currentLineCursor = Console.CursorTop;
            for(int line=0;line<numberOfLine;line++)
                Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
