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
        public BasicView basicUI;
        public BookView bookUI;
        public MemberView memberUI;
    }
    class MainMenu
    {
        ExceptionAndView exceptionAndView = new ExceptionAndView();
        MenuSelection menuSelection = new MenuSelection();
        Exception exception = new Exception();
        ExceptionView exceptionView = new ExceptionView();
        BasicView basicUI=new BasicView();
        BookView bookUI=new BookView();
        MemberView memberUI=new MemberView();
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
                        user.Login();//로그인
                        break;
                    case Constant.SECOND_MENU:
                        user.AddOrReviseMember(Constant.SIGN_UP);//회원가입
                        break;
                    case Constant.THIRD_MENU:
                        admin.AdminLogin();//관리자 로그인
                        break;
                    case Constant.FOURTH_MENU:
                        exception.ExitProgramm();//프로그램 종료
                        break;
                }
            }
        }
    }
}
