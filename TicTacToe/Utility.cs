using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Utility
    {
        public Utility()
        {

        }
        public int CheckException(string userInput)
        {
            string needToCheck = userInput;
            string[] numberToRemove = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach(var number in numberToRemove)
            {
                needToCheck = needToCheck.Replace(number, "");
            }
            Console.WriteLine("@"+needToCheck+"@");
            if (needToCheck == "")
                return 0;
            else
                return -1;
        }
    }
}
