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
        public void NotIdentical(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (비밀번호를 동일하게 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void CanNotLogin(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (아이디와 비밀번호를 확인해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
            ClearLine(Console.CursorTop);
        }
        public void BorrowSuccess(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  (대여가 완료되었습니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
            ClearLine(Console.CursorTop);
        }
        public void DeleteSuccess(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  (삭제 완료되었습니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
            ClearLine(Console.CursorTop);
        }
        public void NotExisted(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (코드와 일치하는 도서가 존재하지 않습니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
            ClearLine(Console.CursorTop);
        }
        public void NotExistedMember(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (주민번호가 일치하는 유저가 존재하지 않습니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
            ClearLine(Console.CursorTop);
        }
        public void NotRemain(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (남은 수량이 없어 대여할 수 없습니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
            ClearLine(Console.CursorTop);
        }
        public void AlreadyHas(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (이미 이 도서를 대여 하셨습니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
            ClearLine(Console.CursorTop);
        }
        public void AdminError(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (틀렸습니다! 다시 입력해 주세요!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void ClearLine(int index)
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
        }
        public void AskEscape()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("     메인 메뉴로 복귀하면 자동으로 로그아웃이 됩니다. 정말 돌아가시겠습니까?");
            Console.WriteLine("  메뉴로 가길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
        public void AskExit()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                            정말 종료하시겠습니까?");
            Console.WriteLine("    종료하길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
        public void AskDelete(string name)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                   {0}을 정말 삭제하시겠습니까?",name);
            Console.WriteLine("    삭제하길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
        public void AskRevise(string name)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                   {0}의 수량을 정말 수정하시겠습니까?", name);
            Console.WriteLine("    수정하길 원하시면 엔터, 그렇지 않으면 엔터키를 제외한 아무키나 눌러주세요.");
        }
        public void EmptyString()
        {
            int printLocation = Constant.ADD_INDEX;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (아무것도 입력하지 않았습니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
        public void ExistedBookId(int length)
        {
            int printLocation = Constant.ADD_INDEX + length;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  (이미 존재하는 도서번호 입니다!)");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Constant.TWO_SECOND);
        }
    }
}
