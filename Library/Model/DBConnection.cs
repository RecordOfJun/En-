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
        Book bookUI = new Book();
        Member memberUI = new Member();
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
        public void InsertMember(MemberVO member)//회원가입 시 멤버정보 추가
        {
            connection.Open();
            query = "";
            query += Constant.INSERT_MEMBER;
            query += member.Id + "','" + member.Password + "','" + member.Name + "','" + member.PersonalCode + "','" + member.PhoneNumber + "','" + member.Address + "');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateMember(MemberVO member,string code)//회원 정보 수정 시 정보 업데이트
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
        public void DeleteMember(string code)//회원 삭제
        {
            connection.Open();
            query = "";
            query += "delete from member ";
            query += "where membercode=" + code + ";";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void SelectMember(string id,string name, string phone,List<MemberVO> memberList)//회원 전체 조회(ADMIN 제외)
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
            {//회원 정보 출력 및 리스트 추가
                MemberVO member = new MemberVO(reader["id"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["phone"].ToString(), reader["adress"].ToString(), reader["personalcode"].ToString(), reader["membercode"].ToString());
                memberUI.MemberInformation(member);
                memberList.Add(member);
            }
            connection.Close();
        }

        public MemberVO SelectAdmin()//관리자 계정 불러오기
        {
            connection.Open();
            query = "";
            query += Constant.SELECT_ADMIN;
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

        public void InsertBook(BookVO book)//도서 추가
        {
            connection.Open();
            query = "";
            query += "Insert into book(name,publisher,author,price,quantity,isbn,pubdate,description) values ('";
            query += book.Name + "','" + book.Publisher + "','" + book.Author + "'," + book.Price + "," + book.Quantity+ ",'" + book.Isbn+ "','" + book.Pubdate + "','" +book.Description+ "');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateBook(int quantity,string id)//도서 수량 조정
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
        public void SelectBook(string name, string author, string publisher,List<BookVO> bookList,int type)//책 조회
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
                BookVO book = new BookVO( reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()),reader["isbn"].ToString(),reader["description"].ToString(),DateTime.Parse(reader["pubdate"].ToString()).ToString("yyyy-mm-dd"), reader["id"].ToString());
                bookList.Add(book);
            }
            connection.Close();
            foreach(BookVO book in bookList)
            {//검색한 책의 대여 수 찾기 & 전체수량에서 대여수량 빼서 잔여수량 출력
                book.Borrowed = NumberOfBorrowed(book.Id);
                bookUI.BookInformation(book,type);
            }
        }
        private int NumberOfBorrowed(string bookid)//대여 수량 찾기
        {
            int count=0;
            connection.Open();
            query = "";
            query += Constant.BORROW_COUNT;
            query += bookid + ";";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
                count = int.Parse(reader["COUNT(*)"].ToString());
            connection.Close();
            return count;
        }
        public void InsertBorrow(string bookId,string code)//도서 대여
        {
            connection.Open();
            query = "";
            query += "Insert into borrowed values ('";
            query += bookId+"',"+code+ ",'"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"','"+DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss") +"');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBorrow(string bookId,string code,int type)//도서 반납
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
        public void SelectBorrow(string name, string author, string publisher,string code,List<BookVO> bookList)//대여정보 출력
        {
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
                BookVO book = new BookVO( reader["name"].ToString(), reader["publisher"].ToString(), reader["author"].ToString(), reader["price"].ToString(), int.Parse(reader["quantity"].ToString()), reader["isbn"].ToString(), reader["description"].ToString(), reader["pubdate"].ToString(), reader["id"].ToString());
                MyBook borrowBook = new MyBook(book, reader["borrowtime"].ToString().Substring(0,10), reader["returntime"].ToString().Substring(0, 10));//db에는 정상적으로 저장 다시 불러올때 값 이상함
                bookUI.BorrowInformation(borrowBook);
                bookList.Add(book);
            }
            connection.Close();
        }
        public MemberVO FindUser(string id,string password)//ID,비번으로 유저 찾기
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
        public bool IsExistedId(string id)//ID존재여부 확인
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
        public bool IsExistedPersonal(string personal)//주민번호 존재여부 확인
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
        public MemberVO GetMember(string code)//회원 코드로 유저 찾기
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
        public bool IsExistedBookId(string id)//도서 ID 중복확인
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
        public bool IsBorrowd(string memberCode,string bookcode)//이미 대여중인지 확인
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
        public bool IsHaveBook(string memberCode)//삭제할 유저가 대여중인지 확인
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
