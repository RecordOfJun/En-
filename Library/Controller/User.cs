using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;

namespace Library.Controller
{
    class User//사용자 기능 클래스
    {
        public ExceptionView exceptionView;
        public Exception exception;
        public VOList voList;
        public BasicView ui;
        public BookService bookFunction;
        public MenuSelection menuSelection = new MenuSelection();
        public MemberVO LoginMember;
        public Input input;
        public MemberVO storage;
        public bool isBack;
        public bool isUp;
        public int inputType;
        public User() { }
        public User(VOList voList,ExceptionAndView exceptionAndView)
        {
            storage = new MemberVO();
            exception = exceptionAndView.exception;
            ui = exceptionAndView.ui;
            exceptionView = exceptionAndView.exceptionView;
            this.voList = voList;
            bookFunction = new BookService(voList, this,exceptionAndView); 
            input = new Input(ui);
        }
        //로그인 기능
        public void Login()//로그인 메소드
        {
            isBack = false;
            bool isCorrect = false;
            //UI 출력
            Console.Clear();
            ui.LibraryLabel();
            ui.LoginForm();
            while (!isCorrect)//일치하는 아이디 비밀번호 있을때까지 입력받기
            {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                isCorrect = ChekId();//아이디 체크
                if (isBack)
                    return;
            }
            if (IsConfirm(Constant.CONFRIM_LOGIN))//로그인 할 것인지 한번 더 확인
            {
                LinkData();
                UserSelectMenu();
            }
        }
        public void LinkData()//로그인 성공 시 해당 계정 정보 불러오기
        {
            storage.Init();
            storage.Id = LoginMember.Id;
            storage.Password = LoginMember.Password;
            storage.TemporalPassword = LoginMember.Password;
            storage.Name = LoginMember.Name;
            storage.PhoneNumber = LoginMember.PhoneNumber;
            storage.PersonalCode = LoginMember.PersonalCode;
            storage.Address = LoginMember.Address;
        }
        private bool ChekId()//아이디와 비밀번호가 일치하는 계정이 있는지 확인
        {
            bool isException = false;
            while (!isException && !isBack) {//아이디 예외 없을 때 까지 입력받기
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ID_LOGIN_INDEX);
                storage.Id = input.GetUserString(Constant.ID_LENGTH, Constant.NOT_PASSWORD_TYPE);
                if (storage.Id == Constant.ESCAPE_STRING)
                {
                    isBack = true;
                    return false;
                }
                isException = exception.IsExceptionIdPassword(storage.Id);
            }
            isException = false;
            while (!isException && !isBack)//비밀번호 예외 없을 때 까지 입력받기
            {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                storage.Password = input.GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);
                if (storage.Password == Constant.ESCAPE_STRING)
                {
                    isBack = true;
                    return false;
                }
                isException = exception.IsExceptionIdPassword(storage.Password);
            }
            if (voList.memberList.Exists(element => element.Id == storage.Id) && voList.memberList.Find(element => element.Id == storage.Id).Password == storage.Password)
            {
                LoginMember = voList.memberList.Find(element => element.Id == storage.Id);
                return !Constant.IS_EXCEPTION;
            }

