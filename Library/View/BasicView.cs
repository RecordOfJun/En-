using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

namespace Library.View
{
    class BasicView
    {
        public BasicView()
        {
        }
        public void MainMenu()
        {
            Console.WriteLine("                                 1.로그인                                        ");
            Console.WriteLine("                                 2.회원가입                                      ");
            Console.WriteLine("                                 3.관리자 로그인                                 ");
            Console.WriteLine("                                 4.프로그램 종료                                 ");
        }
        public void DeleteString(int startCursorIndexOfX, int startCursorIndexOfY, int maximumLength)
        {
            Console.SetCursorPosition(startCursorIndexOfX, startCursorIndexOfY);
            Console.Write(new string(' ', maximumLength + 1));
            Console.SetCursorPosition(startCursorIndexOfX, startCursorIndexOfY);

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
        public void AdminLabel()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|             ###        ######     ####    ####     ##     ####    ##          |");
            Console.WriteLine("|            ## ##       ##   ##    ## ##  ## ##     ##     ## ##   ##          |");
            Console.WriteLine("|           #######      ##   ##    ##  ####  ##     ##     ##  ##  ##          |");
            Console.WriteLine("|          ##     ##     ##   ##    ##   ##   ##     ##     ##   ## ##          |");
            Console.WriteLine("|         ##       ##    ######     ##        ##     ##     ##    ####          |");
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
        public void MemberGuide()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                              회원 전용 메뉴입니다!                 ");
            Console.WriteLine("                          원하시는 메뉴를 선택해 주세요                          ");
            Console.WriteLine("                      (화살표 위, 아래 버튼으로 이동 후 엔터)                     ");
            Console.WriteLine("                                 (뒤로가기:ESC)");
        }
        
        
        public void ConfirmAddForm()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("완료하시려면 아무키나 입력해 주세요.(단,ESC입력시 취소 됩니다.)");
        }
        public void ReviseDone()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("메뉴로 돌아가시려면 아무키나 입력해 주세요.");
        }
        public void SetInputCursor(string inputString)
        {
            Console.Write(inputString);
        }
        public void WritePassword(string inputString)
        {
            Console.Write(new string('*', inputString.Length));
        }
        public void LoginForm()
        {
            Console.WriteLine("                        도서관 시스템을 이용하시려면                          ");
            Console.WriteLine("                     아이디와 비밀번호를 입력해 주세요!                       ");
            Console.WriteLine("                       (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ID[영문과 숫자를 혼합하여 6~10자 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("PASSWORD[영문과 숫자를 혼합하여 6~12자 입력해 주세요]");
            Console.WriteLine(":");
        }
        public void AdminLoginForm()
        {
            Console.WriteLine("                        관리자 로그인 메뉴입니다.                         ");
            Console.WriteLine("                     아이디와 비밀번호를 입력해 주세요!                       ");
            Console.WriteLine("                       (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ID[관리자 전용 ID를 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("PASSWORD[관리자 전용 PASSWORD를 입력해 주세요]");
            Console.WriteLine(":");
        }
        public void AdminGuide()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                              관리자 전용 메뉴입니다!                 ");
            Console.WriteLine("                          원하시는 메뉴를 선택해 주세요                          ");
            Console.WriteLine("                      (화살표 위, 아래 버튼으로 이동 후 엔터)                     ");
            Console.WriteLine("                                 (뒤로가기:ESC)");
        }
        public void UserMenu()
        {
            Console.WriteLine("                                 1.도서 조회                                    ");
            Console.WriteLine("                                 2.도서 대여                                    ");
            Console.WriteLine("                                 3.도서 반납                                    ");
            Console.WriteLine("                                 4.개인정보 수정                                ");
            Console.WriteLine("                                 5.프로그램 종료                                ");
        }
        
        
        public void AdminMenu()
        {
            Console.WriteLine("                                 1.도서 관리                                        ");
            Console.WriteLine("                                 2.회원 관리                                      ");
            Console.WriteLine("                                 3.프로그램 종료                                ");
        }
        public void DeleteDone()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                            삭제가 완료되었습니다.");
        }
        public void BookManage()
        {
            Console.WriteLine("                                 1.도서 관리                                        ");
            Console.WriteLine("                                 2.도서 수정                                      ");
            Console.WriteLine("                                 3.도서 삭제                                ");
            Console.WriteLine("                                 4.도서 추가");
        }
        public void MemberManage()
        {
            Console.WriteLine("                                 1.회원 조회                                        ");
            Console.WriteLine("                                 2.회원 정보 수정                                      ");
            Console.WriteLine("                                 3.회원 삭제                                ");
        }
        public void SearchForm()
        {
            Console.Write("검색어:");
        }
    }
}
