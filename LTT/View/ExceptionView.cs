using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class ExceptionView
    {
        public void ShowException(string insert)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(insert);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
