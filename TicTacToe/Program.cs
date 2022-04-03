using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            data.ShowMenu();
            for (int i = 0; i < 3; i++)
                data.PrintSqaure(i);
        }
    }
}
