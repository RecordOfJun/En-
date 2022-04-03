using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Data
    {
        public List<string> indexOfSquare = new List<string> { "X", "2", "O", "4", "5", "6", "7", "8", "9" };
        public Data()
        {
        }
        public void Sqaure(int numOfLine)
        {
            int leftSquareNum = numOfLine*3;
            int middleSquareNum = numOfLine * 3 + 1;
            int rightSquareNum = numOfLine * 3 + 2;
            if (numOfLine==0)
                Console.WriteLine("###########################################");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("#      "+indexOfSquare[leftSquareNum] + "      #      " + indexOfSquare[middleSquareNum] + "      #      " + indexOfSquare[rightSquareNum] + "      #");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("###########################################");
        }
    }
}
