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
            string userInput;
            int seletedNumber;
            int vsPlayer=1;
            gameData.ShowMenu();
            for (int i = 0; i < 10; i++)
            {
                userInput = Console.ReadLine();
                Console.WriteLine(utility.IsContainChar(userInput));
            }
            /*
            switch (userInput)
            {
                case "1":
                    PlayWithUser();
                    break;
                case "2":
                    break;
                case "3":
                    return;
            }
            */
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
