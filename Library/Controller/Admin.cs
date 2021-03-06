using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class Admin : User//관리자 관련 메소드 구현 클래스
    {
        List<MemberDTO> memberList;
        BookDTO bookStorage;
        NaverBook naverBook;
        List<ItemData> items;
        delegate void Clear();
        public Admin(ExceptionAndView exceptionAndView) : base(exceptionAndView)
        {
            bookStorage = new BookDTO("","","","",0,"","","","");
            naverBook = new NaverBook(exceptionView);
        }
        public void AdminLogin()//id="11111111111" ,password="9999999999" 관리자 로그인
        {
            string id;
            string password;
            bool isCorrect = false;
            Console.Clear();
            basicUI.AdminLabel();
            basicUI.AdminLoginForm();
            while (!isCorrect)//관리자 아이디,비번과 일치할 때까지 입력
            {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ID_LOGIN_INDEX);
                id = KeyProcessing.GetInput().GetUserString(Constant.ID_LENGTH, Constant.NOT_PASSWORD_TYPE);//아이디 입력
                if (id == Constant.ESCAPE_STRING)
                    return;
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                password = KeyProcessing.GetInput().GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);//비밀번호 입력
                if (password == Constant.ESCAPE_STRING)
                    return;
                MemberDTO admin = MemberDAO.GetDBConnection().SelectAdmin();
                isCorrect = (id == admin.Id && password == admin.Password);
                if (!isCorrect)//오입력 시 예외 출력
                    exceptionView.AdminError(password.Length);
            }
            LogDAO.GetLog().LogAdd( "관리자 로그인");
            AdminSelectMenu();//로그인 성공 시 관리자 메뉴 선택
            LogDAO.GetLog().LogAdd("관리자 로그아웃");
        }
        public void AdminSelectMenu()//관리자 메뉴 선택
        {
            int selectedMenu = 0;
            bool isExit = false;
            while (!isExit)
            {
                if (selectedMenu == Constant.ESCAPE_INT)
                    selectedMenu = 0;
                selectedMenu = menuSelection.SelectAdminMenu(selectedMenu);
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        ManageBook();//도서 관리
                        break;
                    case Constant.SECOND_MENU:
                        ManageMember();//멤버 관리
                        break;
                    case Constant.THIRD_MENU:
                        LogManage();//멤버 관리
                        break;
                    case Constant.ESCAPE_INT://ESC감지
                        isExit = exception.IsEscape();
                        break;
                    case Constant.FOURTH_MENU://프로그램 종료
                        exception.ExitProgramm();
                        break;
                }
            }
        }
        private void ManageBook()//책 관리 메소드
        {
            bool isInsert = false;
            int selectedMenu = 0;
            while (!isInsert)
            {
                if (selectedMenu == Constant.ESCAPE_INT)
                    selectedMenu = 0;
                selectedMenu = menuSelection.SelectBookMenu(selectedMenu);
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:// 단순 조회
                        bookFunction.SearchAndChoice(Constant.SEARCH_BOOK);
                        break;
                    case Constant.SECOND_MENU:
                        bookFunction.SearchAndChoice(Constant.BOOK_REVISE);//책 수량 수정
                        break;
                    case Constant.THIRD_MENU:
                        bookFunction.SearchAndChoice(Constant.BOOK_DELETE);//책 삭제
                        break;
                    case Constant.FOURTH_MENU:// 책 추가
                        AddBook();
                        break;
                    case Constant.FIFTH_MENU:
                        SearchNaver();
                        break;
                    case Constant.SIXTH_MENU:// 책 추가
                        AddNaverBook();
                        break;
                    case Constant.ESCAPE_INT://ESC감지
                        return;
                }
            }
        }
        private void ManageMember()//유저 관리 메소드
        {
            bool isInsert = false;
            int selectedMenu = 0;
            while (!isInsert)
            {
                if (selectedMenu == Constant.ESCAPE_INT)
                    selectedMenu = 0;
                selectedMenu = menuSelection.SelectMemberMenu(selectedMenu);
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU://유저 단순 조회
                        SearchAndChoiceMember(Constant.MEMBER_SEARCH);
                        break;
                    case Constant.SECOND_MENU://유저 정보 수정
                        SearchAndChoiceMember(Constant.MEMBER_REVISE);
                        break;
                    case Constant.THIRD_MENU://유저 삭제
                        SearchAndChoiceMember(Constant.MEMBER_DELETE);
                        break;
                    case Constant.FOURTH_MENU://도서 대여 현황
                        SearchAndChoiceMember(Constant.MEMBER_BORROW);
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }
        private void ShowMemberList(string name, string id, string phonenumber)//유저정보 조회
        {
            List<MemberDTO> findList = new List<MemberDTO>();//찾은 멤버 리스트 저장
            MemberDAO.GetDBConnection().SelectMember(id, name, phonenumber, findList);
            //검색 정보와 일치하는 유저 정보들 찾은 후 전역 멤버 리스트로 넘겨주기
            memberList = findList;
        }
        public void SearchAndChoiceMember(int type)//유저 정보 검색 및 선택
        {
            string userInput = Constant.EMPTY;
            string id = Constant.EMPTY;
            string name = Constant.EMPTY;
            string phonenumber = Constant.EMPTY;
            Refresh(name, id, phonenumber, type);
            while (userInput != Constant.ESCAPE)
            {
                userInput = InsertNameAndPersonal(userInput, type);//검색 정보 입력과 회원 코드 입력 메소드 호출
                if (userInput == Constant.ESCAPE)
                    return;
                if (userInput != Constant.ESCAPE_STRING)
                {
                    switch (type)
                    {
                        case Constant.MEMBER_REVISE:
                            AdminReviseMember(userInput);///검색한 정보와 입력한 회원코드를 토대로 회원정보 수정
                            break;
                        case Constant.MEMBER_DELETE:
                            DeleteMember(userInput);//검색한 정보와 입력한 회원코드를 토대로 회원 삭제
                            break;
                        case Constant.MEMBER_SEARCH://단순 조회 시 회원코드 조회 안함(매직넘버)
                            break;
                        case Constant.MEMBER_BORROW://단순 조회 시 회원코드 조회 안함(매직넘버)
                            BorrowList(userInput);
                            Refresh(name, id, phonenumber, type);
                            break;
                    }
                }
            }
        }
        private void BorrowList(string membercode)
        {
            basicUI.BorrowList();
            List<BookDTO> bookList = new List<BookDTO>();
            BookDAO.GetDBConnection().SelectBorrow("", "", "", membercode,bookList);
            KeyProcessing.GetInput().IsEscAndEnter();
        }
        private string InsertNameAndPersonal(string userInput, int type)//검색 정보 입력과 회원 코드 입력 메소드
        {
            storage.Id = Constant.EMPTY;
            storage.Name = Constant.EMPTY;
            storage.PhoneNumber = Constant.EMPTY;
            int selectedSector = 0;
            bool isNotSearch = true;
            //제목,작가명,출판사로 검색을 가능하게 함
            while (isNotSearch)
            {
                selectedSector = KeyProcessing.GetInput().SwicthSector(Constant.MEMBER_SEARCH, selectedSector);
                switch (selectedSector)
                {
                    case Constant.FIRST_MENU:
                        storage.Id = SelectUserData((int)Constant.MemberSearch.ID);//아이디
                        break;
                    case Constant.SECOND_MENU:
                        storage.Name = SelectUserData((int)Constant.MemberSearch.NAME);//이름
                        break;
                    case Constant.THIRD_MENU:
                        storage.PhoneNumber = SelectUserData((int)Constant.MemberSearch.PHONE);//전화번호
                        break;
                    case Constant.FOURTH_MENU:
                        isNotSearch = false;
                        break;
                    case Constant.ESCAPE_INT:
                        return Constant.ESCAPE;
                }
            }
            LogDAO.GetLog().LogAdd("관리자 \"" + storage.Id + "\" \"" + storage.Name + "\" \"" + storage.PhoneNumber + "\"(으)로 회원검색");
            Refresh(storage.Name, storage.Id, storage.PhoneNumber, type);//검색한 정보 토대로 회원 검색 해 출력
            if (type != Constant.MEMBER_SEARCH)//단순 조회 아닐 시(매직넘버)
            {
                bool isExisted = Constant.IS_EXCEPTION;
                while (!isExisted)
                {
                    Console.SetCursorPosition(1, Constant.CODE_INDEX + 4);
                    userInput = KeyProcessing.GetInput().GetUserString(Constant.MEMBER_PERSONALCODE_LENGTH, Constant.NOT_PASSWORD_TYPE);//매직넘버
                    if (userInput == Constant.ESCAPE_STRING)//ESC나 엔터 입력 시에는 빠져나오기
                        return userInput;
                    isExisted = true;
                    if (!memberList.Exists(member => member.MemberCode == userInput))//검색 정보와 일치하는 맴버 입력 때까지 계속 입력
                    {
                        isExisted = false;
                        exceptionView.SearchException(userInput.Length, "  (일치하는 정보가 존재하지 않습니다!)");
                    }
                }
            }

            return userInput;
        }
        private string SelectUserData(int type)//검색할 정보를 입력받는 함수
        {
            string userInput = Constant.EMPTY;
            bool isException = true;
            //ui
            Console.CursorVisible = true;
            //기존에 쓰여있던 문자열 지워주기
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop);
            basicUI.DeleteString(Console.CursorLeft, Console.CursorTop);
            basicUI.SearchForm();
            while (isException)
            {
                Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, Console.CursorTop);
                //정보 입력
                userInput = KeyProcessing.GetInput().GetUserString(10, Constant.NOT_PASSWORD_TYPE);
                if (userInput == Constant.ESCAPE_STRING || userInput == Constant.EMPTY)//esc감지
                {
                    userInput = Constant.EMPTY;
                    basicUI.DeleteString(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop);
                    break;
                }
                switch (type)//타입별로 다른 예외처리 적용
                {
                    case (int)Constant.MemberSearch.ID:
                        isException = !exception.IsExceptionIdPassword(userInput, Constant.SEARCH_TYPE);
                        break;
                    case (int)Constant.MemberSearch.NAME:
                        isException = !exception.IsNameException(userInput, Constant.SEARCH_TYPE);
                        break;
                    case (int)Constant.MemberSearch.PHONE:
                        isException = !exception.IsNumber(userInput, Constant.SEARCH_TYPE);
                        break;
                    case (int)Constant.MemberSearch.DISPLAY:
                        isException = !exception.IsNumber(userInput, Constant.SEARCH_TYPE);
                        if (isException == false && (userInput == "0" || int.Parse(userInput) > 100))
                        {
                            exceptionView.SearchException(userInput.Length, "  (양식에 맞는 숫자를 입력해주세요!)");
                            isException = true;
                        }
                        break;
                    default:
                        isException = false;
                        break;
                }
            }
            Console.CursorVisible = false;
            return userInput;
        }
        private void AdminReviseMember(string code)//개인정보 수정
        {
            if (code == Constant.EMPTY)
                return;
            MemberDTO member = MemberDAO.GetDBConnection().GetMember(code);//회원코드와 일치하는 멤버 찾기
            if (member != null)
            {
                this.LoginMember = member;
                ReviseMember();//멤버 정보 수정
                this.LoginMember = null;
                Refresh(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY, Constant.MEMBER_REVISE);
            }
            else
                exceptionView.SearchException(code.Length, "  (일치하는 유저가 존재하지 않습니다!)");
        }
        private void DeleteMember(string code)//회원 삭제
        {
            if (code == Constant.EMPTY)
                return;
            MemberDTO member = MemberDAO.GetDBConnection().GetMember(code);//회원정보 일치하는 멤버 찾기
            Refresh("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer", Constant.MEMBER_DELETE);//기존 회원정보 출력 없애기
            if (member != null)
            {
                if (MemberDAO.GetDBConnection().IsHaveBook(member.MemberCode))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    exceptionView.SearchException(member.MemberCode.Length, "  (대여중인 도서가 있는 회원입니다!)");
                }
                else if (exception.IsDelete(member.Name + " 회원"))//삭제 한번 더 확인
                {
                    MemberDAO.GetDBConnection().DeleteMember(code);
                    LogDAO.GetLog().LogAdd("관리자 "+member.Id+" 회원 삭제");
                }
            }
            else
                exceptionView.SearchException(code.Length, "  (일치하는 유저가 존재하지 않습니다!)");
            Refresh(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY, Constant.MEMBER_DELETE);
        }
        private void Refresh(string name, string id, string phonenumber, int type)//재조회
        {
            Console.Clear();
            basicUI.AdminLabel();
            switch (type)//수정,삭제,단순 조회에 따라 가이드UI다르게 출력
            {
                case Constant.MEMBER_REVISE:
                    memberUI.MemberReviseGuide();
                    break;
                case Constant.MEMBER_DELETE:
                    memberUI.MemberDeleteGuide();
                    break;
                case Constant.MEMBER_SEARCH:
                    memberUI.MemberSearchGuide();
                    break;
                case Constant.MEMBER_BORROW:
                    memberUI.CheckBorrowGuide();
                    break;
            }
            ShowMemberList(name, id, phonenumber);//검색한 정보 바탕으로 리스트 출력
        }

        private bool IsEmpty(string userInput)//공백 확인
        {
            if (userInput == Constant.EMPTY)
            {
                exceptionView.InsertException(0, "(아무것도 입력하지 않았습니다!)");
                return false;
            }
            return true;
        }
        private bool IsNatural(string userInput, bool isException)
        {
            if (userInput == "0")
            {
                isException = Constant.IS_EXCEPTION;
                exceptionView.InsertException(userInput.Length, "  (0보다 큰 숫자를 입력해 주세요!)");
            }
            return isException;
        }
        private void RefreshNaver()//네이버 검색FORM
        {
            Console.Clear();
            basicUI.AdminLabel();
            bookUI.NaverGuide();
        }
        private void RefreshAdd()//도서 추가 FORM
        {
            Console.Clear();
            basicUI.AdminLabel();
            bookUI.NaverGuide();
            bookUI.NaverAddForm();
        }
        private void SearchNaver()//단순 네이버 조회
        {
            bool isNotEscape = true;
            RefreshNaver();
            while (isNotEscape)
            {
                isNotEscape = IsInsertQueryDisplay(RefreshNaver);
            }
        }
        private void AddNaverBook()//도서추가
        {
            bool isNotEscape = true;
            RefreshAdd();
            while (isNotEscape)
            {
                isNotEscape = IsInsertQueryDisplay(RefreshAdd);//네이버로 책 검색
                if (!isNotEscape)
                    return;
                SelectNaverBook(items.Count);//추가할 책 선택 후 추가
            }
        }
        private bool IsInsertQueryDisplay(Clear clear)//검색어와 수량을 입력해 리스트 받아오기
        {
            int selectedSector = 0;
            bool isNotSearch = true;
            string query = "";
            string display = "";
            int sequence = 1;

            //제목,작가명,출판사로 검색을 가능하게 함
            while (isNotSearch)
            {
                selectedSector = KeyProcessing.GetInput().SwicthSector(Constant.NAVER_SEARCH, selectedSector);
                switch (selectedSector)
                {
                    case Constant.FIRST_MENU:
                        query = SelectUserData((int)Constant.MemberSearch.QUERY);//검색어
                        break;
                    case Constant.SECOND_MENU:
                        display = SelectUserData((int)Constant.MemberSearch.DISPLAY);//수량
                        break;
                    case Constant.THIRD_MENU:
                        if (exception.IsInsertNaver(query, display))//정보를 다 입력해야 검색가능
                            isNotSearch = false;
                        break;
                    case Constant.ESCAPE_INT:
                        return false;
                }
            }
            LogDAO.GetLog().LogAdd("관리자 네이버에서 검색어 \"" + query+ "\"(으)로 " + display+"개의 도서 검색");//로그 추가
            items = naverBook.GetRequestResult(query, display);//데이터 받아오기
            clear();
            if (items != null)
            {
                foreach (ItemData item in items)//받아온 데이터 출력
                {
                    bookUI.NaverBookInformation(item, sequence++);
                }
            }

            return true;
        }
        private void SelectNaverBook(int sequence)//네이버 검색으로 도서 추가
        {
            int selectSequence = SelectNumber(sequence + 1, (int)Constant.SectorCursor.BOOK_CODE_CURSOR, "  (검색목록 중에서 골라주세요!)");//도서번호 선택
            if (selectSequence == Constant.ESCAPE_INT)
                return;
            int quantity = SelectNumber(101, (int)Constant.SectorCursor.BOOK_QUANTITY_CURSOR, "  (알맞은 수량을 입력해주세요!)");//수량 선택
            if (quantity == Constant.ESCAPE_INT)
                return;
            //도서 추가
            BookDTO book = new BookDTO(items[selectSequence - 1].title, items[selectSequence - 1].publisher, items[selectSequence - 1].author, items[selectSequence - 1].price, quantity, items[selectSequence - 1].isbn.Substring(0, 10), items[selectSequence - 1].description, items[selectSequence - 1].pubdate,"");
            if (BookDAO.GetDBConnection().IsExistedBookIsbn(book.Isbn))
            {
                exceptionView.SearchException(quantity.ToString().Length, " (이미 추가된 도서입니다!)");
                return;
            }
            BookDAO.GetDBConnection().InsertBook(book);
            LogDAO.GetLog().LogAdd("관리자 \"" + book.Name + "\" 도서 추가");
            exceptionView.SearchComplete(quantity.ToString().Length, " (추가되었습니다!)");
        }
        private int SelectNumber(int sequence, int cursor,string label)//네이버검색 후 도서번호와 추가수량을 입력받는 함수
        {
            bool isNotExisted = true;
            string userInput = "";
            while (isNotExisted)
            {
                Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, cursor);
                userInput = KeyProcessing.GetInput().GetUserString(3, Constant.NOT_PASSWORD_TYPE);//숫자 입력
                if (userInput == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_INT;
                isNotExisted = !exception.IsNumber(userInput, Constant.SEARCH_TYPE);
                if (!isNotExisted && (userInput == "0" || int.Parse(userInput) >= sequence))//숫자 예외처리
                {
                    isNotExisted = true;
                    exceptionView.SearchException(userInput.Length, label);
                }
            }

            return int.Parse(userInput);
        }
        public void AddBook()//책 추가 메소드
        {
            int selectedSector = 0;
            bool isNotComplete = true;
            //책 정보 초기화
            bookStorage=new BookDTO("","","","",0,"","","","");
            Console.Clear();
            basicUI.AdminLabel();
            bookUI.AddBook();
            while (isNotComplete)//마지막 정보 입력 전 까지 계속 입력
            {
                selectedSector = KeyProcessing.GetInput().SwicthSector(8, selectedSector);
                switch (selectedSector)//위쪽 방향키와 엔터 감지로 입력 원하는 정보 찾기
                {

                    case (int)Constant.Menu.FIRST_MENU:
                        bookStorage.Isbn = SetData(Constant.ID_ADD_INDEX, bookStorage.Id);//책 코드
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        bookStorage.Name = SetData(Constant.PASSWORD_ADD_INDEX, bookStorage.Name);//도서명
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        bookStorage.Publisher = SetData(Constant.PASSWORD_CONFIRM_INDEX, bookStorage.Publisher);//출판사
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        bookStorage.Author = SetData(Constant.NAME_ADD_INDEX, bookStorage.Author);//저자
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        bookStorage.Price = SetData(Constant.PERSONAL_ADD_INDEX, bookStorage.Price);//가격
                        break;
                    case (int)Constant.Menu.SIXTH_MENU:
                        bookStorage.Quantity = int.Parse(SetData(Constant.PHONE_ADD_INDEX, Constant.EMPTY));//수량
                        break;
                    case (int)Constant.Menu.SEVENTH_MENU:
                        bookStorage.Pubdate = SetData(Constant.PHONE_ADD_INDEX+2, Constant.EMPTY);//수량
                        break;
                    case (int)Constant.Menu.EIGHTH_MENU:
                        if (exception.IsBookNull(bookStorage))//회원가입 OR 정보수정 시 빠뜨린 것 없는지 확인
                            isNotComplete = false;
                        else
                            exceptionView.InsertException(20, "  (정보를 다 입력해주세요!)");
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
            if (IsConfirm(Constant.CONFRIM_ADD))//추가할 것인지 한번 더 확인
            {
                BookDTO book = new BookDTO(bookStorage.Name, bookStorage.Publisher, bookStorage.Author, bookStorage.Price, bookStorage.Quantity, bookStorage.Isbn,"",bookStorage.Pubdate,"");
                BookDAO.GetDBConnection().InsertBook(book);
            }
        }
        private string SetData(int index, string userInput)//데이터 입력을 받고 상황별로 다른 예외처리를 해 예외가 없을때까지 입력받는 메소드
        {
            bool isException = Constant.IS_EXCEPTION;
            while (!isException)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX + 2, index);
                basicUI.DeleteString(Console.CursorLeft, Console.CursorTop, 70);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX://도서코드 입력
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.BOOK_ID_LENGTH, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsBookIdException(userInput, Constant.BOOK_ID_LENGTH);
                        break;
                    case Constant.PASSWORD_ADD_INDEX:
                        userInput = KeyProcessing.GetInput().GetUserString(20, Constant.NOT_PASSWORD_TYPE);//도서명 입력
                        isException = IsEmpty(userInput);
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX:
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.BOOK_STRING_LENGTH, Constant.NOT_PASSWORD_TYPE);//출판사 입력
                        isException = IsEmpty(userInput);
                        break;
                    case Constant.NAME_ADD_INDEX:
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.BOOK_STRING_LENGTH, Constant.NOT_PASSWORD_TYPE);//저자명 입력
                        isException = IsEmpty(userInput);
                        break;
                    case Constant.PERSONAL_ADD_INDEX:
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.BOOK_PRICE_LENGTH, Constant.NOT_PASSWORD_TYPE);//가격 입력
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsNumber(userInput, Constant.INSERT_TYPE);
                        isException = IsNatural(userInput, isException);
                        break;
                    case Constant.PHONE_ADD_INDEX:
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.BOOK_QUANTITY_LENGTH, Constant.NOT_PASSWORD_TYPE);//수량 입력
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsNumber(userInput, Constant.INSERT_TYPE);
                        isException = IsNatural(userInput, isException);
                        break;
                    case Constant.PHONE_ADD_INDEX+2:
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.BOOK_ID_LENGTH, Constant.NOT_PASSWORD_TYPE);//수량 입력
                        isException = exception.IsDate(userInput);
                        break;
                }
                if (userInput == Constant.ESCAPE_STRING)
                {
                    userInput = Constant.EMPTY;
                    basicUI.DeleteString(Constant.ADD_INDEX + 2, Console.CursorTop, 70);
                    return userInput;
                }
            }
            exceptionView.InsertComplete(userInput.Length * 2, "  (완료되었습니다!))");
            return userInput;
        }
        private bool IsConfirm(int type)//기능 수행 후 재확인 
        {
            if (type == Constant.CONFRIM_ADD)//회원가입인지 확인
                basicUI.ConfirmAddForm();
            else
                basicUI.ReviseDone();//수정인지 확인
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                return false;
            return true;
        }
        private void LogManage()
        {
            bool isInsert = false;
            int selectedMenu = 0;
            while (!isInsert)
            {
                if (selectedMenu == Constant.ESCAPE_INT)
                    selectedMenu = 0;
                selectedMenu = menuSelection.SelectLogMenu(selectedMenu);
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU://로그 조회
                        LogDAO.GetLog().ShowLog();
                        KeyProcessing.GetInput().IsEscAndEnter();
                        break;
                    case Constant.SECOND_MENU://로그 초기화
                        LogDAO.GetLog().LogInit();
                        break;
                    case Constant.THIRD_MENU://로그 초기화
                        ReviseLog();
                        break;
                    case Constant.FOURTH_MENU://로그 저장
                        LogDAO.GetLog().SaveLogFile();
                        break;
                    case Constant.FIFTH_MENU://로그 삭제
                        LogDAO.GetLog().DeleteLogFile();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }

        private void ReviseLog()
        {
            while (true)
            {
                Console.Clear();
                basicUI.AdminLabel();
                basicUI.LogGuide();
                basicUI.LogMenu();
                LogDAO.GetLog().ShowLog();
                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("제거할 로그번호를 입력해주세요!");
                Console.Write(":");
                if (LogDAO.GetLog().Revise() == Constant.ESCAPE_STRING)
                    return;
            }
        }
    }
} 