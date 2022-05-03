using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
using Library.Utility;
namespace Library.Controller
{
    class BookService//책 관련 메소드 구현 클래스
    {
        User userFunction;
        ExceptionView exceptionView;
        Exception exception;
        List<BookVO> bookList;
        Basic basicUI;
        Book bookUI;
        BookVO storage;
        delegate void bookForm();
        public BookService(User userFunction,ExceptionAndView exceptionAndView)
        {
            this.userFunction = userFunction;
            storage = new BookVO();
            exception = exceptionAndView.exception;
            basicUI = exceptionAndView.basicUI;
            bookUI = exceptionAndView.bookUI;
            exceptionView = exceptionAndView.exceptionView;
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
                if (userInput != Constant.ESCAPE_STRING)
                {
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
                        case Constant.SEARCH_BOOK://단순 조회
                            break;
                    }
                }
            }
        }

        private void ShowBookList(string name,string author,string publisher,int type)//책 검색 메소드
        {
            List<BookVO> findList = new List<BookVO>();
            //입력한 정보와 일치하는 책 찾아 전역 리스트에 대입 AND 찾은 책 출력
            BookDAO.GetDBConnection().SelectBook(name, author, publisher, findList,type);
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
                if (userFunction.LoginMember.IsHaveBook(bookCode))
                {
                    exceptionView.SearchException(bookCode.Length, "  (이미 이 도서를 대여 하셨습니다!)");
                    return;
                }
                BookDAO.GetDBConnection().InsertBorrow(bookCode, userFunction.LoginMember.MemberCode);//책 대여
                Log.GetLog().LogAdd(userFunction.LoginMember.Id +" '"+book.Name+"' 도서 대여");
                exceptionView.SearchComplete(bookCode.Length, "  (대여가 완료되었습니다!)");
                return;
            }
            exceptionView.SearchException(bookCode.Length, "  (남은 수량이 없어 대여할 수 없습니다!)");
            return;
        }

        private void DeleteBook(string bookCode)//책 삭제 메소드
        {
            if (bookCode == Constant.EMPTY)
                return;
            BookVO book = bookList.Find(book => book.Id == bookCode);//코드와 일치하는 책 찾기
            RefreshBook("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer",bookUI.DeleteGuide,Constant.USER_BOOK);//책 목록 없애주기
            if (exception.IsDelete(book.Name))//정말 삭제할 것인지 확인
            {
                BookDAO.GetDBConnection().DeleteBorrow(bookCode, Constant.EMPTY, Constant.DELETE_BOOK);
                BookDAO.GetDBConnection().DeleteBook(bookCode);
                Log.GetLog().LogAdd("관리자 '" + book.Name + "' 도서 삭제");
                exceptionView.SearchComplete(bookCode.Length, "  (삭제가 완료되었습니다!))");//삭제 완료
            }
            RefreshBook(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY,bookUI.DeleteGuide, Constant.USER_BOOK);
        }
        private void ReviseBook(string bookCode)//책 수량 설정 메소드
        {
            if (bookCode == Constant.EMPTY)
                return ;
            bool isNumber = false;
            string quantity=Constant.EMPTY;
            while (!isNumber) {//0보다 큰 숫자가 들어올 때까지 입력
                Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, (int)Constant.SectorCursor.BOOK_QUANTITY_CURSOR);
                quantity = KeyProcessing.GetInput().GetUserString(2, Constant.NOT_PASSWORD_TYPE);
                if (quantity == Constant.ESCAPE_STRING)
                    return;
                isNumber = exception.IsNumber(quantity, Constant.INSERT_TYPE);
                if (quantity == "0")
                {
                    isNumber = Constant.IS_EXCEPTION;
                    exceptionView.SearchException(quantity.Length, "  (0보다 큰 숫자를 입력해 주세요!)");
                }
            }
            BookVO book = bookList.Find(element => element.Id == bookCode) ;//코드와 일치하는 책 찾음
            RefreshBook("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer",bookUI.ReviseGuide, Constant.ADMIN_BOOK);//책 목록 없애주기
            if (exception.IsRevise(book.Name))//수정할 것인지 한번 더 확인
            {
                BookDAO.GetDBConnection().UpdateBook(int.Parse(quantity),bookCode);//수량 수정
                Log.GetLog().LogAdd("관리자 '" + book.Name + "' 도서 수량 "+quantity+"(으)로 수정");
            }
            RefreshBook(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY,bookUI.ReviseGuide, Constant.ADMIN_BOOK);
            return;
        }

        private void ShowMyBook(string name, string author, string publisher)//대여중인 도서 조회 메소드
        {
            List<BookVO> findList = new List<BookVO>();
            //찾은 책 리스트 전역 책 리스트로 넘겨주고 정보 출력
            BookDAO.GetDBConnection().SelectBorrow(name, author, publisher, userFunction.LoginMember.MemberCode, findList);
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
                if (userInput != Constant.ESCAPE_STRING)
                    UpdateBookCount(userInput);//해당 책 수량 조정
                RefreshBorrowBook(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            }
        }

        private void UpdateBookCount(string code)//책 수량 업데이트
        {
            if (code == "")
                return;
            BookDAO.GetDBConnection().DeleteBorrow(code, userFunction.LoginMember.MemberCode, Constant.DELETE_BORROW);//책 반납
            Log.GetLog().LogAdd(userFunction.LoginMember.Id+" '" + bookList.Find(book=>book.Id==code).Name + "' 도서 반납");
            exceptionView.SearchComplete(code.Length, "  (반납이 완료되었습니다!))");

        }

        private string InsertNameAndCode(string userInput, int type)//정보를 검색하고 도서코드를 입력하는메소드
        {
            int selectedSector=0;
            bool isNotSearch = true;
            //제목,작가명,출판사로 검색을 가능하게 함
            storage.Init();
            while (isNotSearch) {
                selectedSector = KeyProcessing.GetInput().SwicthSector(4,selectedSector);
                switch (selectedSector)
                {
                    case Constant.FIRST_MENU:
                        storage.Name=SelectBookData();//도서명 입력
                        break;
                    case Constant.SECOND_MENU:
                        storage.Author = SelectBookData();//저자명 입력
                        break;
                    case Constant.THIRD_MENU:
                        storage.Publisher = SelectBookData();//출판사명 입력
                        break;
                    case Constant.FOURTH_MENU://조회
                        isNotSearch = false;
                        break;
                    case Constant.ESCAPE_INT:
                        return Constant.ESCAPE;
                }
            }
            if(userFunction.LoginMember!=null)
                Log.GetLog().LogAdd(userFunction.LoginMember.Id +" '"+storage.Name+","+storage.Author+","+storage.Publisher+"'(으)로 도서검색");
            else
                Log.GetLog().LogAdd("관리자 '" + storage.Name + "," + storage.Author + "," + storage.Publisher + "'(으)로 도서검색");
            SpreadBook(type, storage.Name, storage.Author, storage.Publisher);//검색한 정보 출력
            if (type != Constant.SEARCH_BOOK)//단순 조회가 아닐 경우 (매직넘버)
            {
                bool isExisted = Constant.IS_EXCEPTION;
                while (!isExisted)
                {
                    Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, (int)Constant.SectorCursor.BOOK_CODE_CURSOR);
                    userInput = KeyProcessing.GetInput().GetUserString(10, Constant.NOT_PASSWORD_TYPE);//도서코드 입력
                    if (userInput==Constant.ESCAPE_STRING)
                        return userInput;
                    isExisted = true;
                    if (!bookList.Exists(book => book.Id == userInput))//검색정보중에 코드와 일치하는 도서 있는지 확인
                    {
                        isExisted = false;
                        exceptionView.SearchException(userInput.Length, "  (일치하는 정보가 존재하지 않습니다!)");
                    }
                }
            }
            return userInput;
        }

        private string SelectBookData()//교수명 입력
        {
            string userInput;
            //ui
            Console.CursorVisible = true;
            //기존에 쓰여 있던 정보 없애주기
            userInput = Constant.EMPTY;
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop);
            //기존에 쓰여있던 문자열 지워주기
            basicUI.DeleteString(Console.CursorLeft, Console.CursorTop);
            basicUI.SearchForm();
            Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, Console.CursorTop);
            userInput = KeyProcessing.GetInput().GetUserString(10, Constant.NOT_PASSWORD_TYPE);
            if (userInput == Constant.ESCAPE_STRING|| userInput == Constant.EMPTY)//esc감지
            {
                userInput = Constant.EMPTY;
                basicUI.DeleteString(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop);
            }
            Console.CursorVisible = false;
            return userInput;
        }

        private void SpreadBook(int type,string name, string author, string publisher)
        {
            switch (type)//타입에 따라 가이드 다르게 출력
            {
                case Constant.BOOK_BORROW:
                    RefreshBook(name, author, publisher,bookUI.BorrowGuide, Constant.USER_BOOK);//대여 시 조회
                    break;
                case Constant.BOOK_RETURN:
                    RefreshBorrowBook(name, author, publisher);//반납 시 조회
                    break;
                case Constant.BOOK_DELETE:
                    RefreshBook(name, author, publisher, bookUI.DeleteGuide, Constant.ADMIN_BOOK);//삭제 시 조회
                    break;
                case Constant.BOOK_REVISE:
                    RefreshBook(name, author, publisher, bookUI.ReviseGuide, Constant.ADMIN_BOOK);//수정 시 조회
                    break;
                case Constant.SEARCH_BOOK://단순조회
                    RefreshBook(name, author, publisher, bookUI.SearchGuide, Constant.USER_BOOK);
                    break;
            }
        }
        private void RefreshBook(string name, string author, string publisher,bookForm action,int type)//조회시 출력
        {
            Console.Clear();
            basicUI.LibraryLabel();
            action();
            ShowBookList(name, author, publisher,type);
        }

        private void RefreshBorrowBook(string name, string author, string publisher)//반납시 출력
        {
            Console.Clear();
            basicUI.LibraryLabel();
            bookUI.ReturnGuide();
            ShowMyBook(name, author, publisher);
        }

        public void ShowBestBook()
        {
            RefreshBook("", "", "",bookUI.BestBookGuide, Constant.BEST_BOOK);
            KeyProcessing.GetInput().IsEscAndEnter();
        }
    }
}
