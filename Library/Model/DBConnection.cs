using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Library.Model;
using Library.View;
namespace Library
{
    class DBConnection
    {
        private static DBConnection dBConnection;
        MySqlConnection connection;
        MySqlCommand command;
        BasicView basicView = new BasicView();
        string query;
        private DBConnection()
        {
            connection = new MySqlConnection(Constant.SERVER_DATA);
        }
        public static DBConnection GetDBConnection()
        {
            if (dBConnection == null)
                dBConnection = new DBConnection();
            return dBConnection;
        }
        public void InsertMember(MemberVO member)
        {
            connection.Open();
            query = "";
            query += "Insert into member (id,password,name,personalcode,phone,adress) ";
            query += "values ('";
            query += member.Id + "','" + member.Password + "','" + member.Name + "','" + member.PersonalCode + "','" + member.PhoneNumber + "','" + member.Address + "');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateMember(MemberVO member,string code)
        {
            connection.Open();
            query = "";
            query += "Update member Set ";
            query += "password='" + member.Password + "',";
            query += "name='" + member.Name + "',";
            query += "phone='" + member.PhoneNumber + "',";
            query += "adress='" + member.Address + "'  ";
            query += "where membercode=" + code + ";";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteMember(string code)
        {
            connection.Open();
            query = "";
            query += "delete from member ";
            query += "where membercode=" + code + ";";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void SelectMember(string id,string name, string phone,List<MemberVO> memberList)
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where id like '%" + id + "%' and ";
            query += "name like '%" + name + "%' and ";
            query += "phone like '%" + phone + "%'  ";
            query += "and name <> 'Adm';";

            command = new MySqlCommand(query, connection);
            MySqlDataReader reader=command.ExecuteReader();
            while (reader.Read())
            {
                MemberVO member = new MemberVO(reader["id"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["phone"].ToString(), reader["adress"].ToString(), reader["personalcode"].ToString(), reader["membercode"].ToString());
                basicView.MemberInformation(member);
                memberList.Add(member);
            }
            connection.Close();
        }

        public MemberVO SelectAdmin()
        {
            connection.Open();
            query = "";
            query += "SELECT id,password from member ";
            query += "where name = 'Adm';";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            MemberVO admin = new MemberVO();
            while (reader.Read())
            {
                admin.Id = reader["id"].ToString();
                admin.Password = reader["password"].ToString();
            }
            connection.Close();
            return admin;
        }

        public void InsertBook(BookVO book)
        {
            connection.Open();
            query = "";
            query += "Insert into book values ('";
            query += book.Id + "','" + book.Name + "','" + book.Publisher + "','" + book.Author + "'," + book.Price + "," + book.Quantity + ");";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateBook(int quantity,string id)
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
        public void DeleteBook(string id)
        {
            connection.Open();
            query = "";
            query += "delete from book ";
            query += "where id='" + id + "';";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void SelectBook(string name, string author, string publisher,List<BookVO> bookList)
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
                BookVO book = new BookVO(reader["id"].ToString(), reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()));
                bookList.Add(book);
            }
            connection.Close();
            foreach(BookVO book in bookList)
            {
                book.Borrowed = NumberOfBorrowed(book.Id);
                basicView.BookInformation(book);
            }
        }
        private int NumberOfBorrowed(string bookid)
        {
            int count=0;
            connection.Open();
            query = "";
            query += "SELECT COUNT(*) FROM borrowed where bookid=";
            query += bookid + ";";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
                count = int.Parse(reader["COUNT(*)"].ToString());
            connection.Close();
            return count;
        }
        public void InsertBorrow(string bookId,string code)
        {
            connection.Open();
            query = "";
            query += "Insert into borrowed values ('";
            query += bookId+"',"+code+ ",'"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"','"+DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss") +"');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBorrow(string bookId,string code,int type)
        {
            connection.Open();
            query = "";
            query += "delete from borrowed ";
            query += "where bookid='" + bookId + "' ";
            if(type==Constant.DELETE_BORROW)
                query += "and membercode=" + code + ";";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void SelectBorrow(string name, string author, string publisher,string code,List<BookVO> bookList)
        {
            connection.Open();
            query = "";
            query += "SELECT book.*,B.borrowtime,B.returntime from book,( select * from borrowed where membercode=" + code + ") as B ";
            query += "where book.name like '%" + name + "%' and ";
            query += "book.author like '%" + author + "%' and ";
            query += "book.publisher like '%" + publisher + "%' and ";
            query += "book.id = B.bookid ";
            query += "order by B.returntime ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookVO book = new BookVO(reader["id"].ToString(), reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()));
                MyBook borrowBook = new MyBook(book, reader["borrowtime"].ToString().Substring(0,10), reader["returntime"].ToString().Substring(0, 10));//db에는 정상적으로 저장 다시 불러올때 값 이상함
                basicView.BorrowInformation(borrowBook);
                bookList.Add(book);
            }
            connection.Close();
        }
        public MemberVO FindUser(string id,string password)
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where id='" + id + "' and ";
            query += "password= '" + password + "';";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            MemberVO member=null;
            while (reader.Read())
                member=new MemberVO(reader["id"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["phone"].ToString(), reader["adress"].ToString(), reader["personalcode"].ToString(), reader["membercode"].ToString());
            connection.Close();
            return member;
        }
        public bool IsExistedId(string id)
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where id='"+id+"'; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            connection.Close();
            return result;
        }
        public bool IsExistedPersonal(string personal)
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where personalcode='" + personal + "'; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            connection.Close();
            return result;
        }
        public MemberVO GetMember(string code)
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where membercode='" + code + "'; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            MemberVO member = null;
            while (reader.Read())
                member = new MemberVO(reader["id"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["phone"].ToString(), reader["adress"].ToString(), reader["personalcode"].ToString(), reader["membercode"].ToString());
            connection.Close();
            return member;
        }
        public bool IsExistedBookId(string id)
        {
            connection.Open();
            query = "";
            query += "select * from book ";
            query += "where id='" + id + "';";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            connection.Close();
            return result;
        }
        public bool IsBorrowd(string memberCode,string bookcode)
        {
            connection.Open();
            query = "";
            query += "select * from borrowed ";
            query += "where bookid='" + bookcode + "' ";
            query += "and membercode=" + memberCode + "; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            connection.Close();
            return result;
        }
        public bool IsHaveBook(string memberCode)
        {
            connection.Open();
            query = "";
            query += "select * from borrowed ";
            query += "where membercode=" + memberCode + "; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            connection.Close();
            return result;
        }
    }
}
