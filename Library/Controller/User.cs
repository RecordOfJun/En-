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
        public UI ui;
        public BookService bookFunction;
        public MenuSelection menuSelection = new MenuSelection();
        public MemberVO LoginMember;
        private string id;
        private string password;
        private string temporalPassword;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        public bool isBack;
        public bool isUp;
        public int inputType;
        public User()
        {

        }
        public User(VOList voList,ExceptionAndView exceptionAndView)
        {
            exception = exceptionAndView.exception;
            ui = exceptionAndView.ui;
            exceptionView = exceptionAndView.exceptionView;
            this.voList = voList;
            bookFunction = new BookService(voList, this,exceptionAndView);
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
            this.id = LoginMember.Id;
            this.password = LoginMember.Password;
            this.temporalPassword = password;
            this.name = LoginMember.Name;
            this.phoneNumber = LoginMember.PhoneNumber;
            this.personalCode = LoginMember.PersonalCode;
            this.address = LoginMember.Address;
        }
        private bool ChekId()//아이디와 비밀번호가 일치하는 계정이 있는지 확인
        {
            bool isException = false;
            while (!isException && !isBack) {//아이디 예외 없을 때 까지 입력받기
                //exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ID_LOGIN_INDEX);
                id = GetData(Constant.ID_LENGTH, Constant.EMPTY);
                isException = exception.IsExceptionIdPassword(id);
            }
            isException = false;
            while (!isException && !isBack)//비밀번호 예외 없을 때 까지 입력받기
            {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                password = GetData(Constant.PASSWORD_LENGTH, Constant.EMPTY);
                isException = exception.IsExceptionIdPassword(password);
            }
            if (isBack)//ESC입력시 뒤로
                return Constant.IS_EXCEPTION;
            if (voList.memberList.Exists(element => element.Id == id) && voList.memberList.Find(element => element.Id == id).Password == password)
            {
                LoginMember = voList.memberList.Find(element => element.Id == id);
                return !Constant.IS_EXCEPTION;
            }

            exceptionView.CanNotLogin(password.Length);
            return Constant.IS_EXCEPTION;
        }
        private void InitString()//멤버 추가 시 멤버 정보 초기화
        {
            id = "";
            password = "";
            temporalPassword = "";
            name = "";
            personalCode = "";
            phoneNumber = "";
            address = "";
        }
        //회원가입 기능
        public void AddOrReviseMember(int type)//회원가입 or 회원정보 수정 메소드
        {
            isBack = false;
            bool isComplete = false;
            int minimumIndex = 0 ;
            inputType = 0;
            Console.Clear();
            ui.LibraryLabel();
            if (type == 1)
            {//회원가입 일 때
                InitString();
                ui.AddMemberForm();
                minimumIndex = 0;
            }
            if (type == 2)
            {//수정일 때
                LinkData();
                minimumIndex = 1;
                ui.ReviseForm();
                //로그인 한 유저 정보 불러오기 OR 관리자가 선택한 유저 정보 불러오기
                WriteData(Constant.ID_ADD_INDEX, id);
                WriteData(Constant.PASSWORD_ADD_INDEX, new string('*', password.Length));
                WriteData(Constant.NAME_ADD_INDEX, name);
                WriteData(Constant.PERSONAL_ADD_INDEX, personalCode);
                WriteData(Constant.PHONE_ADD_INDEX, phoneNumber);
                WriteData(Constant.ADDRESS_ADD_INDEX, address);
                temporalPassword = password;
            }
            while (!isComplete)//작업 끝날 때, 즉 주소 입력 끝날 때 까지 입력 받기
            {
                if (inputType < minimumIndex)//회원가입 시는 ID부터 입력,수정 시는 비밀번호부터 입력
                    inputType = minimumIndex;
                switch (inputType)
                {
                    case 0://아이디 입력
                        id = SetData(Constant.ID_ADD_INDEX, id);
                        break;
                    case 1://비밀번호 입력
                        password = SetData(Constant.PASSWORD_ADD_INDEX, password);
                        break;
                    case 2://비밀번호 확인
                        temporalPassword=SetData(Constant.PASSWORD_CONFIRM_INDEX, temporalPassword);
                        break;
                    case 3://이름 입력
                        name = SetData(Constant.NAME_ADD_INDEX, name);
                        break;
                    case 4://주민번호 입력
                        if (type == 1)//회원가입 시만 입력 가능하게
                            personalCode = SetData(Constant.PERSONAL_ADD_INDEX, personalCode);
                        else if (isUp)
                            inputType--;
                        else
                            inputType++;
                        break;
                    case 5://전화번호 입력
                        phoneNumber = SetData(Constant.PHONE_ADD_INDEX, phoneNumber);
                        break;
                    case 6://주소 입력
                        address = SetData(Constant.ADDRESS_ADD_INDEX, address);
                        break;
                    case 7://입력 완료 체크
                        isComplete = true;
                        break;
                }
                if (isBack)
                    return;
            }
            password = temporalPassword;
            if (isBack)
                return;
            if(type==1&&IsConfirm(Constant.CONFRIM_ADD))//회원가입 시 완료할 것인지 물어보고 작업 수행
                CreateTable();
            if (type==2&&IsConfirm(Constant.CONFIRM_REVISE))//수정완료 할 것인지 물어보고 작업 수행
                ReviseData();
        }
        public void ReviseData()//수정된 데이터 리스트에 업데이트
        {
            LoginMember.Id = this.id;
            LoginMember.Password = this.password;
            LoginMember.Name = this.name;
            LoginMember.PhoneNumber = this.phoneNumber;
            LoginMember.PersonalCode = this.personalCode;
            LoginMember.Address = this.address;
        }
        public void WriteData(int index, string data){//화면에 계정정보 출력
            Console.SetCursorPosition(Constant.ADD_INDEX, index);
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
            bool isException = Constant.IS_EXCEPTION;
            while (!isException&&!isBack)
            {
                isUp = false;
                Console.SetCursorPosition(Constant.ADD_INDEX, index);
                //exceptionView.ClearLine(index);
                switch (index)
                {
                    case Constant.ID_ADD_INDEX://아이디
                        userInput = GetData(Constant.ID_LENGTH,userInput);
                        if(!isUp)
                            isException = exception.IsIdException(userInput, voList.memberList);
                        break;
                    case Constant.PASSWORD_ADD_INDEX://패스워드
                        userInput = GetData(Constant.PASSWORD_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsExceptionIdPassword(userInput);
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX://패스워드 확인
                        userInput = GetData(Constant.PASSWORD_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsIdentical(userInput,password);
                        break;
                    case Constant.NAME_ADD_INDEX://이름
                        userInput = GetData(Constant.NAME_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsNameException(userInput);
                        break;
                    case Constant.PERSONAL_ADD_INDEX://주민번호
                        userInput = GetData(Constant.PERSONAL_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH, voList.memberList);
                        break;
                    case Constant.PHONE_ADD_INDEX://전화번호
                        userInput = GetData(Constant.PHONE_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH, voList.memberList);
                        break;
                    case Constant.ADDRESS_ADD_INDEX://주소
                        if (!isUp)
                            userInput = GetData(Console.WindowWidth-1, userInput);
                        isException =exception.IsAdress(userInput);
                        break;
                }
                if (isUp)//위쪽 방향키 입력 시 알리기
                    return userInput;
            }
            inputType++;
            if (!isBack)
                ui.Passed(userInput.Length);//예외 없이 입력 되었을 때 완료되었다고 알려줌
            return userInput;
        }
        public string GetData(int maximumLength,string inputString)//원하는 길이 이하로 입력을 받아주는 메소드 & 화면에 SPREAD
        {
            ConsoleKeyInfo key;
            string userinput;
            bool isEnter = false;
            //if(inputString!="")
            //    RefreshString(inputString, maximumLength);
            Console.SetCursorPosition(inputString.Length + Constant.ADD_INDEX, Console.CursorTop);
            while (!isEnter)//엔터가 입력되기 전 까지 입력
            {
                
                key = Console.ReadKey();
                RefreshString(inputString, maximumLength);
                bool isArrow = ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.DownArrow));
                userinput = key.KeyChar.ToString();
                if (key.Key == ConsoleKey.Escape)//ESC눌렀을 시 알림
                {
                    isBack = true;
                    return Constant.ESCAPE;
                }
                if (key.Key == ConsoleKey.Enter)//엔터 입력 시 입력한 문자열 리턴
                {
                    RefreshString(inputString, maximumLength);
                    break;
                }
                if (key.Key == ConsoleKey.UpArrow)//위쪽 방향키 눌렀을 시 알림
                {
                    isUp = true;
                    inputType--;
                    break;
                }
                if (userinput == "\b")//백스페이스 입력 시 출력 스트링 조정
                {
                    if (inputString.Length > 0)
                    {
                        inputString = inputString.Substring(0, inputString.Length-1);
                    }
                }
                else if (inputString.Length < maximumLength&&!isArrow)//원하는 길이를 초과해서 입력하려고 할 때 방지
                {
                    
                    inputString += userinput;
                }
                RefreshString(inputString, maximumLength);//입력한 문자열 출력
            }
            return inputString;
        }
        private void RefreshString(string inputString,int maximumLength)//예외필터를 거쳐 입력된 문자열을 출력해주는 함수
        {
            if (maximumLength == Constant.PASSWORD_LENGTH)
                ui.WritePassword(inputString);
            else
                ui.SetInputCursor(inputString);
        }
        private void CreateTable()//새 계정 생성
        {
            MemberVO member = new MemberVO();//맴버 객체 생성
            //새 객체에 입력한 정보들 넣어주기
            member.Id = id;
            member.Password = password;
            member.Name = name;
            member.PersonalCode = personalCode;
            member.PhoneNumber = phoneNumber;
            member.Address = address;
            member.MemberCode = (int.Parse(voList.memberList[voList.memberList.Count - 1].MemberCode) + 1).ToString();
            voList.memberList.Add(member);//리스트에 새로운 멤버 추가 
        }

        //로그인 후 메뉴 선택기능
        public void UserSelectMenu()
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit)
            {
                selectedMenu = menuSelection.SelectUserMenu();//선택한 메뉴를 전달받음
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
                    case Constant.QUIT:
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
