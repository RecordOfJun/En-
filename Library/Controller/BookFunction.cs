using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class BookFunction
    {
        List<BookVO> bookList;
        UserFunction userFunction;
        UI ui = new UI();
        public BookFunction(List<BookVO> bookList, UserFunction userFunction)
        {
            this.bookList = bookList;
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
                Console.Clear();
                ui.LibraryLabel();
                ui.SearchGuide();
                ShowBookList(userInput);
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.BORROW_INDEX);
                userInput = userFunction.GetData(10);

                userInput = "";
            }
        }
        public void ShowBookList(string bookName)
        {
            foreach(BookVO book in bookList.FindAll(element =>element.Name.Contains(bookName)))
            {
                ui.BookInformation(book);
            }
        }
    }
}
