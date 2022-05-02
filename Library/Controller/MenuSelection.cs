using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class MenuSelection//메뉴 선택 관련 메소드 구현 클래스
    {
        Basic ui;
        public MenuSelection()
        {
            ui = new Basic();
        }
        public int SelectMenu(int index)//키보드 입력을 감지해 인덱스가 가리키는 메뉴 화면에 띄어주기
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.MenuGuide();
            ui.MainMenu();
            return KeyProcessing.GetInput().SwicthMenu(5,index);
        }
        public int SelectUserMenu(int index)//로그인 후 나오는 메뉴 선택
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.MemberGuide();
            ui.UserMenu();
            return KeyProcessing.GetInput().SwicthMenu(5,index);
        }
        public int SelectAdminMenu(int index)//관리자 메뉴 선택
        {
            Console.Clear();
            ui.AdminLabel();
            ui.AdminGuide();
            ui.AdminMenu();
            return KeyProcessing.GetInput().SwicthMenu(3,index);
        }
        public int SelectBookMenu(int index)//도서관리 메뉴 선택
        {
            Console.Clear();
            ui.AdminLabel();
            ui.AdminGuide();
            ui.BookManage();
            return KeyProcessing.GetInput().SwicthMenu(5,index);
        }
        public int SelectMemberMenu(int index)//회원관리 메뉴 선택
        {
            Console.Clear();
            ui.AdminLabel();
            ui.AdminGuide();
            ui.MemberManage();
            return KeyProcessing.GetInput().SwicthMenu(3,index);
        }

    }
}
