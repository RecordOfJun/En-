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
        public Interface basicUI;
        public Book bookUI;
        public Member memberUI;
    }
    class MainMenu
    {
        ExceptionAndView exceptionAndView = new ExceptionAndView();
        MenuSelection menuSelection = new MenuSelection();
        Exception exception = new Exception();
        ExceptionView exceptionView = new ExceptionView();
        Interface basicUI=new Interface();
        Book bookUI=new Book();
        Member memberUI=new Member();
        User user;
        Admin admin;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        public MainMenu()
        {
            exceptionAndView.exceptionView = exceptionView;
            exceptionAndView.exception = exception;
            exceptionAndView.basicUI = basicUI;
            exceptionAndView.bookUI = bookUI;
            exceptionAndView.memberUI = memberUI;
            user = new User(exceptionAndView);
            admin=new Admin(exceptionAndView);
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)//콘솔 창 크기 제어 방지
            {
                DeleteMenu(sysMenu, Constant.SC_MINIMIZE, Constant.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constant.SC_MAXIMIZE, Constant.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constant.SC_SIZE, Constant.MF_BYCOMMAND);
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
                        exception.ExitProgramm();//프로그램 종료
                        break;
                    case Constant.ESCAPE_INT:
                        break;
                }
            }
        }
        
    }
}
