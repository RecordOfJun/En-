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
                        ConfirmExit();
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
                Console.WriteLine("----------------------------------------------------------------------------------------");
                while (gameData.indexOfSquare[selectedNumber-1]=="O"|| gameData.indexOfSquare[selectedNumber - 1] == "X")
                {
                    Console.Write("이미 선택된 영역입니다! 다시 선택해 주세요!:");
                    selectedNumber = SelectNumber(1, 9);
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                }
                gameData.indexOfSquare[selectedNumber - 1] = inputToSquare;
                gameResult = utility.CheckResult(gameData.indexOfSquare);
                if (gameCount >= 9 && gameResult == keepGoing)
                {
                    gameResult = 0;
                }
            }
            Console.Clear();
            ShowTicTacToe();
            if(gameResult==firstPlayer||gameResult==firstPlayer+1)
                Console.WriteLine("Player" + gameResult + " 승리!");
            else
                Console.WriteLine("무승부 입니다!");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            if (gameResult == 1)
                gameData.firstPlayerWin++;
            else
                gameData.secondPlayerWin++;
            AfterMethod();
        }
        private void ShowScore()
        {
            Console.Clear();
            gameData.ShowLabel();
            gameData.ScoreBoard();
            AfterMethod();
        }
        private void ConfirmExit()
        {
            int selectedNumber;
            int afterMethod = 1;
            int selectFourth = -1;
            Console.Write("정말 종료하시겠습니까?  맞으면 1, 아니면 2를 입력해 주세요: ");
            selectedNumber = SelectNumber(1, 2);
            Console.WriteLine("----------------------------------------------------------------------------------------");
            if (selectedNumber == 1)
            {
                Console.WriteLine("프로그램을 종료합니다.");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Environment.Exit(0);
            }
        }
        private void AfterMethod()
        {
            Console.Write("게임을 종료하고 싶으면 1, 메뉴로 돌아가고 싶으면 2를 입력해 주세요:");
            if (SelectNumber(1, 2) == 1)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                ConfirmExit();
            }
                   
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
