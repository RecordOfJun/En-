using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class MenuSelection//메뉴 선택 관련 메소드 구현 클래스
    {
        BasicView ui;
        Input input;
        public MenuSelection()
        {
            ui = new BasicView();
            input = new Input(ui);
        }
        public int SelectMenu()//키보드 입력을 감지해 인덱스가 가리키는 메뉴 화면에 띄어주기
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.MenuGuide();
            ui.MainMenu();
            return input.SwicthMenu(4);
        }
        public int SelectUserMenu()//로그인 후 나오는 메뉴 선택
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.MemberGuide();
            ui.UserMenu();
            return input.SwicthMenu(5);
        }
        public int SelectAdminMenu()//관리자 메뉴 선택
        {
            Console.Clear();
            ui.AdminLabel();
            ui.AdminGuide();
            ui.AdminMenu();
            return input.SwicthMenu(3);
        }
        public int SelectBookMenu()//관리자 메뉴 선택
        {
            Console.Clear();
            ui.AdminLabel();
            ui.AdminGuide();
            ui.BookManage();
            return input.SwicthMenu(4);
        }
        public int SelectMemberMenu()//관리자 메뉴 선택
        {
            Console.Clear();
            ui.AdminLabel();
            ui.AdminGuide();
            ui.MemberManage();
            return input.SwicthMenu(3);
        }

    }
}
