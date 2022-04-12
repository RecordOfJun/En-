using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class BookService
    {
        VOList voList;
        User userFunction;
        ExceptionView exceptionView;
        Exception exception;
        List<BookVO> bookList;
        List<MyBook> myBookList;
        UI ui;
        public BookService(VOList voList, User userFunction,ExceptionAndView exceptionAndView)
        {
            exception = exceptionAndView.exception;
            ui = exceptionAndView.ui;
            exceptionView = exceptionAndView.exceptionView;
            this.voList = voList;
            this.userFunction = userFunction;
        }
        public void SearchAndChoice(int type)//책 정보 조회 및 선택 기능 메소드
        {
            string userInput = Constant.EMPTY;
            Console.Clear();
            SpreadBook(type, Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            while (userInput!=Constant.ESCAPE)
            {
                userInput = InsertNameAndCode(userInput,type);
                if (userInput == Constant.ESCAPE)
                    return;
                switch (type)
                {
                    case Constant.BOOK_BORROW:
                        BorrowBook(userInput);
                        break;
                    case Constant.BOOK_DELETE:
                        DeleteBook(userInput);
                        break;
                    case Constant.BOOK_REVISE:
                        ReviseBook(userInput);
                        break;
                    case 5:
                        break;
                }
            }
        }
        private void ShowBookList(string name,string author,string publisher)//책 조회
        {
            List<BookVO> findList = new List<BookVO>();
            foreach (BookVO book in voList.bookList.FindAll(element => element.Name.Contains(name)&&element.Publisher.Contains(publisher) && element.Author.Contains(author)))
            {
                findList.Add(book);
                ui.BookInformation(book);
            }
            bookList = findList;
        }
        private void BorrowBook(string bookCode)//책 대여 메소드
        {
            if (bookCode == Constant.EMPTY)
                return;
            BookVO book = bookList.Find(book => book.Id == bookCode);
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
        private void DeleteBook(string bookCode)//책 삭제 메소드
        {
            if (bookCode == Constant.EMPTY)
                return;
            BookVO book = bookList.Find(book => book.Id == bookCode);
            RefreshAdminBook("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer");
            if (exception.IsDelete(book.Name))
            {
                foreach (MemberVO member in voList.memberList)
                {
                    MyBook myBook = member.borrowedBook.Find(element => element.book == book);
                    member.RemoveBook(myBook);
                }
                voList.bookList.Remove(book);
                exceptionView.DeleteSuccess(bookCode.Length);
            }
        }
        private void ReviseBook(string bookCode)//책 수량 설정 메소드
        {
            if (bookCode == Constant.EMPTY)
                return ;
            bool isNumber = false;
            string quantity=Constant.EMPTY;
            while (!isNumber) {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.QUANTITY_INDEX);
                quantity = userFunction.GetData(2, Constant.EMPTY);
                if (quantity == Constant.ESCAPE)
                    return;
                isNumber = exception.IsNumber(quantity);
                if (quantity == "0")
                {
                    isNumber = Constant.IS_EXCEPTION;
                    exceptionView.QuantityException(quantity.Length);
                }
            }
            ReviseAdminBook("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer");
            BookVO book = bookList.Find(book => book.Id == bookCode);
            if (exception.IsRevise(book.Name))
            {
                book.Quantity = int.Parse(quantity);
            }
            return;
        }
        private void ShowMyBook(string name, string author, string publisher)//대여중인 도서 조회 메소드
        {
            List<BookVO> findList = new List<BookVO>();
            foreach (MyBook myBook in userFunction.LoginMember.borrowedBook.FindAll(element => element.book.Name.Contains(name) || element.book.Name.Contains(publisher) || element.book.Name.Contains(author)))
            {
                findList.Add(myBook.book);
                ui.BorrowInformation(myBook);
            }
            bookList = findList;
        }
        public void ReturnBook()//반납 메소드
        {
            string userInput=Constant.EMPTY;
            RefreshBorrowBook(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            while (userInput != Constant.ESCAPE)
            {
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
            if (myBook != null)
            {
                userFunction.LoginMember.RemoveBook(myBook);
                myBook.book.Borrowed--;
                exceptionView.ReturnSuccess(Code.Length);
            }
            else
                exceptionView.NotExisted(Code.Length);

        }
        private string InsertNameAndCode(string userInput, int type)//정보를 검색하고 필요정보를 입력하는메소드
        {
            string name = Constant.EMPTY;
            string author = Constant.EMPTY;
            string publisher = Constant.EMPTY;
            ConsoleKeyInfo key;
            bool isKey = false;
            //제목,작가명,출판사로 검색을 가능하게 함
            while (!isKey) {
                Console.SetCursorPosition(Constant.ADD_INDEX, 10);
                key = Console.ReadKey();
                Console.SetCursorPosition(Constant.ADD_INDEX, 10);
                Console.Write("  ");
                isKey = true;
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        name = GetBookData(type, 0);
                        break;
                    case ConsoleKey.D2:
                        author = GetBookData(type, 2);
                        break;
                    case ConsoleKey.D3:
                        publisher = GetBookData(type, 4);
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        return Constant.ESCAPE;
                    default:
                        isKey = false;
                        break;
                }
            }
            if (name == Constant.ESCAPE|| author == Constant.ESCAPE|| publisher == Constant.ESCAPE)
                return Constant.ESCAPE;
            SpreadBook(type,name,author,publisher);
            if (type != 5)
            {
                bool isExisted = Constant.IS_EXCEPTION;
                while (!isExisted)
                {
                    Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX + 6);
                    userInput = userFunction.GetData(10, Constant.EMPTY);
                    if (userInput == Constant.EMPTY || userInput==Constant.ESCAPE)
                        return userInput;
                    isExisted = true;
                    if (!bookList.Exists(book => book.Id == userInput))
                    {
                        isExisted = false;
                        exceptionView.NotExisted(userInput.Length);
                    }
                }
            }
            return userInput;
        }
        private string GetBookData(int type,int cursor)
        {
            SpreadBook(type, Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX+cursor);
            string input = userFunction.GetData(10, Constant.EMPTY);
            return input;
        }
        private void SpreadBook(int type,string name, string author, string publisher)
        {
            switch (type)
            {
                case Constant.BOOK_BORROW:
                    RefreshUserBook(name, author, publisher);
                    break;
                case Constant.BOOK_RETURN:
                    RefreshBorrowBook(name, author, publisher);
                    break;
                case Constant.BOOK_DELETE:
                    RefreshAdminBook(name, author, publisher);
                    break;
                case Constant.BOOK_REVISE:
                    ReviseAdminBook(name, author, publisher);
                    break;
                case 5:
                    RefreshSearchBook(name, author, publisher);
                    break;
            }
        }
        private void RefreshSearchBook(string name, string author, string publisher)//RESPREAD VIEW
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.SearchGuide();
            ShowBookList(name, author, publisher);
        }
        private void RefreshUserBook(string name, string author, string publisher)//RESPREAD VIEW
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.BorrowGuide();
            ShowBookList(name, author, publisher);
        }
        private void RefreshAdminBook(string name, string author, string publisher)
        {
            Console.Clear();
            ui.AdminLabel();
            ui.BorrowGuide();
            ShowBookList(name, author, publisher);
        }
        private void ReviseAdminBook(string name, string author, string publisher)
        {
            Console.Clear();
            ui.AdminLabel();
            ui.ReviseGuide();
            ShowBookList(name,author,publisher);
        }
        private void RefreshBorrowBook(string name, string author, string publisher)
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.ReturnGuide();
            ShowMyBook(name, author, publisher);
        }
    }
}
