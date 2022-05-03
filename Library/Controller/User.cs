using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
using Library.Utility;
namespace Library.Controller
{
    class User//사용자 기능 클래스
    {
        public ExceptionView exceptionView;
        public Exception exception;
        public Basic basicUI;
        public Book bookUI;
        public Member memberUI;
        public BookService bookFunction;
        public MenuSelection menuSelection = new MenuSelection();
        public MemberVO LoginMember;
        public MemberVO storage;
        public bool isBack;
        public int inputType;
        public User() { }
        public User(ExceptionAndView exceptionAndView)
        {
            this.exception = exceptionAndView.exception;
            this.basicUI = exceptionAndView.basicUI;
            this.bookUI = exceptionAndView.bookUI;
            this.memberUI = exceptionAndView.memberUI;
            this.exceptionView = exceptionAndView.exceptionView;
            storage = new MemberVO();
            bookFunction = new BookService( this,exceptionAndView); 
        }
        //로그인 기능
        public void Login()//로그인 메소드
        {
            isBack = false;
            bool isCorrect = false;
            //UI 출력
            Console.Clear();
            basicUI.LibraryLabel();
            basicUI.LoginForm();
            while (!isCorrect)//일치하는 아이디 비밀번호 있을때까지 입력받기
            {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                isCorrect = IsExistedId();//아이디 체크
                if (isBack)
                    return;
            }
            if (IsConfirm(Constant.CONFRIM_LOGIN))//로그인 할 것인지 한번 더 확인
            {
                LinkData();
                Log.GetLog().LogAdd(storage.Id + "로그인");
                UserSelectMenu();
                Log.GetLog().LogAdd(storage.Id + "로그아웃");
            }
        }
        private void LinkData()//로그인 성공 시 해당 계정 정보 불러오기
        {
            storage.Init();
            storage.Id = LoginMember.Id;
            storage.Password = LoginMember.Password;
            storage.TemporalPassword = LoginMember.Password;
            storage.Name = LoginMember.Name;
            storage.PhoneNumber = LoginMember.PhoneNumber;
            storage.PersonalCode = LoginMember.PersonalCode;
            storage.Address = LoginMember.Address;
            storage.MemberCode = LoginMember.MemberCode;
        }
     
        private bool IsExistedId()//아이디와 비밀번호가 일치하는 계정이 있는지 확인
        {
            bool isException = false;
            while (!isException && !isBack) {//아이디 예외 없을 때 까지 입력받기
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ID_LOGIN_INDEX);
                storage.Id = KeyProcessing.GetInput().GetUserString(Constant.ID_LENGTH, Constant.NOT_PASSWORD_TYPE);//입력
                if (storage.Id == Constant.ESCAPE_STRING)//ESC감지
                {
                    isBack = true;
                    return false;
                }
                isException = exception.IsExceptionIdPassword(storage.Id,Constant.INSERT_TYPE);//예외처리
            }
            isException = false;
            while (!isException && !isBack)//비밀번호 예외 없을 때 까지 입력받기
            {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                storage.Password = KeyProcessing.GetInput().GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);//입력
                if (storage.Password == Constant.ESCAPE_STRING)//ESC감지
                {
                    isBack = true;
                    return false;
                }
                isException = exception.IsExceptionIdPassword(storage.Password,Constant.INSERT_TYPE);//예외처리
            }
            MemberVO member = DBConnection.GetDBConnection().FindUser(storage.Id, storage.Password);//로그인 정보로 유저 찾기
            if (member!=null)
            {
                LoginMember = member;//유저가 존재할 때 유저 정보 넘겨줌
                return !Constant.IS_EXCEPTION;
            }

