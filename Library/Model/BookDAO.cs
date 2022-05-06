using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Library.Model;
using Library.View;
using System.Linq;
namespace Library.Model
{
    class BookDAO
    {
        private static BookDAO bookDAO;
        MySqlConnection connection;
        MySqlCommand command;
        Book bookUI = new Book();
        string query;
        private BookDAO()
        {
            connection = new MySqlConnection(Constant.SERVER_DATA);
        }
        public static BookDAO GetDBConnection()
        {
            if (bookDAO == null)
                bookDAO = new BookDAO();
            return bookDAO;
        }
        public void InsertBook(BookDTO book)//도서 추가
        {
            connection.Open();
            query = "";
            query += Constant.INSERT_BOOK;
            query += book.Name + "','" + book.Publisher + "','" + book.Author + "'," + book.Price + "," + book.Quantity + ",'" + book.Isbn + "','" + book.Pubdate + "','" + book.Description + "');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateBook(int quantity, string id)//도서 수량 조정
        {
            connection.Open();
            query = "";
            query += "Update book Set ";
            query += "quantity=" + quantity + " ";
            query += "where id='" + id + "';";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBook(string id)//도서 삭제
        {
            connection.Open();
            query = "";
            query += "delete from book ";
            query += "where id='" + id + "';";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void SelectBook(string name, string author, string publisher, List<BookDTO> bookList, int type)//책 조회
        {
            connection.Open();
            query = "";
            query += "SELECT * from book ";
            query += "where name like '%" + name + "%' and ";
            query += "author like '%" + author + "%' and ";
            query += "publisher like '%" + publisher + "%' ";
            query += "order by id; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //검색한 책 정보 불러오기
                BookDTO book = new BookDTO(reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()), reader["isbn"].ToString(), reader["description"].ToString(), DateTime.Parse(reader["pubdate"].ToString()).ToString("yyyy-MM-dd"), reader["id"].ToString());
                bookList.Add(book);
            }
            connection.Close();
            foreach (BookDTO book in bookList)
                book.Borrowed = NumberOfBorrowed(Constant.BORROW_COUNT_BOOK, book.Id);
            if (type == Constant.USER_BOOK || type == Constant.ADMIN_BOOK)
            {
                foreach (BookDTO book in bookList)
                    bookUI.BookInformation(book, type);
            }
            else
            {
                bookList = bookList.OrderByDescending(book => book.Borrowed).ToList();
                for(int count=0;count<5;count++)
                    bookUI.BookInformation(bookList[count], type);
            }
        }
        public int NumberOfBorrowed(string sqlQuery, string id)//대여 수량 찾기
        {
            int count = 0;
            connection.Open();
            query = "";
            query += sqlQuery;
            query += id + ";";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                count = int.Parse(reader["COUNT(*)"].ToString());
            connection.Close();
            return count;
        }
        public void InsertBorrow(string bookId, string code)//도서 대여
        {
            connection.Open();
            query = "";
            query += "Insert into borrowed values ('";
            query += bookId + "'," + code + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss") + "');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBorrow(string bookId, string code, int type)//도서 반납
        {
            connection.Open();
            query = "";
            query += "delete from borrowed ";
            query += "where bookid='" + bookId + "' ";
            if (type == Constant.DELETE_BORROW)
                query += "and membercode=" + code + ";";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void SelectBorrow(string name, string author, string publisher, string code, List<BookDTO> bookList)//대여정보 출력
        {
            string borrowTime;
            string returnTime;
            connection.Open();
            query = "";
            query += Constant.SELECT_BORROW + code + ") as B ";
            query += "where book.name like '%" + name + "%' and ";
            query += "book.author like '%" + author + "%' and ";
            query += "book.publisher like '%" + publisher + "%' and ";
            query += "book.id = B.bookid ";
            query += "order by B.returntime ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {//빌린 책의 정보와 빌린 시간, 반납시간을 가져와 출력
                BookDTO book = new BookDTO(reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()), reader["isbn"].ToString(), reader["description"].ToString(), reader["pubdate"].ToString(), reader["id"].ToString());
                borrowTime = reader["borrowtime"].ToString().Substring(0, 10); 
                returnTime=reader["returntime"].ToString().Substring(0, 10);//db에는 정상적으로 저장 다시 불러올때 값 이상함
                bookUI.BorrowInformation(book,borrowTime,returnTime);
                bookList.Add(book);
            }
            connection.Close();
        }
        public bool IsExistedBookIsbn(string isbn)//도서 ID 중복확인
        {
            connection.Open();
            query = "";
            query += "select * from book ";
            query += "where isbn='" + isbn + "';";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            connection.Close();
            return result;
        }
    }
}
