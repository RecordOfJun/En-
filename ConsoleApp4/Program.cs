using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string num;
            num=Console.ReadLine();
            for(int i = 0; i < int.Parse(num); i++)
            {
                for (int j = 0; j < int.Parse(num)-1-i; j++)
                    Console.Write(" ");
                for (int j = 0; j < i * 2 + 1; j++)
                    Console.Write("*");
                Console.WriteLine("");
            }
            for (int i = int.Parse(num)-1; i >=0 ; i--)
            {
                for (int j = 0; j < int.Parse(num) - 1 - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < i * 2 + 1; j++)
                    Console.Write("*");
                Console.WriteLine("");
            }
        }
    }
}
