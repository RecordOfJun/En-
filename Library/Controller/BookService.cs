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
        BasicView ui;
        Input input;
        BookVO storage;
        DBConnection dBConnection;
        public BookService(VOList voList, User userFunction,ExceptionAndView exceptionAndView)
        {
            this.dBConnection = DBConnection.GetDBConnection();
            storage = new BookVO();
            exception = exceptionAndView.exception;
            ui = exceptionAndView.ui;
            exceptionView = exceptionAndView.exceptionView;
            this.voList = voList;
            this.userFunction = userFunction;
            input = new Input(ui);
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
                        case 5://단순 조회
                            break;
                    }
                }
            }
        }
        private void ShowBookList(string name,string author,string publisher)//책 검색 메소드
        {
            List<BookVO> findList = new List<BookVO>();
            //입력한 정보와 일치하는 책 찾아 전역 리스트에 대입 AND 찾은 책 출력
            dBConnection.SelectBook(name, author, publisher, findList);
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
                    exceptionView.AlreadyHas(bookCode.Length);//이미 빌린 책인지 확인
                    return;
                }
                dBConnection.InsertBorrow(bookCode, userFunction.LoginMember.MemberCode);//책 대여
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
                dBConnection.DeleteBorrow(bookCode, Constant.EMPTY, Constant.DELETE_BOOK);
                dBConnection.DeleteBook(bookCode);
                exceptionView.DeleteSuccess(bookCode.Length);//삭제 완료
            }
            RefreshAdminBook(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
        }
        private void ReviseBook(string bookCode)//책 수량 설정 메소드
        {
            if (bookCode == Constant.EMPTY)
                return ;
            bool isNumber = false;
            string quantity=Constant.EMPTY;
            while (!isNumber) {//0보다 큰 숫자가 들어올 때까지 입력
                Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, (int)Constant.SectorCursor.BOOK_QUANTITY_CURSOR);
                quantity = input.GetUserString(2, Constant.NOT_PASSWORD_TYPE);
                if (quantity == Constant.ESCAPE)
                    return;
                isNumber = exception.IsNumber(quantity, Constant.INSERT_TYPE);
                if (quantity == "0")
                {
                    isNumber = Constant.IS_EXCEPTION;
                    exceptionView.QuantityReviseException(quantity.Length);
                }
            }
            BookVO book = bookList.Find(element => element.Id == bookCode) ;//코드와 일치하는 책 찾음
            ReviseAdminBook("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer");
            if (exception.IsRevise(book.Name))//수정할 것인지 한번 더 확인
            {
                dBConnection.UpdateBook(int.Parse(quantity),bookCode);
            }
            ReviseAdminBook(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY);
            return;
        }
        private void ShowMyBook(string name, string author, string publisher)//대여중인 도서 조회 메소드
        {
            List<BookVO> findList = new List<BookVO>();
            //찾은 책 리스트 전역 책 리스트로 넘겨주고 정보 출력
            dBConnection.SelectBorrow(name, author, publisher, userFunction.LoginMember.MemberCode, findList);
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
            dBConnection.DeleteBorrow(code, userFunction.LoginMember.MemberCode, Constant.DELETE_BORROW);
            exceptionView.ReturnSuccess(code.Length);//완료

        }
        private string InsertNameAndCode(string userInput, int type)//정보를 검색하고 도서코드를 입력하는메소드
        {
            int selectedSector=0;
            bool isNotSearch = true;
            //제목,작가명,출판사로 검색을 가능하게 함
            storage.Init();
            while (isNotSearch) {
                selectedSector = input.SwicthSector(4,selectedSector);
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
                    case Constant.FOURTH_MENU:
                        isNotSearch = false;
                        break;
                    case Constant.ESCAPE_INT:
                        return Constant.ESCAPE;
                }
            }
            SpreadBook(type, storage.Name, storage.Author, storage.Publisher);//검색한 정보 출력
            if (type != 5)//단순 조회가 아닐 경우 (매직넘버)
            {
                bool isExisted = Constant.IS_EXCEPTION;
                while (!isExisted)
                {
                    Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, (int)Constant.SectorCursor.BOOK_CODE_CURSOR);
                    userInput = input.GetUserString(10, Constant.NOT_PASSWORD_TYPE);//도서코드 입력
                    if (userInput==Constant.ESCAPE_STRING)
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
        private string SelectBookData()//교수명 입력
        {
            string userInput;
            //ui
            Console.CursorVisible = true;
            //기존에 쓰여 있던 정보 없애주기
            userInput = Constant.EMPTY;
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop);
            //기존에 쓰여있던 문자열 지워주기
            ui.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            ui.SearchForm();
            Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, Console.CursorTop);
            userInput = input.GetUserString(10, Constant.NOT_PASSWORD_TYPE);
            if (userInput == Constant.ESCAPE_STRING|| userInput == Constant.EMPTY)//esc감지
            {
                userInput = Constant.EMPTY;
                ui.DeleteString(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop, Constant.COLUMN_DELETE);
            }
            Console.CursorVisible = false;
            return userInput;
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
            ui.LibraryLabel();
            ui.DeleteGuide();
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
