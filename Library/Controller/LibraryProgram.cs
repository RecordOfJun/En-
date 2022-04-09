using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

namespace Library.Controller
{
    class LibraryProgram
    {
        VOList listData = new VOList();
        MenuSelection menuSelection = new MenuSelection();
        Exception exception = new Exception();
        UserFunction userFunction;
        AdminFuncion adminFuncion;
        public LibraryProgram()
        {
            userFunction= new UserFunction(listData);
            adminFuncion=new AdminFuncion(listData);
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
                        userFunction.AddMember();//회원가입
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
