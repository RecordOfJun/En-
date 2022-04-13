using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class BasicView
    {
        public void LoginView(){
            Console.WriteLine("ID:");
            Console.WriteLine("PW:");
        }
        public void DeleteSting(int startCursorIndex,int maximumLength)
        {
            Console.SetCursorPosition(startCursorIndex, Console.CursorTop);
            Console.Write(new string(' ', maximumLength+1));
            Console.SetCursorPosition(startCursorIndex, Console.CursorTop);

        }
        public void SetInputCursor(string inputString)
        {
            Console.Write(inputString);
        }
        public void WritePassword(string inputString)
        {
            Console.Write(new string('*', inputString.Length));
        }
    }
}
