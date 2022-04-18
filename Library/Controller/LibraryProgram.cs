using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
using System.Runtime.InteropServices;
namespace Library.Controller
{
    class ExceptionAndView
    {
        public ExceptionView exceptionView;
        public Exception exception;
        public BasicView ui;
    }
    class LibraryProgram
    {
        ExceptionAndView exceptionAndView = new ExceptionAndView();
        VOList listData = new VOList();
        MenuSelection menuSelection = new MenuSelection();
        Exception exception = new Exception();
        ExceptionView exceptionView = new ExceptionView();
        BasicView ui = new BasicView();
        User userFunction;
        Admin adminFuncion;

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        public LibraryProgram()
        {
            exceptionAndView.exceptionView = this.exceptionView;
            exceptionAndView.exception = this.exception;
            exceptionAndView.ui = this.ui;
            userFunction = new User(listData,exceptionAndView);
            adminFuncion=new Admin(listData,exceptionAndView);
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)//콘솔 창 크기 제어 방지
            {
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
            Console.SetWindowSize(81, 40);
        }
        public void start()//프로그램 시작
        {
            int selectedMenu=0;
            bool isExit = false;
            while (!isExit) {
                selectedMenu = menuSelection.SelectMenu(selectedMenu);//선택한 메뉴값을 전달해주는 메소드
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
