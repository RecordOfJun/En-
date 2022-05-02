﻿using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class Admin: User//관리자 관련 메소드 구현 클래스
    {
        List<MemberVO> memberList;
        BookVO bookStorage;
        NaverBook naverBook;
        List<ItemData> items;
        delegate void Clear();
        public Admin(ExceptionAndView exceptionAndView):base(exceptionAndView)
        {
            bookStorage = new BookVO();
            naverBook = new NaverBook();
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
                id= KeyProcessing.GetInput().GetUserString(Constant.ID_LENGTH, Constant.NOT_PASSWORD_TYPE);//아이디 입력
                if (id == Constant.ESCAPE_STRING)
                    return;
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                password = KeyProcessing.GetInput().GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);//비밀번호 입력
                if (password == Constant.ESCAPE_STRING)
                    return;
                MemberVO admin = DBConnection.GetDBConnection().SelectAdmin();
                isCorrect = (id == admin.Id && password == admin.Password);
                if (!isCorrect)//오입력 시 예외 출력
                    exceptionView.AdminError(password.Length);
            }
            AdminSelectMenu();//로그인 성공 시 관리자 메뉴 선택
        }
        public void AdminSelectMenu()//관리자 메뉴 선택
        {
            int selectedMenu=0;
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
                    case Constant.ESCAPE_INT://ESC감지
                        isExit = exception.IsEscape();
                        break;
                    case Constant.THIRD_MENU://프로그램 종료
                        exception.ExitProgramm();
                        break;
                }
            }
        }
        private void ManageBook()//책 관리 메소드
        {
            bool isInsert = false;
            int selectedMenu=0;
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
                    case Constant.ESCAPE_INT://ESC감지
                        return;
                }
            }
        }
        private void ManageMember()//유저 관리 메소드
        {
            bool isInsert = false;
            int selectedMenu=0;
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
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }
        private void ShowMemberList(string name,string id,string phonenumber)//유저정보 조회
        {
            List<MemberVO> findList = new List<MemberVO>();//찾은 멤버 리스트 저장
            DBConnection.GetDBConnection().SelectMember(id, name, phonenumber,findList);
            //검색 정보와 일치하는 유저 정보들 찾은 후 전역 멤버 리스트로 넘겨주기
            memberList = findList;
        }
        public void SearchAndChoiceMember(int type)//유저 정보 검색 및 선택
        {
            string userInput = Constant.EMPTY;
            string id = Constant.EMPTY;
            string name = Constant.EMPTY;
            string phonenumber = Constant.EMPTY;
            Refresh(name, id, phonenumber,type);
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
                    }
                }
            }
        }
        private string InsertNameAndPersonal(string userInput,int type)//검색 정보 입력과 회원 코드 입력 메소드
        {
            storage.Init();
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
            Refresh(storage.Name, storage.Id, storage.PhoneNumber,type);//검색한 정보 토대로 회원 검색 해 출력
            if (type != Constant.MEMBER_SEARCH)//단순 조회 아닐 시(매직넘버)
            {
                bool isExisted = Constant.IS_EXCEPTION;
                while (!isExisted)
                {
                    Console.SetCursorPosition(1, Constant.CODE_INDEX+4);
                    userInput = KeyProcessing.GetInput().GetUserString(Constant.MEMBER_PERSONALCODE_LENGTH, Constant.NOT_PASSWORD_TYPE);//매직넘버
                    if (userInput == Constant.ESCAPE_STRING)//ESC나 엔터 입력 시에는 빠져나오기
                        return userInput;
                    isExisted = true;
                    if (!memberList.Exists(member=>member.MemberCode==userInput))//검색 정보와 일치하는 맴버 입력 때까지 계속 입력
                    {
                        isExisted = false;
                        exceptionView.SearchException(userInput.Length, "  (일치하는 정보가 존재하지 않습니다!)");
                    }
                }
            }

            return userInput;
        }
        private string SelectUserData(int type)
        {
            string userInput=Constant.EMPTY;
            bool isException=true;
            //ui
            Console.CursorVisible = true;
            //기존에 쓰여 있던 정보 없애주기
            Console.SetCursorPosition(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop);
            //기존에 쓰여있던 문자열 지워주기
            basicUI.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.COLUMN_DELETE);
            basicUI.SearchForm();
            while (isException)
            {
                Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, Console.CursorTop);
                //교수명 입력
                userInput = KeyProcessing.GetInput().GetUserString(10, Constant.NOT_PASSWORD_TYPE);
                if (userInput == Constant.ESCAPE_STRING || userInput == Constant.EMPTY)//esc감지
                {
                    userInput = Constant.EMPTY;
                    basicUI.DeleteString(Constant.COLUMN_PRINT_CURSOR, Console.CursorTop, Constant.COLUMN_DELETE);
                    break;
                }
                switch (type)
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
                        if (isException==false&&(userInput == "0" || int.Parse(userInput) > 100))
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
            MemberVO member = DBConnection.GetDBConnection().GetMember(code);//회원코드와 일치하는 멤버 찾기
            if (member != null)
            {
                this.LoginMember = member;
                AddOrReviseMember(2);//멤버 정보 수정
                Refresh(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY, Constant.MEMBER_REVISE);
            }
            else
                exceptionView.SearchException(code.Length, "  (일치하는 유저가 존재하지 않습니다!)");
        }
        private void DeleteMember(string code)//회원 삭제
        {
            if (code == Constant.EMPTY)
                return;
            MemberVO member = DBConnection.GetDBConnection().GetMember(code);//회원정보 일치하는 멤버 찾기
            Refresh("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer",Constant.MEMBER_DELETE);//기존 회원정보 출력 없애기
            if (member != null)
            {
                if (DBConnection.GetDBConnection().IsHaveBook(member.MemberCode))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    exceptionView.SearchException(member.MemberCode.Length, "  (대여중인 도서가 있는 회원입니다!)");
                }
                else if (exception.IsDelete(member.Name + " 회원"))//삭제 한번 더 확인
                {
                    DBConnection.GetDBConnection().DeleteMember(code);
                }
            }
            else
                exceptionView.SearchException(code.Length, "  (일치하는 유저가 존재하지 않습니다!)");
            Refresh(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY, Constant.MEMBER_DELETE);
        }
        private void Refresh(string name, string id, string phonenumber,int type)//재조회
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
            }
            ShowMemberList(name, id, phonenumber);//검색한 정보 바탕으로 리스트 출력
        }

        private bool IsEmpty(string userInput)
        {
            if (userInput == Constant.EMPTY)
            {
                exceptionView.InsertException(0, "(아무것도 입력하지 않았습니다!)");
                return false;
            }
            return true;
        }

        private bool IsNatural(string userInput,bool isException)
        {
            if (userInput == "0")
            {
                isException = Constant.IS_EXCEPTION;
                exceptionView.InsertException(userInput.Length, "  (0보다 큰 숫자를 입력해 주세요!)");
            }
            return isException;
        }

         string SetData(int index, string userInput)//데이터 입력을 받고 상황별로 다른 예외처리를 해 예외가 없을때까지 입력받는 메소드
        {
            bool isException = Constant.IS_EXCEPTION;
            while (!isException)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX+2, index);
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
                        isException = IsNatural(userInput,isException);
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
        private void RefreshNaver()
        {
            Console.Clear();
            basicUI.AdminLabel();
            bookUI.NaverGuide();
        }
        private void RefreshAdd()
        {
            Console.Clear();
            basicUI.AdminLabel();
            bookUI.NaverGuide();
            bookUI.NaverAddForm();
        }
        private void SearchNaver()
        {
            bool isNotEscape = true;
            RefreshNaver();
            while (isNotEscape)
            {
                isNotEscape=IsInsertQueryDisplay(RefreshNaver);
            }
        }
        private void AddBook()
        {
            bool isNotEscape = true;
            RefreshAdd();
            while (isNotEscape)
            {
                isNotEscape = IsInsertQueryDisplay(RefreshAdd);
                if (!isNotEscape)
                    return;
                NaverAddBook(items.Count);
            }
        }
        private bool IsInsertQueryDisplay(Clear clear)
        {
            int selectedSector = 0;
            bool isNotSearch = true;
            string query="";
            string display="";
            int sequence = 1;
           
            //제목,작가명,출판사로 검색을 가능하게 함
            while (isNotSearch)
            {
                selectedSector = KeyProcessing.GetInput().SwicthSector(Constant.NAVER_SEARCH, selectedSector);
                switch (selectedSector)
                {
                    case Constant.FIRST_MENU:
                        query = SelectUserData((int)Constant.MemberSearch.QUERY);//아이디
                        break;
                    case Constant.SECOND_MENU:
                        display = SelectUserData((int)Constant.MemberSearch.DISPLAY);//이름
                        break;
                    case Constant.THIRD_MENU:
                        if(exception.IsInsertNaver(query,display))
                            isNotSearch = false;
                        break;
                    case Constant.ESCAPE_INT:
                        return false;
                }
            }
            items = naverBook.GetRequestResult(query, display);
            clear();
            foreach (ItemData item in items)
            {
                bookUI.NaverBookInformation(item,sequence++);
            }
            
            return true;
        }
        private void NaverAddBook(int sequence)
        {
            int selectSequence = SelectNumber(sequence+1, (int)Constant.SectorCursor.BOOK_CODE_CURSOR);
            if (selectSequence == Constant.ESCAPE_INT)
                return;
            int quantity = SelectNumber(101, (int)Constant.SectorCursor.BOOK_QUANTITY_CURSOR);
            if (quantity == Constant.ESCAPE_INT)
                return;
            //도서 추가할것인지 확인하기
            BookVO book = new BookVO(items[selectSequence-1].title.Replace("</b>", "").Replace("<b>", ""), items[selectSequence - 1].publisher.Replace("</b>", "").Replace("<b>", ""), items[selectSequence - 1].author.Replace("</b>", "").Replace("<b>", ""), items[selectSequence - 1].price.Replace("</b>", "").Replace("<b>", ""), quantity, items[selectSequence - 1].isbn.Substring(0,10).Replace("</b>", "").Replace("<b>", ""), items[selectSequence - 1].description.Substring(0,50).Replace("</b>", "").Replace("<b>", ""), items[selectSequence - 1].pubdate.Replace("</b>", "").Replace("<b>", ""));
            DBConnection.GetDBConnection().InsertBook(book);
        }
        private int SelectNumber(int sequence, int cursor)
        {
            bool isNotExisted = true;
            string userInput="";
            while (isNotExisted)
            {
                Console.SetCursorPosition(Constant.DATA_INSERT_CURSOR, cursor);
                userInput = KeyProcessing.GetInput().GetUserString(3, Constant.NOT_PASSWORD_TYPE);
                if (userInput == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_INT;
                isNotExisted = !exception.IsNumber(userInput, Constant.SEARCH_TYPE);
                if (!isNotExisted && (userInput == "0" || int.Parse(userInput) >= sequence))
                {
                    isNotExisted = true;
                    exceptionView.SearchException(userInput.Length, "  (검색목록 중에서 골라주세요!)");
                }
            }
            
            return int.Parse(userInput);
        }
    }
} 