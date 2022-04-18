using System;
using Library.Controller;
using System.Runtime.InteropServices;
using Library.Model;
namespace Library

{
    class System
    {

        static void Main(string[] args)
        {
            //LibraryProgram libraryProgram = new LibraryProgram();
            //libraryProgram.start();
            MemberVO member = new MemberVO("abcd12345", "qwer1235", "조영", "01055533355", "경기도 군포시 고산로", "9808281111118", "6");
            DBConnection dB = new DBConnection();
            dB.InsertMember(member);
        }//관리자 아이디:1111111111,비밀번호:9999999999
    }
}
