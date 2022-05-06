using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Library.Model;
using Library.View;
namespace Library.Model
{
    class MemberDAO
    {
        private static MemberDAO memberDAO;
        MySqlConnection connection;
        MySqlCommand command;
        Member memberUI = new Member();
        string query;
        private MemberDAO()
        {
            connection = new MySqlConnection(Constant.SERVER_DATA);
        }
        public static MemberDAO GetDBConnection()
        {
            if (memberDAO == null)
                memberDAO = new MemberDAO();
            return memberDAO;
        }
        public void InsertMember(MemberDTO member)//회원가입 시 멤버정보 추가
        {
            connection.Open();
            query = "";
            query += Constant.INSERT_MEMBER;
            query += member.Id + "','" + member.Password + "','" + member.Name + "','" + member.PersonalCode + "','" + member.PhoneNumber + "','" + member.Address + "');";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateMember(MemberDTO member, string code)//회원 정보 수정 시 정보 업데이트
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
        public void SelectMember(string id, string name, string phone, List<MemberDTO> memberList)//회원 전체 조회(ADMIN 제외)
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where id like '%" + id + "%' and ";
            query += "name like '%" + name + "%' and ";
            query += "phone like '%" + phone + "%'  ";
            query += "and name <> 'Adm';";

            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {//회원 정보 출력 및 리스트 추가
                MemberDTO member = new MemberDTO(reader["id"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["phone"].ToString(), reader["adress"].ToString(), reader["personalcode"].ToString(), reader["membercode"].ToString());
                memberList.Add(member);
            }
            connection.Close();
            foreach (MemberDTO member in memberList)
            {
                member.Borrowed = BookDAO.GetDBConnection().NumberOfBorrowed(Constant.BORROW_COUNT_MEMBER, member.MemberCode);
                memberUI.MemberInformation(member);
            }
        }

        public MemberDTO SelectAdmin()//관리자 계정 불러오기
        {
            connection.Open();
            query = "";
            query += Constant.SELECT_ADMIN;
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            MemberDTO admin = new MemberDTO("","","","","","","");
            while (reader.Read())
            {
                admin.Id = reader["id"].ToString();
                admin.Password = reader["password"].ToString();
            }
            connection.Close();
            return admin;
        }
        public MemberDTO FindUser(string id, string password)//ID,비번으로 유저 찾기
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where id='" + id + "' and ";
            query += "password= '" + password + "';";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            MemberDTO member = null;
            while (reader.Read())
                member = new MemberDTO(reader["id"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["phone"].ToString(), reader["adress"].ToString(), reader["personalcode"].ToString(), reader["membercode"].ToString());
            connection.Close();
            return member;
        }
        public bool IsExistedId(string id)//ID존재여부 확인
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where id='" + id + "'; ";
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
        public MemberDTO GetMember(string code)//회원 코드로 유저 찾기
        {
            connection.Open();
            query = "";
            query += "SELECT * from member ";
            query += "where membercode='" + code + "'; ";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            MemberDTO member = null;
            while (reader.Read())
                member = new MemberDTO(reader["id"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["phone"].ToString(), reader["adress"].ToString(), reader["personalcode"].ToString(), reader["membercode"].ToString());
            connection.Close();
            return member;
        }
        public bool IsBorrowd(string memberCode, string bookcode)//이미 대여중인지 확인
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