            exceptionView.CanNotLogin(storage.Password.Length);//유저 존재하지 않을 경우 예외처리
            return Constant.IS_EXCEPTION;
        }
        //회원가입 기능
        protected void ReviseMember()//회원가입 or 회원정보 수정 메소드
        {
            int selectedSector=0;
            bool isNotComplete = true;
            inputType = 0;
            Console.Clear();
            basicUI.LibraryLabel();
            LinkData();
            memberUI.ReviseForm();
            //로그인 한 유저 정보 불러오기 OR 관리자가 선택한 유저 정보 불러오기
            WriteData(Constant.ID_ADD_INDEX, storage.Id);
            WriteData(Constant.PASSWORD_ADD_INDEX, new string('*', storage.Password.Length));
            WriteData(Constant.NAME_ADD_INDEX, storage.Name);
            WriteData(Constant.PERSONAL_ADD_INDEX, storage.PersonalCode);
            WriteData(Constant.PHONE_ADD_INDEX, storage.PhoneNumber);
            WriteData(Constant.ADDRESS_ADD_INDEX, storage.Address);
            storage.TemporalPassword = storage.Password;
            if (!IsInsertData(Constant.REVISE_MEMBER))
                return;
            if (IsConfirm(Constant.CONFIRM_REVISE))//수정완료 할 것인지 물어보고 작업 수행
                ReviseData();
        }
        public void AddMember()
        {
            inputType = 0;
            Console.Clear();
            basicUI.LibraryLabel();
            storage.Init();//가입정보 저장공간 초기화
            memberUI.AddMemberForm();
            if (!IsInsertData(Constant.SIGN_UP))
                return;
            if (IsConfirm(Constant.CONFRIM_ADD))//회원가입 시 완료할 것인지 물어보고 작업 수행
                CreateTable();
        }
        private bool IsInsertData(int type)
        {
            int selectedSector = 0;
            bool isNotComplete = true;
            while (isNotComplete)
            {
                selectedSector = KeyProcessing.GetInput().SwicthSector(8, selectedSector);
                switch (selectedSector)
                {
                    case (int)Constant.Menu.FIRST_MENU://아이디 입력
                        if (type == Constant.SIGN_UP)
                            storage.Id = SetData(Constant.ID_ADD_INDEX, storage.Id);
                        break;
                    case (int)Constant.Menu.SECOND_MENU://비밀번호 입력
                        storage.Password = SetData(Constant.PASSWORD_ADD_INDEX, storage.Password);
                        storage.TemporalPassword = Constant.EMPTY;
                        break;
                    case (int)Constant.Menu.THIRD_MENU://비밀번호 확인
                        storage.TemporalPassword = SetData(Constant.PASSWORD_CONFIRM_INDEX, storage.TemporalPassword);
                        break;
                    case (int)Constant.Menu.FOURTH_MENU://이름 입력
                        storage.Name = SetData(Constant.NAME_ADD_INDEX, storage.Name);
                        break;
                    case (int)Constant.Menu.FIFTH_MENU://주민번호 입력
                        if (type == Constant.SIGN_UP)//회원가입 시만 입력 가능하게
                            storage.PersonalCode = SetData(Constant.PERSONAL_ADD_INDEX, storage.PersonalCode);
                        break;
                    case (int)Constant.Menu.SIXTH_MENU://전화번호 입력
                        storage.PhoneNumber = SetData(Constant.PHONE_ADD_INDEX, storage.PhoneNumber);
                        break;
                    case (int)Constant.Menu.SEVENTH_MENU://주소 입력
                        storage.Address = SetData(Constant.ADDRESS_ADD_INDEX, storage.Address);
                        break;
                    case (int)Constant.Menu.EIGHTH_MENU://입력 완료 체크
                        if (storage.IsNotNull())//회원가입 OR 정보수정 시 빠뜨린 것 없는지 확인
                            isNotComplete = false;
                        else
                            exceptionView.InsertException(20, "  (정보를 다 입력해주세요!)");
                        break;
                    case Constant.ESCAPE_INT:
                        return Constant.IS_EXCEPTION;
                }
            }
            return !Constant.IS_EXCEPTION;
        }
        private void ReviseData()//수정된 데이터 리스트에 업데이트
        {
            LoginMember.Id = storage.Id;
            LoginMember.Password = storage.Password;
            LoginMember.Name = storage.Name;
            LoginMember.PhoneNumber = storage.PhoneNumber;
            LoginMember.PersonalCode = storage.PersonalCode;
            LoginMember.Address = storage.Address;
            DBConnection.GetDBConnection().UpdateMember(LoginMember, LoginMember.MemberCode);
            Log.GetLog().LogAdd(storage.Id + " 회원정보 수정");
        }

        private void WriteData(int index, string data){//화면에 계정정보 출력
            Console.SetCursorPosition(Constant.ADD_INDEX+2, index);
            Console.Write(data);
        }

        private bool IsConfirm(int type)//기능 수행 후 재확인 
        {   if (type == Constant.CONFRIM_ADD)//회원가입인지 확인
                basicUI.ConfirmAddForm();
            else
                basicUI.ReviseDone();//수정인지 확인
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                return false;
            return true;
        }
        private string SetData(int index,string userInput)//데이터 입력을 받고 상황별로 다른 예외처리를 해 예외가 없을때까지 입력받는 메소드
        {
            Console.CursorVisible = true;
            bool isException = Constant.IS_EXCEPTION;
            while (!isException&&!isBack)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX+2, index);
                basicUI.DeleteString(Console.CursorLeft, Console.CursorTop);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX://아이디
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.ID_LENGTH,Constant.NOT_PASSWORD_TYPE);
                        if(userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsIdException(userInput);
                        break;
                    case Constant.PASSWORD_ADD_INDEX://패스워드
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);
                        if ( userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsExceptionIdPassword(userInput,Constant.INSERT_TYPE);
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX://패스워드 확인
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsIdentical(userInput, storage.Password);
                        break;
                    case Constant.NAME_ADD_INDEX://이름
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.NAME_LENGTH, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsNameException(userInput, Constant.INSERT_TYPE);
                        break;
                    case Constant.PERSONAL_ADD_INDEX://주민번호
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.PERSONAL_LENGTH, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH);
                        break;
                    case Constant.PHONE_ADD_INDEX://전화번호
                        userInput = KeyProcessing.GetInput().GetUserString(Constant.PHONE_LENGTH, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH);
                        break;
                    case Constant.ADDRESS_ADD_INDEX://주소
                        userInput = KeyProcessing.GetInput().GetUserString(Console.WindowWidth - 30, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)     
                            isException =exception.IsAdress(userInput);
                        break;
                }
                if (userInput == Constant.ESCAPE_STRING)//ESC감지
                {
                    userInput = Constant.EMPTY;
                    basicUI.DeleteString(Constant.ADD_INDEX + 2, Console.CursorTop);
                    return userInput;
                }
            }
            exceptionView.InsertComplete(userInput.Length * 2, "  (완료되었습니다!))");
            return userInput;
        }
        private void CreateTable()//새 계정 생성
        {
            MemberVO member = new MemberVO();//맴버 객체 생성
            //새 객체에 입력한 정보들 넣어주기
            member.Id = storage.Id;
            member.Password = storage.Password;
            member.Name = storage.Name;
            member.PersonalCode = storage.PersonalCode;
            member.PhoneNumber = storage.PhoneNumber;
            member.Address = storage.Address;
            DBConnection.GetDBConnection().InsertMember(member);
            Log.GetLog().LogAdd(member.Id + " 회원가입");
        }

        //로그인 후 메뉴 선택기능
        private void UserSelectMenu()
        {
            int selectedMenu=0;
            bool isExit = false;
            while (!isExit)
            {
                if (selectedMenu == Constant.ESCAPE_INT)
                    selectedMenu = 0;
                selectedMenu = menuSelection.SelectUserMenu(selectedMenu);//선택한 메뉴를 전달받음
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        bookFunction.SearchAndChoice(Constant.SEARCH_BOOK);//도서 단순 조회
                        break;
                    case Constant.SECOND_MENU:
                        bookFunction.SearchAndChoice(Constant.BOOK_BORROW);//도서 대여
                        break;
                    case Constant.THIRD_MENU:
                        bookFunction.ReturnBook();//도서 반납
                        break;
                    case Constant.FOURTH_MENU:
                        ReviseMember();//개인정보 수정
                        break;
                    case Constant.ESCAPE_INT:
                        isExit = exception.IsEscape();//ESC입력 감지
                        break;
                    case Constant.FIFTH_MENU:
                        exception.ExitProgramm();//프로그램 종료
                        break;
                }
            }
        }
    }
}
