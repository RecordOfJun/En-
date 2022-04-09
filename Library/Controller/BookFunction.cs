using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class BookFunction
    {
        VOList voList;
        UserFunction userFunction;
        ExceptionView exceptionView = new ExceptionView();
        Exception exception = new Exception();
        UI ui = new UI();
        public BookFunction(VOList voList, UserFunction userFunction)
        {
            this.voList = voList;
            this.userFunction = userFunction;
        }
        public void SearchAndChoice(int type)//책 정보 조회 및 선택 기능 메소드
        {
            string userInput = Constant.EMPTY;
            Console.Clear();
            switch (type)
            {
                case Constant.BOOK_BORROW:
                    RefreshUserBook(Constant.EMPTY);
                    break;
                case Constant.BOOK_DELETE:
                    RefreshAdminBook(Constant.EMPTY);
                    break;
                case Constant.BOOK_REVISE:
                    ReviseAdminBook(Constant.EMPTY);
                    break;
            }
            while (userInput!=Constant.ESCAPE)
            {
                userInput = InsertNameAndCode(userInput,type);
                if (userInput == Constant.ESCAPE)
                    return;
                switch (type)
                {
                    case Constant.BOOK_BORROW:
                        BorrowBook(userInput);
                        RefreshUserBook(Constant.EMPTY);
                        break;
                    case Constant.BOOK_DELETE:
                        DeleteBook(userInput);
                        RefreshAdminBook(Constant.EMPTY);
                        break;
                    case Constant.BOOK_REVISE:
                        string temp=ReviseBook(userInput);
                        ReviseAdminBook(Constant.EMPTY);
                        if (temp == Constant.ESCAPE)
                            return;
                        break;
                }
            }
        }
        private void ShowBookList(string bookName)//책 조회
        {
            foreach(BookVO book in voList.bookList.FindAll(element =>element.Name.Contains(bookName)))
            {
                ui.BookInformation(book);
            }
        }
        private void BorrowBook(string bookCode)//책 대여 메소드
        {
            if (bookCode == Constant.EMPTY)
                return;
            BookVO book = voList.bookList.Find(book => book.Id == bookCode);
            if (book != null)
            {
                int remain = book.Quantity - book.Borrowed;
                if (remain > 0)
                {
                    if (userFunction.LoginMember.IsHaveBook(book))
                    {
                        exceptionView.AlreadyHas(bookCode.Length);
                        return;
                    }
                    userFunction.LoginMember.AddBook(book);
                    book.Borrowed++;
                    exceptionView.BorrowSuccess(bookCode.Length);
                    return;
                }
                exceptionView.NotRemain(bookCode.Length);
                return;
            }
            else
            {
                exceptionView.NotExisted(bookCode.Length);
            }
        }
        private void DeleteBook(string bookCode)//책 삭제 메소드
        {
            if (bookCode == Constant.EMPTY)
                return;
            BookVO book = voList.bookList.Find(book => book.Id == bookCode);
            RefreshAdminBook(bookCode);
            if (book != null)
            {
                if (exception.IsDelete(book.Name))
                {
                    foreach(MemberVO member in voList.memberList)
                    {
                        MyBook myBook=member.borrowedBook.Find(element=>element.book==book);
                        member.RemoveBook(myBook);
                    }
                    voList.bookList.Remove(book);
                }
                return;
            }
            else
                exceptionView.NotExisted(bookCode.Length);
        }
        private string ReviseBook(string bookCode)//책 수량 설정 메소드
        {
            bool isNumber = false;
            string quantity=Constant.EMPTY;
            if (bookCode == Constant.EMPTY)
                return quantity;
            while (!isNumber) {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.QUANTITY_INDEX);
                quantity = userFunction.GetData(2, Constant.EMPTY);
                if (quantity == Constant.ESCAPE)
                    return quantity;
                isNumber = exception.IsNumber(quantity);
            }
            ReviseAdminBook(bookCode);
            BookVO book = voList.bookList.Find(book => book.Id == bookCode);
            if (book != null)
            {
                if (exception.IsRevise(book.Name))
                {
                    book.Quantity = int.Parse(quantity);
                }
                return quantity;
            }
            else
                exceptionView.NotExisted(bookCode.Length);
            return quantity;
        }
        private void ShowMyBook(string userInput)//대여중인 도서 조회 메소드
        {
            foreach (MyBook myBook in userFunction.LoginMember.borrowedBook.FindAll(element => element.book.Name.Contains(userInput)))
            {
                ui.BorrowInformation(myBook);
            }
        }
        public void ReturnBook()//반납 메소드
        {
            string userInput=Constant.EMPTY;
            while (userInput != Constant.ESCAPE)
            {
                RefreshBorrowBook(Constant.EMPTY);
                userInput = InsertNameAndCode(userInput,2);
                if (userInput == Constant.ESCAPE)
                    return;
                UpdateBookCount(userInput);
            }
        }
        private void UpdateBookCount(string Code)//책 수량 업데이트
        {
            if (Code == "")
                return;
            MyBook myBook = userFunction.LoginMember.borrowedBook.Find(element => element.book.Id == Code);
            userFunction.LoginMember.RemoveBook(myBook);
            myBook.book.Borrowed--;
        }
        private string InsertNameAndCode(string userInput, int type)//정보를 검색하고 필요정보를 입력하는메소드
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX);
            userInput = userFunction.GetData(10, Constant.EMPTY);
            if (userInput == Constant.ESCAPE)
                return userInput;
            switch (type)
            {
                case Constant.BOOK_BORROW:
                    RefreshUserBook(userInput);
                    break;
                case Constant.BOOK_RETURN:
                    RefreshBorrowBook(userInput);
                    break;
                case Constant.BOOK_DELETE:
                    RefreshAdminBook(userInput);
                    break;
                case Constant.BOOK_REVISE:
                    ReviseAdminBook(userInput);
                    break;
            }
       
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.CODE_INDEX);
            userInput = userFunction.GetData(10, Constant.EMPTY);
            return userInput;
        }
        private void RefreshUserBook(string input)//RESPREAD VIEW
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.SearchGuide();
            ShowBookList(input);
        }
        private void RefreshAdminBook(string input)
        {
            Console.Clear();
            ui.AdminLabel();
            ui.SearchGuide();
            ShowBookList(input);
        }
        private void ReviseAdminBook(string input)
        {
            Console.Clear();
            ui.AdminLabel();
            ui.ReviseGuide();
            ShowBookList(input);
        }
        private void RefreshBorrowBook(string input)
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.ReturnGuide();
            ShowMyBook(input);
        }
    }
}