            exceptionView.CanNotLogin(storage.Password.Length);
            return Constant.IS_EXCEPTION;
        }
        //회원가입 기능
        public void AddOrReviseMember(int type)//회원가입 or 회원정보 수정 메소드
        {
            isBack = false;
            int selectedSector=0;
            bool isNotComplete = true;
            inputType = 0;
            Console.Clear();
            ui.LibraryLabel();
            if (type == 1)
            {//회원가입 일 때
                storage.Init();
                ui.AddMemberForm();
            }
            if (type == 2)
            {//수정일 때
                LinkData();
                ui.ReviseForm();
                //로그인 한 유저 정보 불러오기 OR 관리자가 선택한 유저 정보 불러오기
                WriteData(Constant.ID_ADD_INDEX, storage.Id);
                WriteData(Constant.PASSWORD_ADD_INDEX, new string('*', storage.Password.Length));
                WriteData(Constant.NAME_ADD_INDEX, storage.Name);
                WriteData(Constant.PERSONAL_ADD_INDEX, storage.PersonalCode);
                WriteData(Constant.PHONE_ADD_INDEX, storage.PhoneNumber);
                WriteData(Constant.ADDRESS_ADD_INDEX, storage.Address);
                storage.TemporalPassword = storage.Password;
            }
            while (isNotComplete)
            {
                selectedSector = input.SwicthSector(8,selectedSector);
                switch (selectedSector)
                {
                    case (int)Constant.Menu.FIRST_MENU://아이디 입력
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
                        if (type == 1)//회원가입 시만 입력 가능하게
                            storage.PersonalCode = SetData(Constant.PERSONAL_ADD_INDEX, storage.PersonalCode);
                        break;
                    case (int)Constant.Menu.SIXTH_MENU://전화번호 입력
                        storage.PhoneNumber = SetData(Constant.PHONE_ADD_INDEX, storage.PhoneNumber);
                        break;
                    case (int)Constant.Menu.SEVENTH_MENU://주소 입력
                        storage.Address = SetData(Constant.ADDRESS_ADD_INDEX, storage.Address);
                        break;
                    case (int)Constant.Menu.EIGHTH_MENU://입력 완료 체크
                        if (storage.IsNotNull())
                            isNotComplete = false;
                        else
                            exceptionView.SignUpException();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
            if (type == 1 && IsConfirm(Constant.CONFRIM_ADD))//회원가입 시 완료할 것인지 물어보고 작업 수행
                CreateTable();
            if (type == 2 && IsConfirm(Constant.CONFIRM_REVISE))//수정완료 할 것인지 물어보고 작업 수행
                ReviseData();
        }
        public void ReviseData()//수정된 데이터 리스트에 업데이트
        {
            LoginMember.Id = storage.Id;
            LoginMember.Password = storage.Password;
            LoginMember.Name = storage.Name;
            LoginMember.PhoneNumber = storage.PhoneNumber;
            LoginMember.PersonalCode = storage.PersonalCode;
            LoginMember.Address = storage.Address;
        }
        public void WriteData(int index, string data){//화면에 계정정보 출력
            Console.SetCursorPosition(Constant.ADD_INDEX+2, index);
            Console.Write(data);
        }
        public bool IsConfirm(int type)//기능 수행 후 재확인 
        {   if (type == Constant.CONFRIM_ADD)//회원가입인지 확인
                ui.ConfirmAddForm();
            else
                ui.ReviseDone();//수정인지 확인
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                return false;
            return true;
        }
        public string SetData(int index,string userInput)//데이터 입력을 받고 상황별로 다른 예외처리를 해 예외가 없을때까지 입력받는 메소드
        {
            Console.CursorVisible = true;
            bool isException = Constant.IS_EXCEPTION;
            while (!isException&&!isBack)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX+2, index);
                ui.DeleteString(Console.CursorLeft, Console.CursorTop, 70);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX://아이디
                        userInput = input.GetUserString(Constant.ID_LENGTH,Constant.NOT_PASSWORD_TYPE);
                        if(userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsIdException(userInput, voList.memberList);
                        break;
                    case Constant.PASSWORD_ADD_INDEX://패스워드
                        userInput = input.GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);
                        if ( userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsExceptionIdPassword(userInput);
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX://패스워드 확인
                        userInput = input.GetUserString(Constant.PASSWORD_LENGTH, Constant.PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsIdentical(userInput, storage.Password);
                        break;
                    case Constant.NAME_ADD_INDEX://이름
                        userInput = input.GetUserString(Constant.NAME_LENGTH, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsNameException(userInput);
                        break;
                    case Constant.PERSONAL_ADD_INDEX://주민번호
                        userInput = input.GetUserString(Constant.PERSONAL_LENGTH, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH, voList.memberList);
                        break;
                    case Constant.PHONE_ADD_INDEX://전화번호
                        userInput = input.GetUserString(Constant.PHONE_LENGTH, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH, voList.memberList);
                        break;
                    case Constant.ADDRESS_ADD_INDEX://주소
                        userInput = input.GetUserString(Console.WindowWidth - 1, Constant.NOT_PASSWORD_TYPE);
                        if (userInput != Constant.ESCAPE_STRING)     
                            isException =exception.IsAdress(userInput);
                        break;
                }
                if (userInput == Constant.ESCAPE_STRING)
                {
                    userInput = Constant.EMPTY;
                    ui.DeleteString(Constant.ADD_INDEX + 2, Console.CursorTop, 70);
                    return userInput;
                }
            }
            if (!isBack)
                exceptionView.InsertSuccess(userInput.Length);//예외 없이 입력 되었을 때 완료되었다고 알려줌
            return userInput;
        }
        private void RefreshString(string inputString, int inputType)//예외필터를 거쳐 입력된 문자열을 출력해주는 함수
        {
            if (inputType == Constant.HIDE_INPUT)
                ui.WritePassword(inputString);
            else
                ui.SetInputCursor(inputString);
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
            member.MemberCode = (int.Parse(voList.memberList[voList.memberList.Count - 1].MemberCode) + 1).ToString();
            voList.memberList.Add(member);//리스트에 새로운 멤버 추가 
        }

        //로그인 후 메뉴 선택기능
        public void UserSelectMenu()
        {
            int selectedMenu=0;
            bool isExit = false;
            while (!isExit)
            {
                selectedMenu = menuSelection.SelectUserMenu(selectedMenu);//선택한 메뉴를 전달받음
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        bookFunction.SearchAndChoice(5);//도서 단순 조회
                        break;
                    case Constant.SECOND_MENU:
                        bookFunction.SearchAndChoice(Constant.BOOK_BORROW);//도서 대여
                        break;
                    case Constant.THIRD_MENU:
                        bookFunction.ReturnBook();//도서 반납
                        break;
                    case Constant.FOURTH_MENU:
                        AddOrReviseMember(2);//개인정보 수정
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
