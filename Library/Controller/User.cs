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
        private string confirmPassword;
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
            Console.Clear();
            ui.LibraryLabel();
            ui.LoginForm();
            while (!isCorrect)
            {
                exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                exceptionView.ClearLine(Constant.PASSWORD_LOGIN_INDEX);
                isCorrect = ChekId();
                if (isBack)
                    return;
            }
            if (IsConfirm(Constant.CONFRIM_LOGIN))
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
            while (!isException && !isBack) {
                //exceptionView.ClearLine(Constant.ID_LOGIN_INDEX);
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.ID_LOGIN_INDEX);
                id = GetData(Constant.ID_LENGTH, Constant.EMPTY);
                isException = exception.IsExceptionIdPassword(id);
            }
            isException = false;
            while (!isException && !isBack)
            {
                Console.SetCursorPosition(Constant.ADD_INDEX, Constant.PASSWORD_LOGIN_INDEX);
                password = GetData(Constant.PASSWORD_LENGTH, Constant.EMPTY);
                isException = exception.IsExceptionIdPassword(password);
            }
            if (isBack)
                return Constant.IS_EXCEPTION;
            if (voList.memberList.Exists(element => element.Id == id) && voList.memberList.Find(element => element.Id == id).Password == password)
            {
                LoginMember = voList.memberList.Find(element => element.Id == id);
                return !Constant.IS_EXCEPTION;
            }

            exceptionView.CanNotLogin(password.Length);
            return Constant.IS_EXCEPTION;
        }
        private void InitString()
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
        public void AddOrReviseMember(int type)//회원가입
        {
            isBack = false;
            bool isComplete = false;
            int minimumIndex = 0 ;
            inputType = 0;
            Console.Clear();
            ui.LibraryLabel();
            if (type == 1)
            {//추가일 때
                InitString();
                ui.AddMemberForm();
                minimumIndex = 0;
            }
            if (type == 2)
            {
                LinkData();
                minimumIndex = 1;
                ui.ReviseForm();
                WriteData(Constant.ID_ADD_INDEX, id);
                WriteData(Constant.PASSWORD_ADD_INDEX, new string('*', password.Length));
                WriteData(Constant.NAME_ADD_INDEX, name);
                WriteData(Constant.PERSONAL_ADD_INDEX, personalCode);
                WriteData(Constant.PHONE_ADD_INDEX, phoneNumber);
                WriteData(Constant.ADDRESS_ADD_INDEX, address);
                temporalPassword = password;
            }
            while (!isComplete)
            {
                if (inputType < minimumIndex)
                    inputType = minimumIndex;
                switch (inputType)
                {
                    case 0:
                        id = SetData(Constant.ID_ADD_INDEX, id);
                        break;
                    case 1:
                        password = SetData(Constant.PASSWORD_ADD_INDEX, password);
                        break;
                    case 2:
                        temporalPassword=SetData(Constant.PASSWORD_CONFIRM_INDEX, temporalPassword);
                        break;
                    case 3:
                        name = SetData(Constant.NAME_ADD_INDEX, name);
                        break;
                    case 4:
                        if (type == 1)
                            personalCode = SetData(Constant.PERSONAL_ADD_INDEX, personalCode);
                        else if (isUp)
                            inputType--;
                        else
                            inputType++;
                        break;
                    case 5:
                        phoneNumber = SetData(Constant.PHONE_ADD_INDEX, phoneNumber);
                        break;
                    case 6:
                        address = SetData(Constant.ADDRESS_ADD_INDEX, address);
                        break;
                    case 7:
                        isComplete = true;
                        break;
                }
                if (isBack)
                    return;
            }
            password = temporalPassword;
            if (isBack)
                return;
            if(type==1&&IsConfirm(Constant.CONFRIM_ADD))
                CreateTable();
            if (type==2&&IsConfirm(Constant.CONFIRM_REVISE))
                ReviseData();
        }
        public void ReviseData()//수정된 데이터 업데이트
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
        {   if (type == Constant.CONFRIM_ADD)
                ui.ConfirmAddForm();
            else
                ui.ReviseDone();
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
                    case Constant.ID_ADD_INDEX:
                        userInput = GetData(Constant.ID_LENGTH,userInput);
                        if(!isUp)
                            isException = exception.IsIdException(userInput, voList.memberList);
                        break;
                    case Constant.PASSWORD_ADD_INDEX:
                        userInput = GetData(Constant.PASSWORD_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsExceptionIdPassword(userInput);
                        break;
                    case Constant.PASSWORD_CONFIRM_INDEX:
                        userInput = GetData(Constant.PASSWORD_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsIdentical(userInput,password);
                        break;
                    case Constant.NAME_ADD_INDEX:
                        userInput = GetData(Constant.NAME_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsNameException(userInput);
                        break;
                    case Constant.PERSONAL_ADD_INDEX:
                        userInput = GetData(Constant.PERSONAL_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PERSONAL_LENGTH, voList.memberList);
                        break;
                    case Constant.PHONE_ADD_INDEX:
                        userInput = GetData(Constant.PHONE_LENGTH, userInput);
                        if (!isUp)
                            isException = exception.IsPersnoalAndPhoneException(userInput, Constant.PHONE_LENGTH, voList.memberList);
                        break;
                    case Constant.ADDRESS_ADD_INDEX:
                        if (!isUp)
                            userInput = GetData(Console.WindowWidth-1, userInput);
                        isException =exception.IsAdress(userInput);
                        break;
                }
                if (isUp)
                    return userInput;
            }
            inputType++;
            if (!isBack)
                ui.Passed(userInput.Length);
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
            while (!isEnter)
            {
                
                key = Console.ReadKey();
                RefreshString(inputString, maximumLength);
                bool isArrow = ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.DownArrow));
                userinput = key.KeyChar.ToString();
                if (key.Key == ConsoleKey.Escape)
                {
                    isBack = true;
                    return Constant.ESCAPE;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    RefreshString(inputString, maximumLength);
                    break;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    isUp = true;
                    inputType--;
                    break;
                }
                if (userinput == "\b")
                {
                    if (inputString.Length > 0)
                    {
                        inputString = inputString.Substring(0, inputString.Length-1);
                    }
                }
                else if (inputString.Length < maximumLength&&!isArrow)
                {
                    
                    inputString += userinput;
                }
                RefreshString(inputString, maximumLength);
            }
            return inputString;
        }
        private void RefreshString(string inputString,int maximumLength)
        {
            if (maximumLength == Constant.PASSWORD_LENGTH)
                ui.WritePassword(inputString);
            else
                ui.SetInputCursor(inputString);
        }
        private void CreateTable()//새 계정 생성
        {
            MemberVO member = new MemberVO();
            member.Id = id;
            member.Password = password;
            member.Name = name;
            member.PersonalCode = personalCode;
            member.PhoneNumber = phoneNumber;
            member.Address = address;
            voList.memberList.Add(member);
        }

        //로그인 후 메뉴 선택기능
        public void UserSelectMenu()
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit)
            {
                selectedMenu = menuSelection.SelectUserMenu();
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        bookFunction.SearchAndChoice(5);
                        break;
                    case Constant.SECOND_MENU:
                        bookFunction.SearchAndChoice(Constant.BOOK_BORROW);
                        break;
                    case Constant.THIRD_MENU:
                        bookFunction.ReturnBook();
                        break;
                    case Constant.FOURTH_MENU:
                        AddOrReviseMember(2);
                        break;
                    case Constant.QUIT:
                        isExit = exception.IsEscape();
                        break;
                    case Constant.FIFTH_MENU:
                        exception.ExitProgramm();
                        break;
                }
            }
        }
    }
}
