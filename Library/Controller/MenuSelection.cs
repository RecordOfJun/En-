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
            int selectedMenu;
            while (!isEnter)
            {
                Console.Clear();
                ui.LibraryLabel();
                ui.MenuGuide();
                SwitchMenu(index);
                ConsoleKeyInfo upAndDown = Console.ReadKey();
                switch (upAndDown.Key)
                {
                    case ConsoleKey.UpArrow:
                        index+= Constant.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        index+= Constant.DOWN;
                        break;
                    case ConsoleKey.Enter:
                        isEnter = true;
                        break;
                    default:
                        break;
                }
                if (index < Constant.INDEX_MINIMUM)
                    index += Constant.MENU_LENGTH;
                index = index % Constant.MENU_LENGTH;
            }
            selectedMenu = index;
            return index;
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
                case Constant.FIFTH_MENU:
                    ui.SelectFifth();
                    break;
            }
        }
    }
}
