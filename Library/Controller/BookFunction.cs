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
        UI ui = new UI();
        public BookFunction(List<BookVO> bookList)
        {
            this.bookList = bookList;
        }
        public void ShowBookList()
        {
            string bookName = Console.ReadLine();
            foreach(BookVO book in bookList.FindAll(element =>element.Name.Contains(bookName)))
            {
                ui.BookInformation(book);
            }
        }
    }
}
