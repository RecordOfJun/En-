using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class BookService//책 관련 메소드 구현 클래스
    {
        VOList voList;
        User userFunction;
        ExceptionView exceptionView;
        Exception exception;
        List<BookVO> bookList;
        List<MyBook> myBookList;
        UI ui;
        public BookService(VOList voList, User userFunction,ExceptionAndView exceptionAndView)
        {
            exception = exceptionAndView.exception;
            ui = exceptionAndView.ui;
            exceptionView = exceptionAndView.exceptionView;
            this.voList = voList;
            this.userFunction = userFunction;
        }
        public void SearchAndChoice(int type)//책 정보 조회,수정,삭제 기능 메소드
        {
            string userInput = Constant.EMPTY;
            Console.Clear();
            SpreadBook(type, Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            while (userInput!=Constant.ESCAPE)
            {
                userInput = InsertNameAndCode(userInput,type);//책 정보 입력 및 도서코드 입력
                if (userInput == Constant.ESCAPE)
                    return;
                switch (type)
                {
                    case Constant.BOOK_BORROW:
                        BorrowBook(userInput);//책 대여
                        break;
                    case Constant.BOOK_DELETE:
                        DeleteBook(userInput);//책 삭제
                        break;
                    case Constant.BOOK_REVISE:
                        ReviseBook(userInput);//책 수정
                        break;
                    case 5://단순 조회
                        break;
                }
            }
        }
        private void ShowBookList(string name,string author,string publisher)//책 검색 메소드
        {
            List<BookVO> findList = new List<BookVO>();
            //입력한 정보와 일치하는 책 찾아 전역 리스트에 대입 AND 찾은 책 출력
            foreach (BookVO book in voList.bookList.FindAll(element => element.Name.Contains(name)&&element.Publisher.Contains(publisher) && element.Author.Contains(author)))
            {
                findList.Add(book);
                ui.BookInformation(book);
            }
            bookList = findList;
        }
        private void BorrowBook(string bookCode)//책 대여 메소드
        {
            if (bookCode == Constant.EMPTY)
                return;
            BookVO book = bookList.Find(book => book.Id == bookCode);//코드와 일치하는 책 찾기
            int remain = book.Quantity - book.Borrowed;
            if (remain > 0)//수량이 0보다 클 때 대여 가능
            {
                if (userFunction.LoginMember.IsHaveBook(book))
                {
                    exceptionView.AlreadyHas(bookCode.Length);//이미 빌린 책인지 확인
                    return;
                }
                userFunction.LoginMember.AddBook(book);//책 대여
                book.Borrowed++;
                exceptionView.BorrowSuccess(bookCode.Length);
                return;
            }
            exceptionView.NotRemain(bookCode.Length);//수량 없음
            return;
        }
        private void DeleteBook(string bookCode)//책 삭제 메소드
        {
            if (bookCode == Constant.EMPTY)
                return;
            BookVO book = bookList.Find(book => book.Id == bookCode);//코드와 일치하는 책 찾기
            RefreshAdminBook("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer");
            if (exception.IsDelete(book.Name))//정말 삭제할 것인지 확인
            {
                foreach (MemberVO member in voList.memberList)//삭제할 책을 빌린 유저들의 대여 리스트에서 해당 책 삭제
                {
                    MyBook myBook = member.borrowedBook.Find(element => element.book == book);
                    member.RemoveBook(myBook);
                }
                voList.bookList.Remove(book);//삭제
                exceptionView.DeleteSuccess(bookCode.Length);//삭제 완료
            }
        }
        private void ReviseBook(string bookCode)//책 수량 설정 메소드
        {
            if (bookCode == Constant.EMPTY)
                return ;
            bool isNumber = false;
            string quantity=Constant.EMPTY;
            while (!isNumber) {//0보다 큰 숫자가 들어올 때까지 입력
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.QUANTITY_INDEX);
                quantity = userFunction.GetData(2, Constant.EMPTY);
                if (quantity == Constant.ESCAPE)
                    return;
                isNumber = exception.IsNumber(quantity);
                if (quantity == "0")
                {
                    isNumber = Constant.IS_EXCEPTION;
                    exceptionView.QuantityException(quantity.Length);
                }
            }
            ReviseAdminBook("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer");
            BookVO book = bookList.Find(book => book.Id == bookCode);//코드와 일치하는 책 찾음
            if (exception.IsRevise(book.Name))//수정할 것인지 한번 더 확인
            {
                book.Quantity = int.Parse(quantity);//수량 수정
            }
            return;
        }
        private void ShowMyBook(string name, string author, string publisher)//대여중인 도서 조회 메소드
        {
            List<BookVO> findList = new List<BookVO>();
            //찾은 책 리스트 전역 책 리스트로 넘겨주고 정보 출력
            foreach (MyBook myBook in userFunction.LoginMember.borrowedBook.FindAll(element => element.book.Name.Contains(name) || element.book.Name.Contains(publisher) || element.book.Name.Contains(author)))
            {
                findList.Add(myBook.book);
                ui.BorrowInformation(myBook);
            }
            bookList = findList;
        }
        public void ReturnBook()//반납 메소드
        {
            string userInput=Constant.EMPTY;
            RefreshBorrowBook(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            while (userInput != Constant.ESCAPE)
            {
                userInput = InsertNameAndCode(userInput,2);//반납할 책 정보 입력
                if (userInput == Constant.ESCAPE)
                    return;
                UpdateBookCount(userInput);//해당 책 수량 조정
            }
        }
        private void UpdateBookCount(string Code)//책 수량 업데이트
        {
            if (Code == "")
                return;
            MyBook myBook = userFunction.LoginMember.borrowedBook.Find(element => element.book.Id == Code);//로그인 멤버 대여함에서 코드 일치 책 탐색
            if (myBook != null)
            {
                userFunction.LoginMember.RemoveBook(myBook);//로그인 한 멤버의 대여함에서 코드와 일치하는 책 삭제
                myBook.book.Borrowed--;//수량 조정
                exceptionView.ReturnSuccess(Code.Length);//완료
            }
            else
                exceptionView.NotExisted(Code.Length);

        }
        private string InsertNameAndCode(string userInput, int type)//정보를 검색하고 도서코드를 입력하는메소드
        {
            string name = Constant.EMPTY;
            string author = Constant.EMPTY;
            string publisher = Constant.EMPTY;
            ConsoleKeyInfo key;
            bool isKey = false;
            //제목,작가명,출판사로 검색을 가능하게 함
            while (!isKey) {
                Console.SetCursorPosition(Constant.ADD_INDEX, 10);
                key = Console.ReadKey();//1,2,3,엔터,ESC감지
                Console.SetCursorPosition(Constant.ADD_INDEX, 10);
                Console.Write("  ");
                isKey = true;
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        name = GetBookData(type, 0);//도서명 입력
                        break;
                    case ConsoleKey.D2:
                        author = GetBookData(type, 2);//저자명 입력
                        break;
                    case ConsoleKey.D3:
                        publisher = GetBookData(type, 4);//출판사명 입력
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        return Constant.ESCAPE;
                    default:
                        isKey = false;
                        break;
                }
            }
            if (name == Constant.ESCAPE|| author == Constant.ESCAPE|| publisher == Constant.ESCAPE)
                return Constant.ESCAPE;
            SpreadBook(type,name,author,publisher);//검색한 정보 출력
            if (type != 5)//단순 조회가 아닐 경우 (매직넘버)
            {
                bool isExisted = Constant.IS_EXCEPTION;
                while (!isExisted)
                {
                    Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX + 6);
                    userInput = userFunction.GetData(10, Constant.EMPTY);//도서코드 입력
                    if (userInput == Constant.EMPTY || userInput==Constant.ESCAPE)
                        return userInput;
                    isExisted = true;
                    if (!bookList.Exists(book => book.Id == userInput))//검색정보중에 코드와 일치하는 도서 있는지 확인
                    {
                        isExisted = false;
                        exceptionView.NotExisted(userInput.Length);
                    }
                }
            }
            return userInput;
        }
        private string GetBookData(int type,int cursor)//책 정보 입력받기
        {
            SpreadBook(type, Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX+cursor);
            string input = userFunction.GetData(10, Constant.EMPTY);
            return input;
        }
        private void SpreadBook(int type,string name, string author, string publisher)
        {
            switch (type)//타입에 따라 가이드 다르게 출력
            {
                case Constant.BOOK_BORROW:
                    RefreshUserBook(name, author, publisher);
                    break;
                case Constant.BOOK_RETURN:
                    RefreshBorrowBook(name, author, publisher);
                    break;
                case Constant.BOOK_DELETE:
                    RefreshAdminBook(name, author, publisher);
                    break;
                case Constant.BOOK_REVISE:
                    ReviseAdminBook(name, author, publisher);
                    break;
                case 5://단순조회(매직넘버)
                    RefreshSearchBook(name, author, publisher);
                    break;
            }
        }
        private void RefreshSearchBook(string name, string author, string publisher)//단순 조회시 출력
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.SearchGuide();
            ShowBookList(name, author, publisher);
        }
        private void RefreshUserBook(string name, string author, string publisher)//대여시 출력
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.BorrowGuide();
            ShowBookList(name, author, publisher);
        }
        private void RefreshAdminBook(string name, string author, string publisher)//삭제시 출력
        {
            Console.Clear();
            ui.DeleteGuide();
            ui.BorrowGuide();
            ShowBookList(name, author, publisher);
        }
        private void ReviseAdminBook(string name, string author, string publisher)//수정시 출력
        {
            Console.Clear();
            ui.AdminLabel();
            ui.ReviseGuide();
            ShowBookList(name,author,publisher);
        }
        private void RefreshBorrowBook(string name, string author, string publisher)//반납시 출력
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.ReturnGuide();
            ShowMyBook(name, author, publisher);
        }
    }
}
