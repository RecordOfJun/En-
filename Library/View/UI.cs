using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

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
        public void MemberGuide()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                              회원 전용 메뉴입니다!                 ");
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
            Console.WriteLine("                           (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("ID[영문과 숫자를 혼합하여 6~10자 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("PASSWORD[영문과 숫자를 혼합하여 6~12자 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("PASSWORD확인");
            Console.WriteLine(":");
            Console.WriteLine("이름[한글만 입력해 주세요]");
            Console.WriteLine(":");
            Console.WriteLine("주민번호[숫자 13자리를 입력해주세요]");
            Console.WriteLine(":");
            Console.WriteLine("전화번호[숫자만 입력해 주세요 EX)01026763147]");
            Console.WriteLine(":");
            Console.WriteLine("주소[EX) 경기도 군포시 고산로 539번길]");
            Console.WriteLine(":");

        }
        public void ConfirmAddForm()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("완료하시려면 아무키나 입력해 주세요.(단,ESC입력시 취소 됩니다.)");
        }
        public void SetInputCursor(string inputString)
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constant.ADD_INDEX, Console.CursorTop);
            Console.Write(inputString);
        }
        public void WritePassword(string inputString)
        {
            Console.SetCursorPosition(Constant.ADD_INDEX, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constant.ADD_INDEX, Console.CursorTop);
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
        public void UserSelectFirst()
        {
            Console.WriteLine("                                 >1.도서 대여                                        ");
            Console.WriteLine("                                 2.도서 반납                                      ");
            Console.WriteLine("                                 3.개인정보 수정                                ");
            Console.WriteLine("                                 4.메인메뉴 복귀                                ");
            Console.WriteLine("                                 5.프로그램 종료                                ");
        }
        public void UserSelectSecond()
        {
            Console.WriteLine("                                 1.도서 대여                                        ");
            Console.WriteLine("                                 >2.도서 반납                                      ");
            Console.WriteLine("                                 3.개인정보 수정                                ");
            Console.WriteLine("                                 4.메인메뉴 복귀                                ");
            Console.WriteLine("                                 5.프로그램 종료                                ");
        }
        public void UserSelectThird()
        {
            Console.WriteLine("                                 1.도서 대여                                        ");
            Console.WriteLine("                                 2.도서 반납                                      ");
            Console.WriteLine("                                >3.개인정보 수정                                ");
            Console.WriteLine("                                 4.메인메뉴 복귀                                ");
            Console.WriteLine("                                 5.프로그램 종료                                ");
        }
        public void UserSelectFourth()
        {
            Console.WriteLine("                                 1.도서 대여                                        ");
            Console.WriteLine("                                 2.도서 반납                                      ");
            Console.WriteLine("                                 3.개인정보 수정                                ");
            Console.WriteLine("                                 >4.메인메뉴 복귀                                ");
            Console.WriteLine("                                 5.프로그램 종료                                ");
        }
        public void UserSelectFifth()
        {
            Console.WriteLine("                                 1.도서 대여                                        ");
            Console.WriteLine("                                 2.도서 반납                                      ");
            Console.WriteLine("                                 3.개인정보 수정                                ");
            Console.WriteLine("                                 4.메인메뉴 복귀                                ");
            Console.WriteLine("                                 >5.프로그램 종료                                ");
        }
        
        public void BookInformation(BookVO book)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write("도서코드:{0}", book.Id);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("도서명:{0}",book.Name);
            Console.Write("출판사:{0}",book.Publisher);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("저자명:{0}", book.Author);
            Console.Write("가격:{0}",book.Price);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("대여 가능 수량:{0}", book.Quantity);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public void SearchGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                도서대여 방법");
            Console.WriteLine("                         1.원하는 도서의 이름을 입력한다.");
            Console.WriteLine("                          2.엔터를 눌러 도서를 검색한다.");
            Console.WriteLine("                        3.찾은 도서의 도서코드를 입력한다.");
            Console.WriteLine("                          4.엔터를 눌러 도서를 대여한다.");
            Console.WriteLine();
            Console.WriteLine("                            메뉴로 돌아가고 싶으면ESC, ");
            Console.WriteLine("            재검색을 하고싶으면 도서코드 입력 시 공란으로 엔터를 눌러주세요");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("도서명에 포함된 문자열을 입력해 주세요!");
            Console.WriteLine(":");
            Console.WriteLine("도서코드를 정확하게 입력해 주세요!");
            Console.WriteLine(":");
        }
    }
}
