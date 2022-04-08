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
        public void NameContain(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (한글만 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void PersonalAndPhoneLength(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (양식에 맞는 글자수를 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void NumberContain(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (숫자만 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void StartWith010(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (010으로 시작해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void CheckDate(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (생년월일을 다시 확인해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void CheckGender(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (7번째 자리를 다시 확인해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void ExistedId(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (이미 존재하는 아이디 입니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void ExistedCode(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (이미 가입이 완료된 사용자 입니다!)");
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
