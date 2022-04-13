using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
namespace LTT.Controller
{
    class MainMenu
    {
        BasicView basicView;
        ExceptionView exceptionView;
        Input input;
        public MainMenu(ExceptionView exceptionView,BasicView basicView,Input input)
        {
            this.basicView = basicView;
            this.exceptionView = exceptionView;
            this.input = input;
        }
        public void SelectMenu()
        {
            int selected;
            bool isNotEscape = true;
            while (isNotEscape) {
                Console.Clear();
                selected = SwicthMenu();
                switch (selected)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    case Constant.ESCAPE_INT:
                        Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐
                        basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 1);
                        isNotEscape = false;
                        break;
                }
            }
        }
        private int SwicthMenu()//함수로 뺄 여지가 있음
        {
            int index = 0;
            int selected = 0;
            bool isNotEnter = true;
            basicView.MainMenuForm();
            while (isNotEnter)
            {
                basicView.DeleteString(0, 0, 1);
                basicView.DeleteString(0, 1, 1);
                basicView.DeleteString(0, 2, 1);
                basicView.DeleteString(0, 3, 1);
                basicView.DeleteString(0, 4, 1);
                switch (index)//
                {
                    case 0:
                        Console.SetCursorPosition(0, 0);
                        break;
                    case 1:
                        Console.SetCursorPosition(0, 1);
                        break;
                    case 2:
                        Console.SetCursorPosition(0 , 2);
                        break;
                    case 3:
                        Console.SetCursorPosition(0 , 3);
                        break;
                    case 4:
                        Console.SetCursorPosition(0, 4);
                        break;
                }
                Console.Write(">");
                index = input.GetUpDown(index, 5);
                if (index == Constant.RETURN)
                    return selected;
                if (index == Constant.ESCAPE_INT)
                    return Constant.ESCAPE_INT;
                selected = index;
            }
            return selected;
        }
    }
}
