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
            memberList.Add(new MemberVO("abcd123", "qwer123", "조영준", "01011111111", "경기도 군포시 고산로", "9808281111112"));
            memberList.Add(new MemberVO("abcde123", "qwer123", "조형운", "01022222222", "경기도 군포시 고산로", "9808281111113"));
            memberList.Add(new MemberVO("abc1234", "qwer123", "조준", "01033333333", "경기도 군포시 고산로", "9808281111114"));
            memberList.Add(new MemberVO("abc1235", "qwer123", "형준", "01044444444", "경기도 군포시 고산로", "9808281111115"));
            memberList.Add(new MemberVO("abcd1234", "qwer123", "조형", "01055555555", "경기도 군포시 고산로", "9808281111116"));

            bookList.Add(new BookVO("12345678", "신호와 시스템", "(주)한티에듀", "Simon Haykin","30000",3));
            bookList.Add(new BookVO("11111111", "컴퓨터 구조", "한티 미디어", "David A. Patterson", "50000", 2));
            bookList.Add(new BookVO("22222222", "디지털 논리 설계", "Mc Graw Hill Edu", "Alan B.Marcovitz", "350000", 1));
            bookList.Add(new BookVO("33333333", "명품 웹 프로그래밍", "생능출판", "황기태", "28000", 1));
            bookList.Add(new BookVO("44444444", "수능완성 국어영역", "EBS", "조형준", "7000", 3));
            bookList.Add(new BookVO("55555555", "솔직한 공학수학", "텍스트북스", "노태완", "32000", 2));
            bookList.Add(new BookVO("66666666", "노인과 바다", "소담 출판사", "어네스트 헤밍웨이", "4500", 1));
            bookList.Add(new BookVO("77777777", "명품 자바 프로그래밍", "생능출판", "황기태", "38000", 2));
        }
    }
}
