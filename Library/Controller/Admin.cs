using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class Admin: User//관리자 관련 메소드 구현 클래스
    {
        List<MemberVO> memberList;
        public Admin(VOList voList, ExceptionAndView exceptionAndView)
        {
            exception = exceptionAndView.exception;
            ui = exceptionAndView.ui;
            exceptionView = exceptionAndView.exceptionView;
            this.voList = voList;
            bookFunction = new BookService(voList, this,exceptionAndView);
        }
        public void AdminLogin()//id="11111111111" ,password="9999999999" 관리자 로그인
        {
            string id;
            string password;
            isBack = false;
            bool isCorrect = false;
            Console.Clear();
            ui.AdminLabel();
            ui.AdminLoginForm();
            while (!isCorrect)//관리자 아이디,비번과 일치할 때까지 입력
            {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ID_LOGIN_INDEX);
                id= GetData(Constant.ID_LENGTH, Constant.EMPTY);
                if (isBack)//ESC뒤로가기
                    return;
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                password = GetData(Constant.PASSWORD_LENGTH, Constant.EMPTY);
                isCorrect = (id == Constant.ADMIN_ID && password == Constant.ADMIN_PASSWORD);
                if (isBack)
                    return;
                if (!isCorrect)//오입력 시 예외 출력
                    exceptionView.AdminError(password.Length);
            }
            AdminSelectMenu();//로그인 성공 시 관리자 메뉴 선택
        }
        public void AdminSelectMenu()//관리자 메뉴 선택
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit)
            {
                selectedMenu = menuSelection.SelectAdminMenu();
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
            int selectedMenu;
            while (!isInsert)//1,2,3,4,ESC만을 감지하여 키 입력 받기
            {
                selectedMenu = menuSelection.SelectBookMenu();
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU://1 입력 시 단순 조회
                        isInsert = true;
                        bookFunction.SearchAndChoice(5);
                        break;
                    case Constant.SECOND_MENU://2 입력 시
                        isInsert = true;
                        bookFunction.SearchAndChoice(Constant.BOOK_REVISE);//책 수량 수정
                        break;
                    case Constant.THIRD_MENU://3 입력 시
                        isInsert = true;
                        bookFunction.SearchAndChoice(Constant.BOOK_DELETE);//책 삭제
                        break;
                    case Constant.FOURTH_MENU://4 입력 시 책 추가
                        AddBook();
                        isInsert = true;
                        break;
                    case Constant.ESCAPE_INT://ESC감지
                        return;
                }
            }
        }
        public void AddBook()//책 추가 메소드
        {
            if (IsConfirm(Constant.CONFRIM_ADD))
            {
                isBack = false;
                bool isComplete = false;
                //책 정보 초기화
                int minimumIndex = 0;
                string id = "";
                string name = "";
                string publisher = "";
                string author = "";
                string price = "";
                string quantity = "";
                Console.Clear();
                ui.AdminLabel();
                ui.AddBook();
                inputType = 0;
                while (!isComplete)//마지막 정보 입력 전 까지 계속 입력
                {
                    if (inputType < minimumIndex)
                        inputType = minimumIndex;
                    switch (inputType)//위쪽 방향키와 엔터 감지로 입력 원하는 정보 찾기
                    {
                        case 0:
                            id = SetData(Constant.ID_ADD_INDEX, id);//책 코드
                            break;
                        case 1:
                            name = SetData(Constant.PASSWORD_ADD_INDEX, name);//도서명
                            break;
                        case 2:
                            publisher = SetData(Constant.PASSWORD_CONFIRM_INDEX, publisher);//출판사
                            break;
                        case 3:
                            author = SetData(Constant.NAME_ADD_INDEX, author);//저자
                            break;
                        case 4:
                            price = SetData(Constant.PERSONAL_ADD_INDEX, price);//가격
                            break;
                        case 5:
                            quantity = SetData(Constant.PHONE_ADD_INDEX, quantity);//수량
                            break;
                        case 6:
                            isComplete = true;
                            break;
                    }
                }
                if (isBack)
                    return;
                if (IsConfirm(Constant.CONFRIM_ADD))//추가할 것인지 한번 더 확인
                {
                    BookVO book = new BookVO(id, name, publisher, author, price, int.Parse(quantity));
                    voList.bookList.Add(book);
                }
            }
        }
        private void ManageMember()//유저 관리 메소드
        {
            bool isInsert = false;
            int selectedMenu;
            while (!isInsert)
            {
                selectedMenu = menuSelection.SelectMemberMenu();
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU://유저 단순 조회
                        isInsert = true;
                        SearchAndChoiceMember(4);
                        break;
                    case Constant.SECOND_MENU://유저 정보 수정
                        isInsert = true;
                        SearchAndChoiceMember(Constant.MEMBER_REVISE);
                        break;
                    case Constant.THIRD_MENU://유저 삭제
                        isInsert = true;
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
            //검색 정보와 일치하는 유저 정보들 찾은 후 전역 멤버 리스트로 넘겨주기
            foreach (MemberVO member in voList.memberList.FindAll(element => element.Name.Contains(name)&&element.Id.Contains(id)&&element.PhoneNumber.Contains(phonenumber)))
            {
                findList.Add(member);
                ui.MemberInformation(member);//찾은 유저 정보 차례대로 출력
            }
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
                switch (type)
                {
                    case Constant.MEMBER_REVISE:
                        AdminReviseMember(userInput);///검색한 정보와 입력한 회원코드를 토대로 회원정보 수정
                        break;
                    case Constant.MEMBER_DELETE:
                        DeleteMember(userInput);//검색한 정보와 입력한 회원코드를 토대로 회원 삭제
                        break;
                    case 4://단순 조회 시 회원코드 조회 안함(매직넘버)
                        break;
                }
            }
        }
        private string InsertNameAndPersonal(string userInput,int type)//검색 정보 입력과 회원 코드 입력 메소드
        {
            string id = Constant.EMPTY;
            string name = Constant.EMPTY;
            string phonenumber = Constant.EMPTY;
            ConsoleKeyInfo key;
            bool isKey = false;
            //제목,작가명,출판사로 검색을 가능하게 함
            while (!isKey)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX, 10);
                key = Console.ReadKey();//아이디,이름,휴대폰 번호 중 어떤 것으로 검색할 것인지 입력받음
                Console.SetCursorPosition(Constant.ADD_INDEX, 10);
                Console.Write("  ");
                isKey = true;
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        id = GetUserData(0,type);//1 입력시 아이디 입력
                        break;
                    case ConsoleKey.D2:
                        name = GetUserData(2,type);//2 입력시 이름 입력
                        break;
                    case ConsoleKey.D3:
                        phonenumber = GetUserData(4,type);//3 입력시 전화번호 입력
                        break;
                    case ConsoleKey.Enter://엔터 입력시 전체 정보 출력
                        break;
                    case ConsoleKey.Escape:
                        return Constant.ESCAPE;
                    default:
                        isKey = false;
                        break;
                }
            }
            if (name == Constant.ESCAPE || id == Constant.ESCAPE || phonenumber == Constant.ESCAPE)
                return Constant.ESCAPE;
            Refresh(name,id,phonenumber,type);//검색한 정보 토대로 회원 검색 해 출력
            if (type != 4)//단순 조회 아닐 시(매직넘버)
            {
                bool isExisted = Constant.IS_EXCEPTION;
                while (!isExisted)
                {
                    Console.SetCursorPosition(Constant.ADD_INDEX, Constant.CODE_INDEX);
                    userInput = GetData(Constant.MEMBER_PERSONALCODE_LENGTH, Constant.EMPTY);//매직넘버
                    if (userInput == Constant.EMPTY || userInput == Constant.ESCAPE)//ESC나 엔터 입력 시에는 빠져나오기
                        return userInput;
                    isExisted = true;
                    if (!memberList.Exists(member => member.MemberCode == userInput))//검색 정보와 일치하는 맴버 입력 때까지 계속 입력
                    {
                        isExisted = false;
                        exceptionView.NotExisted(userInput.Length);//검색정보 중에 해당 회원코드가 없으면 예외출력
                    }
                }
            }

            return userInput;
        }
        private void AdminReviseMember(string code)//개인정보 수정
        {
            if (code == Constant.EMPTY)
                return;
            MemberVO member = voList.memberList.Find(member => member.MemberCode == code);//회원코드와 일치하는 멤버 찾기
            if (member != null)
            {
                this.LoginMember = member;
                AddOrReviseMember(2);//멤버 정보 수정
                Refresh(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY, Constant.MEMBER_REVISE);
            }
            else
                exceptionView.NotExistedMember(code.Length);//없으면 예외처리
        }
        private void DeleteMember(string code)//회원 삭제
        {
            if (code == Constant.EMPTY)
                return;
            MemberVO member = voList.memberList.Find(member => member.MemberCode == code);//회원정보 일치하는 멤버 찾기
            Refresh("qwerqwerqwer", "qwerqwerqwer", "qwerqwerqwer",Constant.MEMBER_DELETE);//기존 회원정보 출력 없애기
            if (member != null)
            {
                if (exception.IsDelete(member.Name+" 회원"))//삭제 한번 더 확인
                {
                    foreach (MyBook myBook in member.borrowedBook)//회원이 빌린 책 목록 삭제
                    {
                        myBook.book.Borrowed--;
                    }
                    voList.memberList.Remove(member);//회원 삭제
                }
            }
            else
                exceptionView.NotExistedMember(code.Length);//일치하는 회원 없으면 예외처리
        }
        private string GetUserData(int cursor,int type)//검색할 유저 정보 입력 받기
        {
            Refresh(Constant.EMPTY, Constant.EMPTY, Constant.EMPTY,type);
            Console.SetCursorPosition(Constant.ADD_INDEX, Constant.SEARCH_INDEX + cursor);
            string input = GetData(10, Constant.EMPTY);
            return input;
        }
        private void Refresh(string name, string id, string phonenumber,int type)//재조회
        {
            Console.Clear();
            ui.AdminLabel();
            switch (type)//수정,삭제,단순 조회에 따라 가이드UI다르게 출력
            {
                case Constant.MEMBER_REVISE:
                    ui.MemberReviseGuide();
                    break;
                case Constant.MEMBER_DELETE:
                    ui.MemberDeleteGuide();
                    break;
                case 4://매직넘버
                    ui.MemberSearchGuide();
                    break;
            }
            ShowMemberList(name, id, phonenumber);//검색한 정보 바탕으로 리스트 출력
        }
        public string SetData(int index, string userInput)//데이터 입력을 받고 상황별로 다른 예외처리를 해 예외가 없을때까지 입력받는 메소드
        {
            bool isException = Constant.IS_EXCEPTION;
            while (!isException && !isBack)
            {
                isUp = false;
                Console.SetCursorPosition(Constant.ADD_INDEX, index);
                //exceptionView.ClearLine(index);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX://도서코드 입력
                        userInput = GetData(Constant.BOOK_ID_LENGTH, Constant.EMPTY);
                        if (!isUp)
                            isException = exception.IsBookIdException(userInput, Constant.BOOK_ID_LENGTH, voList.bookList);
                        break;
                    case Constant.PASSWORD_ADD_INDEX:
                        userInput = GetData(20, Constant.EMPTY);//도서명 입력
                        isException = true;
                        if (userInput == Constant.EMPTY)
                        {
                            exceptionView.EmptyString();
                            isException=false;
                        }
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX:
                        userInput = GetData(Constant.BOOK_STRING_LENGTH, userInput);//출판사 입력
                        isException = true;
                        if (userInput == Constant.EMPTY)
                        {
                            exceptionView.EmptyString();
                            isException = false;
                        }
                        break;
                    case Constant.NAME_ADD_INDEX:
                        userInput = GetData(Constant.BOOK_STRING_LENGTH, userInput);//저자명 입력
                        isException = true;
                        if (userInput == Constant.EMPTY)
                        {
                            exceptionView.EmptyString();
                            isException = false;
                        }
                        break;
                    case Constant.PERSONAL_ADD_INDEX:
                        userInput = GetData(Constant.BOOK_PRICE_LENGTH, userInput);//가격 입력
                        if (!isUp)
                            isException = exception.IsNumber(userInput);
                        if (userInput == "0")
                        {
                            isException = Constant.IS_EXCEPTION;
                            exceptionView.QuantityException(userInput.Length);
                        }
                        break;
                    case Constant.PHONE_ADD_INDEX:
                        userInput = GetData(Constant.BOOK_QUANTITY_LENGTH, userInput);//수량 입력
                        if (!isUp)
                            isException = exception.IsNumber(userInput);
                        if (userInput == "0")
                        {
                            isException = Constant.IS_EXCEPTION;
                            exceptionView.QuantityException(userInput.Length);
                        }
                        break;
                }
                if (isUp)//위 방향 키 입력 감지
                    return userInput;
            }
            inputType++;//입력할 정보 타입 인덱스 조정
            if (!isBack)
                ui.Passed(userInput.Length);//완료 출력
            return userInput;
        }
    }
} 