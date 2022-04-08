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
        UI ui = new UI();
        public BookFunction(VOList voList, UserFunction userFunction)
        {
            this.voList = voList;
            this.userFunction = userFunction;
        }
        public void SearchAndBrrow()
        {
            string userInput = "";
            Console.Clear();
            ui.LibraryLabel();
            ui.SearchGuide();
            ShowBookList(userInput);
            while (userInput!=Constant.ESCAPE)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX);
                userInput = userFunction.GetData(10);
                if (userInput == Constant.ESCAPE)
                    return;
                Console.Clear();
                ui.LibraryLabel();
                ui.SearchGuide();
                ShowBookList(userInput);
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.BORROW_INDEX);
                userInput = userFunction.GetData(10);
                if (userInput == Constant.ESCAPE)
                    return;
                BorrowBook(userInput);
            }
        }
        private void ShowBookList(string bookName)
        {
            foreach(BookVO book in voList.bookList.FindAll(element =>element.Name.Contains(bookName)))
            {
                ui.BookInformation(book);
            }
        }
        private void BorrowBook(string bookCode)
        {
            if (bookCode == "")
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
        public void ShowMyBook()
        {
            Console.Clear();
            ui.LibraryLabel();
            foreach (MyBook myBook in userFunction.LoginMember.borrowedBook)
            {
                ui.BorrowInformation(myBook);
            }
            Console.ReadLine();
        }
        private void ReturnBook()
        {

        }
    }
}
