using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Controller
{
    class LibraryProgram
    {
        MenuSelection menuSelection = new MenuSelection();
        UserFunction userFunction = new UserFunction();
        public LibraryProgram()
        {

        }
        public void start()
        {
            int selectedMenu;
            selectedMenu=menuSelection.SelectMenu();
            switch (selectedMenu)
            {
                case Constant.FIRST_MENU:
                    
                    break;
                case Constant.SECOND_MENU:
                    userFunction.AddMember();
                    break;
                case Constant.THIRD_MENU:
                    
                    break;
                case Constant.FOURTH_MENU:
                    
                    break;
                case Constant.FIFTH_MENU:
                    return;
            }
        }
    }
}
