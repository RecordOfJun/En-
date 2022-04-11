using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;
namespace Library.Controller
{
    class MenuSelection
    {
        UI ui;
        public MenuSelection()
        {
            ui = new UI();
        }
        public int SelectMenu()//키보드 입력을 감지해 인덱스가 가리키는 메뉴 화면에 띄어주기
        {
            bool isEnter = false;
            int index = 0;
            int selectedMenu = index;
            Console.Clear();
            ui.LibraryLabel();
            ui.MenuGuide();
            ui.MainMenu();
            while (!isEnter)
            {
                SetArrow(selectedMenu);
                index = CheckKey(selectedMenu, Constant.MAIN_MENU_LENGTH);
                if (index == Constant.RETURN)
                    break;
                if(index!=Constant.QUIT)
                selectedMenu = index;
            }
            return selectedMenu;
        }
        public int SelectUserMenu()//로그인 후 나오는 메뉴 선택
        {
            bool isEnter = false;
            int index = 0;
            int selectedMenu = index;
            Console.Clear();
            ui.LibraryLabel();
            ui.MemberGuide();
            ui.UserMenu();
            while (!isEnter)
            {
                SetArrow(selectedMenu);
                index = CheckKey(selectedMenu, Constant.USER_MENU_LENGTH);
                if (index == Constant.RETURN)
                    break;
                if (index == Constant.QUIT)
                    return Constant.QUIT;
                else
                    selectedMenu = index;
            }
            return selectedMenu;
        }
        public int SelectAdminMenu()//관리자 메뉴 선택
        {
            bool isEnter = false;
            int index = 0;
            int selectedMenu = index;
            Console.Clear();
            ui.AdminLabel();
            ui.MemberGuide();
            ui.AdminMenu();
            while (!isEnter)
            {
                SetArrow(selectedMenu);
                index = CheckKey(selectedMenu, Constant.ADMIN_MENU_LENGTH);
                if (index == Constant.RETURN)
                    break;
                if (index == Constant.QUIT)
                    return Constant.QUIT;
                else
                    selectedMenu = index;
            }

            return selectedMenu;
        }
        private int CheckKey(int index,int Lenth)//어떤 키가 들어왔는지 감지 (단,위 아래 엔터 ESC만 감지)
        {
            ConsoleKeyInfo upAndDown = Console.ReadKey();
            switch (upAndDown.Key)
            {
                case ConsoleKey.UpArrow:
                    index += Constant.UP;
                    break;
                case ConsoleKey.DownArrow:
                    index += Constant.DOWN;
                    break;
                case ConsoleKey.Enter:
                    return Constant.RETURN;
                case ConsoleKey.Escape:
                    return Constant.QUIT;
                default:
                    break;
            }
            if (index < Constant.INDEX_MINIMUM)
                index += Lenth;
            index = index % Lenth;
            return index;
        }
        private void SetArrow(int index)
        {
            for (int indexOfY = Constant.FIRST_MENU_INDEX; indexOfY <= Constant.FIFTH_MENU_INDEX; indexOfY += Constant.DISTANCE_OF_INDEX)
            {
                SetMenuCursor(indexOfY, Constant.ERASE);
            }
            switch (index)
            {
                case Constant.FIRST_MENU:
                    SetMenuCursor(Constant.FIRST_MENU_INDEX, Constant.ARROW);
                    break;
                case Constant.SECOND_MENU:
                    SetMenuCursor(Constant.SECOND_MENU_INDEX, Constant.ARROW);
                    break;
                case Constant.THIRD_MENU:
                    SetMenuCursor(Constant.THIRD_MENU_INDEX, Constant.ARROW);
                    break;
                case Constant.FOURTH_MENU:
                    SetMenuCursor(Constant.FOURTH_MENU_INDEX, Constant.ARROW);
                    break;
                case Constant.FIFTH_MENU:
                    SetMenuCursor(Constant.FIFTH_MENU_INDEX, Constant.ARROW);
                    break;
            }
        }
        private void SetMenuCursor(int index,char insert)
        {
            Console.SetCursorPosition(Constant.ARROW_INDEX, index);
            Console.Write(new string(insert, 1));
            Console.Write(new string(Constant.ERASE, 1));
            Console.SetCursorPosition(Constant.ARROW_INDEX+1, index);
        }
    }
}
