using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        Data gameData = new Data();
        Utility utility = new Utility();
        public Game()
        {
        }
        public void Start()
        {
            int seletedNumber;
            bool isStart = true;
            gameData.ShowLabel();
            gameData.ShowMenu();
            while (isStart)
            {
                seletedNumber = SelectNumber(1, 4);
                switch (seletedNumber)
                {
                    case 1:
                        PlayWithUser();
                        break;
                    case 2:
                        break;
                    case 3:
                        ShowScore();
                        break;
                    case 4:
                        ConfirmExit(-1);
                        break;
                }
                Reset();
            }
            
        }
        private void Reset()
        {
            Console.Clear();
            gameData.ShowLabel();
            gameData.ShowMenu();
            for(int index= 0; index < 9; index++)
            {
                gameData.indexOfSquare[index] = (index + 1).ToString();
            }
        }
        private int SelectNumber(int startNumber,int endNumber)
        {
            string userInput;
            bool isException = false;
            userInput = Console.ReadLine();
            while (utility.IsParseException(userInput, startNumber, endNumber) == isException)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("다시 입력해 주세요!:");
                userInput = Console.ReadLine();
            }
            return int.Parse(userInput);
        }
        private void PlayWithUser()
        {
            int keepGoing = 3;
            int gameCount = 0;
            int firstPlayer = 1;
            int selectedNumber;
            string inputToSquare;
            int gameResult = utility.CheckResult(gameData.indexOfSquare);
            while (gameResult == keepGoing)
            {
                gameCount++;
                Console.Clear();
                ShowTicTacToe();
                if (gameCount % 2 == firstPlayer)
                {
                    Console.Write("Player1  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = "O";
                }
                else
                {
                    Console.Write("Player2  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = "X";
                }
                selectedNumber = SelectNumber(1, 9);
                while(gameData.indexOfSquare[selectedNumber-1]=="O"|| gameData.indexOfSquare[selectedNumber - 1] == "X")
                {
                    Console.Write("이미 선택된 영역입니다! 다시 선택해 주세요!:");
                    selectedNumber = SelectNumber(1, 9);
                }
                gameData.indexOfSquare[selectedNumber - 1] = inputToSquare;
                gameResult = utility.CheckResult(gameData.indexOfSquare);
            }
            Console.Clear();
            ShowTicTacToe();
            Console.WriteLine("Player" + gameResult + " 승리!");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            if (gameResult == 1)
                gameData.firstPlayerWin++;
            else
                gameData.secondPlayerWin++;
            ConfirmExit(1);
        }
        private void ShowScore()
        {
            gameData.ShowLabel();
            gameData.ScoreBoard();
            ConfirmExit(1);
        }
        private void ConfirmExit(int type)
        {
            int selectedNumber;
            int afterMethod = 1;
            int selectFourth = -1;
            if (type == afterMethod)
                Console.Write("계속 하려면 1, 종료하려면 2를 입력해 주세요:");
            else
                Console.WriteLine("정말 종료하시겠습니까? 메뉴로 돌아가려면 1, 종료하려면 2를 입력해 주세요:");
            selectedNumber = SelectNumber(1, 2);
            if (selectedNumber == 2)
                return;
        }

        private void ShowTicTacToe()
        {
            int numberOfLine;
            int lastLine = 3;
            for(numberOfLine=0; numberOfLine < lastLine; numberOfLine++)
            {
                gameData.PrintSqaure(numberOfLine);
            }
        }
    }
}
