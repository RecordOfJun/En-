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
        public void SearchAndChoice(int type)
        {
            string userInput = "";
            Console.Clear();
            switch (type)
            {
                case 1:
                    RefreshUserBook("");
                    break;
                case 3:
                    ui.AdminLabel();
                    ui.DeleteGuide();
                    break;
                case 4:
                    ui.AdminLabel();
                    ui.ReviseGuide();
                    break;
            }
            ShowBookList(userInput);
            while (userInput!=Constant.ESCAPE)
            {
                userInput = InsertNameAndCode(userInput,type);
                if (userInput == Constant.ESCAPE)
                    return;
                switch (type)
                {
                    case 1:
                        BorrowBook(userInput);
                        break;
                    case 3:
                        DeleteBook(userInput);
                        break;
                    case 4:
                        string temp=ReviseBook(userInput);
                        if (temp == Constant.ESCAPE)
                            return;
                        break;
                }
                RefreshUserBook("");
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
        private void DeleteBook(string bookCode)
        {
            if (bookCode == "")
                return;
            BookVO book = voList.bookList.Find(book => book.Id == bookCode);
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
        private string ReviseBook(string bookCode)
        {
            bool isNumber = false;
            string quantity=Constant.EMPTY;
            while (!isNumber) {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.QUANTITY_INDEX);
                quantity = userFunction.GetData(2, Constant.EMPTY);
                if (quantity == Constant.ESCAPE)
                    return quantity;
                isNumber = exception.IsNumber(quantity);
            }
            if (bookCode == "")
                return quantity;
            Console.Clear();
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
        private void ShowMyBook(string userInput)
        {
            foreach (MyBook myBook in userFunction.LoginMember.borrowedBook.FindAll(element => element.book.Name.Contains(userInput)))
            {
                ui.BorrowInformation(myBook);
            }
        }
        public void ReturnBook()
        {
            string userInput=Constant.EMPTY;
            while (userInput != Constant.ESCAPE)
            {
                RefreshBorrowBook("");
                userInput = InsertNameAndCode(userInput,2);
                if (userInput == Constant.ESCAPE)
                    return;
                UpdateBookCount(userInput);
            }
        }
        private void UpdateBookCount(string Code)
        {
            if (Code == "")
                return;
            MyBook myBook = userFunction.LoginMember.borrowedBook.Find(element => element.book.Id == Code);
            userFunction.LoginMember.RemoveBook(myBook);
            myBook.book.Borrowed--;
        }
        private string InsertNameAndCode(string userInput, int type)
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX);
            userInput = userFunction.GetData(10, Constant.EMPTY);
            if (userInput == Constant.ESCAPE)
                return userInput;
            switch (type)
            {
                case 1:
                    RefreshUserBook(userInput);
                    break;
                case 2:
                    RefreshBorrowBook(userInput);
                    break;
                case 4:
                    ReviseAdminBook(userInput);
                    break;
            }
       
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.CODE_INDEX);
            userInput = userFunction.GetData(10, Constant.EMPTY);
            return userInput;
        }
        private void RefreshUserBook(string input)
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
