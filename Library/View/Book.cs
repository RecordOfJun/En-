using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
namespace Library.View
{
    class Book
    {
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
            Console.WriteLine("  Isbn[10글자의 숫자를 입력해 주세요]");
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
            Console.WriteLine("  출판일[ex)1998-08-28]");
            Console.WriteLine("  :");
            Console.WriteLine("  완료하기");

        }

        public void BookInformation(BookVO book, int type)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("도서코드 :" + book.Id);
            Console.WriteLine("제목 :" + book.Name);
            Console.WriteLine("저자 :" + book.Author);
            Console.WriteLine("출판사 :" + book.Publisher);
            Console.WriteLine("출판일 :" + book.Pubdate);
            Console.WriteLine("가격 :" + book.Price);
            Console.WriteLine("Isbn :" + book.Isbn);
            Console.WriteLine("설명 :" + book.Description);
            if (type == Constant.BOOK_BORROW)
                Console.WriteLine("대여 가능 수량:{0}", book.Quantity - book.Borrowed);
            else if(type==Constant.ADMIN_BOOK)
                Console.WriteLine("총 수량:{0}", book.Quantity);
            else
                Console.WriteLine("대여된 수량:{0}", book.Borrowed);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public void NaverBookInformation(ItemData item,int sequence)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("번호 :" + sequence);
            Console.WriteLine("제목 :" + item.title);
            Console.WriteLine("저자 :" + item.author);
            Console.WriteLine("출판사 :" + item.publisher);
            Console.WriteLine("출판일 :" + item.pubdate);
            Console.WriteLine("가격 :" + item.price);
            Console.WriteLine("Isbn :" + item.isbn);
            Console.WriteLine("설명 :" + item.description);
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
        private void NaverSearchForm()
        {
            Console.WriteLine("  키워드 입력");
            Console.WriteLine();
            Console.WriteLine("  출력수 입력(1~100)");
            Console.WriteLine();
            Console.WriteLine("  조회");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public void NaverAddForm()
        {
            Console.WriteLine("검색된 도서의 번호와 수량을 입력 시 해당 도서를 도서관에 추가합니다.");
            Console.WriteLine("(최대 추가 가능 권수 :99권),(ESC입력 시 재검색)");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("출력번호를 입력해 주세요:");
            Console.WriteLine();
            Console.WriteLine("추가수량을 입력해 주세요:");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        private void Guide()
        {
            Console.WriteLine();
            Console.WriteLine("                  방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                      메뉴로 돌아가고 싶으면ESC를 눌러주세요. ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public void NaverGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("                                네이버 도서조회 방법");
            Console.WriteLine("                       1.원하는 키워드와 출력수를 입력한다.");
            Console.WriteLine("                          2.조회를 눌러 도서를 검색한다.");
            Guide();
            NaverSearchForm();
        }

        public void SearchGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("                                  도서조회 방법");
            Console.WriteLine("                         1.원하는 도서의 정보를 입력한다.");
            Console.WriteLine("                          2.조회를 눌러 도서를 검색한다.");
            Guide();
            BookSearchForm();
        }
        private void BookManual(string firstLine, string thirdLine, string fourthLine)
        {
            Console.WriteLine("                         1.{0} 도서의 정보를 입력한다.", firstLine);
            Console.WriteLine("                          2.조회를 눌러 도서를 검색한다.");
            Console.WriteLine("                        3.{0} 도서의 도서코드를 입력한다.", thirdLine);
            Console.WriteLine("                          4.엔터를 눌러 도서를 {0}한다.", fourthLine);
        }
        private void KeyGuide()
        {
            Console.WriteLine("                  방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("             전체조회시 바로  조회 버튼클릭, 메뉴로 돌아가고 싶으면ESC ");
            Console.WriteLine("                 원하는 정보를 검색 후 도서코드를 입력해 주세요!");
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

        public void BestBookGuide()
        {
            Console.WriteLine();
            Console.WriteLine("                                 인기도서 조회");
            Console.WriteLine();
            Console.WriteLine("                대여량이 가장 많은 도서들을 보실 수 있습니다!");
            Console.WriteLine("                                   (1위~5위) ");
            Console.WriteLine("                  조회를 마쳤으면 ESC나 엔터를 입력해주세요. ");
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
