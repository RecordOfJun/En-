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
            int vsPlayer=1;
            gameData.ShowMenu();
            seletedNumber = SelectNumber(1,3);
            
            switch (seletedNumber)
            {
                case 1:
                    Console.Clear();
                    PlayWithUser();
                    break;
                case 2:
                    break;
                case 3:
                    return;
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
                Console.Write("메뉴번호 입력&엔터=>");
                userInput = Console.ReadLine();
            }
            return int.Parse(userInput);
        }
        private void PlayWithUser()
        {
            ShowTicTacToe();
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
