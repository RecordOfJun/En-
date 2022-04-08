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
            Console.WriteLine("                      (화살표 위, 아래 버튼으로 이동 후 엔터)                     ");
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
            Console.WriteLine("                                 >5.프로그램 종료                                ");
        }

        public void AddMemberForm()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                     회원가입 후 도서 대여 및 반납이 가능합니다!                 ");
            Console.WriteLine("                   아래에 양식에 맞게 차례대로 정보를 입럭해 주세요!             ");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("ID[영문과 숫자를 혼합하여 6~10자 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("PASSWORD[영문과 숫자를 혼합하여 6~10자 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("이름[한글만 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("주민번호[숫자 13자리를 입력해주세요]");
            Console.WriteLine(":");
            Console.WriteLine("전화번호[숫자만 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("주소[EX) 경기도 군포시 고산로 539번길]");
            Console.WriteLine(":");

            Console.WriteLine("모두 입력 완료하시면 자동으로 회원가입이 완료 됩니다.");

        }
        public void SetIdPasswordCursor(string [] inputString)
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constant.ADD_INDEX, Console.CursorTop);
            Console.Write(String.Join("", inputString));
        }
    }
}
