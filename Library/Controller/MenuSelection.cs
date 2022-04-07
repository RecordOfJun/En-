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
        public void SelectMenu()
        {
            bool isEnter = false;
            int index = 0;
            while (!isEnter)
            {
                Console.Clear();
                ui.LibraryLabel();
                ui.MenuGuide();
                SwitchMenu(index);
                ConsoleKeyInfo upAndDown = Console.ReadKey();
                switch (upAndDown.KeyChar)
                {
                    case 'w':
                        index+= Constant.UP;
                        break;
                    case 's':
                        index+= Constant.DOWN;
                        break;
                    case '\n':
                        isEnter = true;
                        break;
                    default:
                        break;
                }
                if (index < Constant.INDEX_MINIMUM)
                    index += Constant.MENU_LENGTH;
                index = index % Constant.MENU_LENGTH;
            }
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
