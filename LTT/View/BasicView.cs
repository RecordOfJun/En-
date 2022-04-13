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
        public void DeleteString(int startCursorIndexOfX, int startCursorIndexOfY,int maximumLength)
        {
            Console.SetCursorPosition(startCursorIndexOfX, startCursorIndexOfY);
            Console.Write(new string(' ', maximumLength+1));
            Console.SetCursorPosition(startCursorIndexOfX, startCursorIndexOfY);

        }
        public void SetInputCursor(string inputString)
        {
            Console.Write(inputString);
        }
        public void WritePassword(string inputString)
        {
            Console.Write(new string('*', inputString.Length));
        }
        public void ShowAgain()
        {
            Console.Write("  다시 로그인  프로그램 종료");
        }
    }
}
