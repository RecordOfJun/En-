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
            Console.SetWindowSize(81, 40);
            ui = new UI();
        }
        public int SelectMenu()
        {
            bool isEnter = false;
            int index = 0;
            int selectedMenu = index;
            while (!isEnter)
            {
                Console.Clear();
                ui.LibraryLabel();
                ui.MenuGuide();
                SwitchMenu(index);
                index = CheckKey(index, Constant.MAIN_MENU_LENGTH);
                if (index == -1)
                    break;
                selectedMenu = index;
            }
            return selectedMenu;
        }
        private void SwitchMenu(int index)
        {
            switch (index)
            {
                case Constant.FIRST_MENU:
                    ui.SelectFirst();
                    break;
                case Constant.SECOND_MENU:
                    ui.SelectSecond();
                    break;
                case Constant.THIRD_MENU:
                    ui.SelectThird();
                    break;
                case Constant.FOURTH_MENU:
                    ui.SelectFourth();
                    break;
            }
        }
        public int SelectUserMenu()
        {
            bool isEnter = false;
            int index = 0;
            int selectedMenu = index;
            while (!isEnter)
            {
                Console.Clear();
                ui.LibraryLabel();
                ui.MemberGuide();
                SwitchUserMenu(index);
                index = CheckKey(index, Constant.USER_MENU_LENGTH);
                if (index == -1)
                    break;
                selectedMenu = index;
            }
            return selectedMenu;
        }
        private void SwitchUserMenu(int index)
        {
            switch (index)
            {
                case Constant.FIRST_MENU:
                    ui.UserSelectFirst();
                    break;
                case Constant.SECOND_MENU:
                    ui.UserSelectSecond();
                    break;
                case Constant.THIRD_MENU:
                    ui.UserSelectThird();
                    break;
                case Constant.FOURTH_MENU:
                    ui.UserSelectFourth();
                    break;
                case Constant.FIFTH_MENU:
                    ui.UserSelectFifth();
                    break;
            }
        }
        public int SelectAdminMenu()
        {
            bool isEnter = false;
            int index = 0;
            int selectedMenu = index;
            while (!isEnter)
            {
                Console.Clear();
                ui.AdminLabel();
                ui.MemberGuide();
                SwitchAdminMenu(index);
                index = CheckKey(index, Constant.ADMIN_MENU_LENGTH);
                if (index == -1)
                    break;
                selectedMenu = index;
            }

            return selectedMenu;
        }
        private void SwitchAdminMenu(int index)
        {
            switch (index)
            {
                case Constant.FIRST_MENU:
                    ui.AdminSelectFirst();
                    break;
                case Constant.SECOND_MENU:
                    ui.AdminSelectSecond();
                    break;
                case Constant.THIRD_MENU:
                    ui.AdminSelectThird();
                    break;
                case Constant.FOURTH_MENU:
                    ui.AdminSelectFourth();
                    break;
            }
        }
        private int CheckKey(int index,int Lenth)
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
                    return -1;
                case ConsoleKey.Escape:
                    break;
                default:
                    break;
            }
            if (index < Constant.INDEX_MINIMUM)
                index += Lenth;
            index = index % Lenth;
            return index;
        }
    }
}
