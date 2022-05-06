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
        public Basic basicUI;
        public Book bookUI;
        public Member memberUI;
    }
    class MainMenu
    {
        ExceptionAndView exceptionAndView = new ExceptionAndView();
        MenuSelection menuSelection = new MenuSelection();
        Exception exception = new Exception();
        ExceptionView exceptionView = new ExceptionView();
        Basic basicUI=new Basic();
        Book bookUI=new Book();
        Member memberUI=new Member();
        User user;
        Admin admin;

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
        public MainMenu()
        {
            exceptionAndView.exceptionView = this.exceptionView;
            exceptionAndView.exception = this.exception;
            exceptionAndView.basicUI = this.basicUI;
            exceptionAndView.bookUI = this.bookUI;
            exceptionAndView.memberUI = this.memberUI;
            user = new User(exceptionAndView);
            admin=new Admin(exceptionAndView);
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)//콘솔 창 크기 제어 방지
            {
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
            Console.SetWindowSize(81, 40);
            Console.SetBufferSize(Console.WindowWidth+1, Console.BufferHeight);
        }
        public void start()//프로그램 시작
        {
            int selectedMenu=0;
            bool isExit = false;
            while (!isExit) {
                if (selectedMenu == Constant.ESCAPE_INT)
                    selectedMenu = 0;
                selectedMenu = menuSelection.SelectMenu(selectedMenu);//선택한 메뉴값을 전달해주는 메소드
                switch (selectedMenu)
                {
                    case Constant.FIRST_MENU:
                        user.Login();//로그인
                        break;
                    case Constant.SECOND_MENU:
                        user.AddMember();//회원가입
                        break;
                    case Constant.THIRD_MENU:
                        admin.AdminLogin();//관리자 로그인
                        break;
                    case Constant.FOURTH_MENU:
                        LogManage();
                        break;
                    case Constant.FIFTH_MENU:
                        exception.ExitProgramm();//프로그램 종료
                        break;
                    case Constant.ESCAPE_INT:
                        break;
                }
            }
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
                        break;
                    case Constant.SECOND_MENU://로그 초기화
                        LogDAO.GetLog().LogInit();
                        break;
                    case Constant.THIRD_MENU://로그 저장
                        LogDAO.GetLog().SaveLogFile();
                        break;
                    case Constant.FOURTH_MENU://로그 삭제
                        LogDAO.GetLog().DeleteLogFile();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }
    }
}
