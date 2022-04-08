using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class VOList
    {
        public List<BookVO> bookList=new List<BookVO>();
        public List<MemberVO> memberList = new List<MemberVO>();
        public VOList()
        {
            memberList.Add(new MemberVO("abc123", "qwer123", "조형준", "01026763147", "경기도 군포시 고산로", "9808281111111"));
        }
    }
}
