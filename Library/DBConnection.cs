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
        private static DBConnection dBConnection = new DBConnection();
        MySqlConnection connection;
        MySqlCommand command;
        BasicView basicView = new BasicView();
        string query;
        private DBConnection()
        {
            connection = new MySqlConnection("Server=localhost;Port=3306;Database=ensharpstudy;Uid=root;Pwd=0000");
        }
        public static DBConnection GetDBConnection()
        {
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
            query += "phone like '%" + phone + "%'; ";
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
            query += "publisher like '%" + publisher + "%'; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookVO book = new BookVO(reader["id"].ToString(), reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()));
                basicView.BookInformation(book);
                bookList.Add(book);
            }
            connection.Close();
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
            query += "SELECT book.*,borrowed.borrowtime,borrowed.returntime from book,borrowed ";
            query += "where book.name like '%" + name + "%' and ";
            query += "book.author like '%" + author + "%' and ";
            query += "book.publisher like '%" + publisher + "%' and ";
            query += "book.id in( select bookid from borrowed where membercode=" + code + ") ";
            query += "group by book.id;";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookVO book = new BookVO(reader["id"].ToString(), reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()));
                MyBook borrowBook = new MyBook(book, reader["borrowtime"].ToString(), reader["returntime"].ToString());//db에는 정상적으로 저장 다시 불러올때 값 이상함
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
    }
}
