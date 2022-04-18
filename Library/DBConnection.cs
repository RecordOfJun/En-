using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Library.Model;
namespace Library
{
    class DBConnection
    {
        MySqlConnection connection;
        MySqlCommand command;
        string query;
        public DBConnection()
        {
            connection = new MySqlConnection("Server=localhost;Port=3306;Database=ensharpstudy;Uid=root;Pwd=6212");
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
        }
        public void DeleteMember(string code)
        {
            connection.Open();
            query = "";
            query += "delete from member ";
            query += "where membercode=" + code + ";";
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
