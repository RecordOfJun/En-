using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            for (int i = 0; i < 3; i++)
                data.Sqaure(i);
        }
    }
}
