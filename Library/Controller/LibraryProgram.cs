using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;

namespace Library.Controller
{
    class ExceptionAndView
    {
        public ExceptionView exceptionView;
        public Exception exception;
        public UI ui;
    }
    class LibraryProgram
    {
        ExceptionAndView exceptionAndView = new ExceptionAndView();
        VOList listData = new VOList();
        MenuSelection menuSelection = new MenuSelection();
        Exception exception = new Exception();
        ExceptionView exceptionView = new ExceptionView();
        UI ui = new UI();
        UserFunction userFunction;
        AdminFuncion adminFuncion;
        public LibraryProgram()
        {
            exceptionAndView.exceptionView = this.exceptionView;
            exceptionAndView.exception = this.exception;
            exceptionAndView.ui = this.ui;
            userFunction = new UserFunction(listData,exceptionAndView);
            adminFuncion=new AdminFuncion(listData,exceptionAndView);
        }
        public void start()//프로그램 시작
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit) {
                selectedMenu = menuSelection.SelectMenu();//선택한 메뉴값을 전달해주는 메소드
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        userFunction.Login();//로그인
                        break;
                    case Constant.SECOND_MENU:
                        userFunction.AddOrReviseMember(1);//회원가입
                        break;
                    case Constant.THIRD_MENU:
                        adminFuncion.AdminLogin();//관리자 로그인
                        break;
                    case Constant.FOURTH_MENU:
                        exception.ExitProgramm();//프로그램 종료
                        break;
                }
            }
        }
    }
}
