using System;
using System.Collections.Generic;
using System.Text;

namespace Library.View
{
    class UI
    {
        public UI()
        {
        }
        public void LibraryLabel()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|         ##      ##  ######   ######        ###      ######   ##    ##         |");
            Console.WriteLine("|         ##      ##  ##   ##  ##   ##      ## ##     ##   ##   ##  ##          |");
            Console.WriteLine("|         ##      ##  ######   ######      #######    ######      ##            |");
            Console.WriteLine("|         ##      ##  ##   ##  ##   ##    ##     ##   ##   ##     ##            |");
            Console.WriteLine("|         ######  ##  ######   ##    ##  ##       ##  ##    ##    ##            |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public void MenuGuide()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                     도서관리 시스템에 오신것을 환영합니다!                      ");
            Console.WriteLine("                          원하시는 메뉴를 선택해 주세요                          ");
            Console.WriteLine("                      (w,s 버튼으로 위, 아래 이동 후 엔터)                     ");
            Console.WriteLine("");
        }
        public void SelectFirst() 
        {
            Console.WriteLine("                                 >1.로그인                                        ");
            Console.WriteLine("                                 2.회원가입                                      ");
            Console.WriteLine("                                 3.도서검색                                      ");
            Console.WriteLine("                                 4.관리자 로그인                                 ");
            Console.WriteLine("                                 5.프로그램 종료                                 ");
        }
        public void SelectSecond()
        {
            Console.WriteLine("                                 1.로그인                                        ");
            Console.WriteLine("                                 >2.회원가입                                      ");
            Console.WriteLine("                                 3.도서검색                                      ");
            Console.WriteLine("                                 4.관리자 로그인                                 ");
            Console.WriteLine("                                 5.프로그램 종료                                 ");
        }
        public void SelectThird()
        {
            Console.WriteLine("                                 1.로그인                                        ");
            Console.WriteLine("                                 2.회원가입                                      ");
            Console.WriteLine("                                 >3.도서검색                                      ");
            Console.WriteLine("                                 4.관리자 로그인                                 ");
            Console.WriteLine("                                 5.프로그램 종료                                 ");
        }
        public void SelectFourth()
        {
            Console.WriteLine("                                 1.로그인                                        ");
            Console.WriteLine("                                 2.회원가입                                      ");
            Console.WriteLine("                                 3.도서검색                                      ");
            Console.WriteLine("                                 >4.관리자 로그인                                 ");
            Console.WriteLine("                                 5.프로그램 종료                                 ");
        }
        public void SelectFifth()
        {
            Console.WriteLine("                                 1.로그인                                        ");
            Console.WriteLine("                                 2.회원가입                                      ");
            Console.WriteLine("                                 3.도서검색                                      ");
            Console.WriteLine("                                 4.관리자 로그인                                 ");
            Console.WriteLine("                                 >5.프로그램 종료                                 ");
        }
    }
}
