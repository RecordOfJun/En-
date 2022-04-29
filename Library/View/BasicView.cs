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
        public void MainMenu()
        {
            Console.WriteLine("                                 1.로그인                                        ");
            Console.WriteLine("                                 2.회원가입                                      ");
            Console.WriteLine("                                 3.관리자 로그인                                 ");
            Console.WriteLine("                                 4.프로그램 종료                                 ");
        }

        public void AddMemberForm()
        {
            Console.WriteLine("");
            Console.WriteLine("                     회원가입 후 도서 대여 및 반납이 가능합니다!                 ");
            Console.WriteLine("                   아래에 양식에 맞게 차례대로 정보를 입럭해 주세요!             ");
            Console.WriteLine(" 입력한 정보를 다시 입력하려면 방향키로 이동, 입력을 완료했으면 엔터를 눌러주세요!");
            Console.WriteLine("                           (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            InsetForm();

        }
        public void ReviseForm()
        {
            Console.WriteLine("");
            Console.WriteLine("               개인정보 수정은 비밀번호, 이름, 전화번호,주소 만 가능합니다!                 ");
            Console.WriteLine("                   아래에 양식에 맞게 차례대로 정보를 입럭해 주세요!             ");
            Console.WriteLine(" 입력한 정보를 다시 입력하려면 방향키로 이동, 입력을 완료했으면 엔터를 눌러주세요!");
            Console.WriteLine("                           (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            InsetForm();

        }
        private void InsetForm()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ID[영문과 숫자를 혼합하여 6~10자 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  PASSWORD[영문과 숫자를 혼합하여 6~12자 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  PASSWORD확인");
            Console.WriteLine("  :");
            Console.WriteLine("  이름[한글만 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  주민번호[숫자 13자리를 입력해주세요 ex)9808281111111]");
            Console.WriteLine("  :");
            Console.WriteLine("  전화번호[숫자만 입력해 주세요 EX)01026763147]");
            Console.WriteLine("  :");
            Console.WriteLine("  주소[경기도 군포시 고산로 539번길 7-12]");
            Console.WriteLine("  :");
            Console.WriteLine("  완료하기");
        }
        public void AddBook()
        {
            Console.WriteLine("");
            Console.WriteLine("                             새로운 도서 추가를 원하시면                 ");
            Console.WriteLine("                   아래에 양식에 맞게 차례대로 정보를 입럭해 주세요!             ");
            Console.WriteLine(" 입력한 정보를 다시 입력하려면 방향키로 이동, 입력을 완료했으면 엔터를 눌러주세요!");
            Console.WriteLine("                           (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  도서번호[8글자의 숫자를 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  도서명[최대 20글자]");
            Console.WriteLine("  :");
            Console.WriteLine("  출판사명[최대 20글자]");
            Console.WriteLine("  :");
            Console.WriteLine("  저자명[최대 20글자]");
            Console.WriteLine("  :");
            Console.WriteLine("  가격[숫자만 입력해주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  수량[숫자만 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  완료하기");

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
        
        public void BookInformation(BookVO book, int type)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write("도서코드:{0}", book.Id);
            Console.SetCursorPosition(Constant.WIDTH, Console.CursorTop);
            Console.WriteLine("도서명:{0}",book.Name);
            Console.Write("출판사:{0}",book.Publisher);
            Console.SetCursorPosition(Constant.WIDTH, Console.CursorTop);
            Console.WriteLine("저자명:{0}", book.Author);
            Console.Write("가격:{0}",book.Price);
            Console.SetCursorPosition(Constant.WIDTH, Console.CursorTop);
            if(type==Constant.BOOK_BORROW)
                Console.WriteLine("대여 가능 수량:{0}", book.Quantity-book.Borrowed);
            else
                Console.WriteLine("총 수량:{0}", book.Quantity);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public void BorrowInformation(MyBook myBook)
        {
            BookVO book = myBook.book;
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write("도서코드:{0}", book.Id);
            Console.SetCursorPosition(Constant.WIDTH, Console.CursorTop);
            Console.WriteLine("도서명:{0}", book.Name);
            Console.Write("출판사:{0}", book.Publisher);
            Console.SetCursorPosition(Constant.WIDTH, Console.CursorTop);
            Console.WriteLine("저자명:{0}", book.Author);
            Console.Write("가격:{0}", book.Price);
            Console.SetCursorPosition(Constant.WIDTH, Console.CursorTop);
            Console.WriteLine();
            Console.Write("대여 날짜:{0}", myBook.borrowedTime);
            Console.SetCursorPosition(Constant.WIDTH, Console.CursorTop);
            Console.WriteLine("반납 기한:{0}", myBook.returnTime);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public void MemberInformation(MemberVO member)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write("ID:{0}", member.Id);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("회원코드:{0}", member.MemberCode);
            Console.Write("Password:{0}", member.Password);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("이름:{0}", member.Name);
            Console.Write("주민등록번호:{0}", member.PersonalCode);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("전화번호:{0}", member.PhoneNumber);
            Console.WriteLine("주소:{0}", member.Address);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        private void BookSearchForm()
        {
            Console.WriteLine("  도서명 입력");
            Console.WriteLine();
            Console.WriteLine("  저자명 입력");
            Console.WriteLine();
            Console.WriteLine("  출판사 입력");
            Console.WriteLine();
            Console.WriteLine("  조회");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        private void KeyGuide()
        {
            Console.WriteLine("                  방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("             전체조회시 바로  조회 버튼클릭, 메뉴로 돌아가고 싶으면ESC ");
            Console.WriteLine("                 원하는 정보를 검색 후 도서코드를 입력해 주세요!");
        }
        public void SearchGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("                                  도서조회 방법");
            Console.WriteLine("                         1.원하는 도서의 정보를 입력한다.");
            Console.WriteLine("                          2.조회를 눌러 도서를 검색한다.");
            Console.WriteLine();
            Console.WriteLine("                  방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                      메뉴로 돌아가고 싶으면ESC를 눌러주세요. ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            BookSearchForm();
        }
        private void BookManual(string firstLine, string thirdLine, string fourthLine)
        {
            Console.WriteLine("                         1.{0} 도서의 정보를 입력한다.",firstLine);
            Console.WriteLine("                          2.조회를 눌러 도서를 검색한다.");
            Console.WriteLine("                        3.{0} 도서의 도서코드를 입력한다.",thirdLine);
            Console.WriteLine("                          4.엔터를 눌러 도서를 {0}한다.",fourthLine);
        }
        public void BorrowGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                  도서대여 방법");
            BookManual("원하는", "찾은", "대여");
            KeyGuide();
            Console.WriteLine("---------------------------------------------------------------------------------");
            BookSearchForm();
            Console.WriteLine("도서코드를 입력해 주세요:");
        }
        public void ReturnGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                도서반납 방법");
            BookManual("빌린", "반납할", "반납");
            KeyGuide();
            Console.WriteLine("---------------------------------------------------------------------------------");
            BookSearchForm();
            Console.WriteLine("도서코드를 입력해 주세요:");
        }
        public void DeleteGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                도서삭제 방법");
            BookManual("삭제할", "삭제할", "삭제");
            KeyGuide();
            Console.WriteLine("---------------------------------------------------------------------------------");
            BookSearchForm();
            Console.WriteLine("도서코드를 입력해 주세요:");
        }
        public void ReviseGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                               도서수량 수정 방법");
            BookManual("수정할", "수정할", "수정");
            KeyGuide();
            Console.WriteLine("---------------------------------------------------------------------------------");
            BookSearchForm();
            Console.WriteLine("도서코드를 입력해 주세요:");
            Console.WriteLine();
            Console.WriteLine("변경수량을 입력해 주세요:");
        }
        private void UserDataForm()
        {
            Console.WriteLine("  ID 입력");
            Console.WriteLine();
            Console.WriteLine("  회원명 입력");
            Console.WriteLine("");
            Console.WriteLine("  전화번호 입력");
            Console.WriteLine("");
            Console.WriteLine("  조회");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        private void UserManual()
        {
            Console.WriteLine("                         1.원하는 회원의 정보를 입력한다.");
            Console.WriteLine("                          2.조회를 눌러 회원을 검색한다.");
            Console.WriteLine("                        3.찾은 회원의 회원코드를 입력한다.");
        }
        public void MemberReviseGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                  회원정보 수정");
            UserManual();
            Console.WriteLine("                      4.엔터를 눌러 수정화면으로  넘어간다.");
            Console.WriteLine("                방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                      전체조회시 바로 조회를 눌러주세요 ");
            Console.WriteLine("                                    뒤로가기:ESC");
            Console.WriteLine("---------------------------------------------------------------------------------");
            UserDataForm();
            Console.WriteLine("회원코드를 정확하게 입력해 주세요!");
            Console.WriteLine(":");
        }
        public void MemberDeleteGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                    회원 삭제");
            UserManual();
            Console.WriteLine("                           4.엔터를 눌러 회원을 삭제한다.");
            Console.WriteLine("                 방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                        전체조회시 바로 조회를 눌러주세요 ");
            Console.WriteLine("                                    뒤로가기:ESC");
            Console.WriteLine("---------------------------------------------------------------------------------");
            UserDataForm();
            Console.WriteLine("회원코드를 정확하게 입력해 주세요!");
            Console.WriteLine(":");
        }
        public void MemberSearchGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                    회원 조회");
            UserManual();
            Console.WriteLine();
            Console.WriteLine("                  방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                           메뉴로 돌아가고 싶으면ESC ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            UserDataForm();
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
