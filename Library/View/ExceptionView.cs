﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Library.View
{
    class ExceptionView
    {
        BasicView basicView = new BasicView();
        public ExceptionView()
        {

        }
        private void ReadAndErase(int leftCusor, int eraseLength)//예외 안내문 제거 함수
        {
            Console.ReadKey();
            basicView.DeleteString(leftCusor, Console.CursorTop, eraseLength);
        }
        private void SearchException(int inputLength,string insert)
        {
            int printLocation = inputLength + Constant.DATA_INSERT_CURSOR;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
            ReadAndErase(Constant.DATA_INSERT_CURSOR, 50);
        }
        private void InsertException(int inputLength, string insert)
        {
            int printLocation = inputLength + Constant.ADD_INDEX+2;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
            ReadAndErase(printLocation, 50);
        }
        private void SearchComplete(int inputLength, string insert)
        {
            int printLocation = inputLength + Constant.DATA_INSERT_CURSOR;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
            ReadAndErase(printLocation, 50);
        }
        private void InsertComplete(int inputLength, string insert)
        {
            int printLocation = inputLength + Constant.ADD_INDEX+2;
            Console.SetCursorPosition(printLocation, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(insert);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void SignUpException()
        {
            InsertException(20, "  (정보를 다 입력해주세요!)");
        }
        public void QuantityAddException(int length)
        {
            InsertException(length, "  (0보다 큰 숫자를 입력해 주세요!)");
        }
        public void QuantityReviseException(int length)
        {
            SearchException(length, "  (0보다 큰 숫자를 입력해 주세요!)");
        }
        public void IdPasswordLength(int length)
        {
            InsertException(length, "  (6~10 글자로 입력해 주세요!)");
        }
        public void IdPasswordContain(int length)
        {
            InsertException(length, "  (영어와 숫자만 입력해 주세요!)");
        }
        public void IdPasswordNotContain(int length)
        {
            InsertException(length, "  (영어와 숫자를 혼합해 입력해 주세요!)");
        }
        public void NameContain(int length)
        {
            InsertException(length, "  (한글만 입력해 주세요!)");
        }
        public void PersonalAndPhoneLength(int length)
        {
            InsertException(length, "  (양식에 맞는 글자수를 입력해 주세요!)");
        }
        public void NumberContain(int length)
        {
            InsertException(length, "  (숫자만 입력해 주세요!)");
        }
        public void StartWith010(int length)
        {
            InsertException(length, "  (010으로 시작해 주세요!)");
        }
        public void CheckDate(int length)
        {
            InsertException(length, "  (생년월일을 다시 확인해 주세요!)");
        }
        public void CheckGender(int length)
        {
            InsertException(length, "  (7번째 자리를 다시 확인해 주세요!)");
        }
        public void ExistedId(int length)
        {
            InsertException(length, "  (이미 존재하는 아이디 입니다!)");
        }
        public void ExistedCode(int length)
        {
            InsertException(length, "  (이미 가입이 완료된 사용자 입니다!)");
        }
        public void NotIdentical(int length)
        {
            InsertException(length, "  (비밀번호를 동일하게 입력해 주세요!)");
        }
        public void CanNotLogin(int length)
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            InsertException(0, "(아이디와 비밀번호를 확인해 주세요!)");

        }
        public void BorrowSuccess(int length)
        {
            SearchComplete(length, "  (대여가 완료되었습니다!)");
        }
        public void DeleteSuccess(int length)
        {
            SearchComplete(length, "  (삭제가 완료되었습니다!))");
        }
        public void ReturnSuccess(int length)
        {
            SearchComplete(length, "  (반납이 완료되었습니다!))");
        }
        public void InsertSuccess(int length)
        {
            InsertComplete(length, "  (완료되었습니다!))");
        }
        public void NotExisted(int length)
        {
            SearchException(length, "  (일치하는 정보가 존재하지 않습니다!)");
        }
        public void NotExistedMember(int length)
        {
            SearchException(length, "  (일치하는 유저가 존재하지 않습니다!)");
        }
        public void NotRemain(int length)
        {
            SearchException(length, "  (남은 수량이 없어 대여할 수 없습니다!)");
        }
        public void AlreadyHas(int length)
        {
            SearchException(length, "  (이미 이 도서를 대여 하셨습니다!)");
        }
        public void AdminError(int length)
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            InsertException(0, "(틀렸습니다! 다시 입력해 주세요!)");
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
            Console.WriteLine("뒤          뒤로 돌아가면 자동으로 로그아웃이 됩니다. 정말 돌아가시겠습니까?");
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
            InsertException(0, "(아무것도 입력하지 않았습니다!)");
        }
        public void ExistedBookId(int length)
        {
            InsertException(length,  "(이미 존재하는 도서번호 입니다!)");
        }
        public void ValidAdress(int length)
        {
            InsertException(length, "(주소 양식을 확인해 주세요!)");
        }
    }
}
