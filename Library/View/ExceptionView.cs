using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Library.View
{
    class ExceptionView
    {
        public ExceptionView()
        {

        }
        public void IdPasswordLength(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (6~10 글자만 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);

        }
        public void IdPasswordContain(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop );
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (영어와 숫자만 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void IdPasswordNotContain(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (영어와 숫자를 혼합해 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void ClearLine(int index)
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
        }
    }
}
