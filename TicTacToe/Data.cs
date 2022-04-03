using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Data
    {
        public List<string> indexOfSquare = new List<string> { "X", "2", "O", "4", "5", "6", "7", "8", "9" };//틱택토 인덱스 번호,플레이어 선택 상태
        public Data()
        {
        }
        public void PrintSqaure(int numOfLine)//틱택토 3x1 한줄 출력 메소드
        {
            int leftSquareNum = numOfLine*3;
            int middleSquareNum = numOfLine * 3 + 1;
            int rightSquareNum = numOfLine * 3 + 2;
            if (numOfLine==0)
                Console.WriteLine("###########################################");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("#             #             #             #");
            Console.Write("#      ");
            CheckSelected(indexOfSquare[leftSquareNum]);
            Console.Write("      #      "); 
            CheckSelected(indexOfSquare[middleSquareNum]);
            Console.Write("      #      ");
            CheckSelected(indexOfSquare[rightSquareNum]);
            Console.WriteLine("      #");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("###########################################");
        }
        private void CheckSelected(string squareLocation )
        {
            if (squareLocation == "O")
                Console.ForegroundColor = ConsoleColor.Red;
            else if (squareLocation == "X")
                Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(squareLocation);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowMenu()
        {
            Console.WriteLine(" #########  #     ###     #########      #        ###    #########     ##      ######## ");
            Console.WriteLine("     #      #    #            #         # #      #           #        #  #     #        ");
            Console.WriteLine("     #      #   #             #        #####    #            #       #    #    ######## ");
            Console.WriteLine("     #      #    #            #       #     #    #           #        #  #     #        ");
            Console.WriteLine("     #      #     ###         #      #       #    ###        #         ##      ######## ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                 메뉴를 선택해 주세요!                                    ");
            Console.WriteLine("                                1. Player1 vs Player2                                     ");
            Console.WriteLine("                                2. Player vs Computer                                     ");
            Console.WriteLine("                                3.    SocreBoard                                          ");
        }
    }
}
