﻿using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

namespace Library.Controller
{
    class LibraryProgram
    {
        VOList listData = new VOList();
        MenuSelection menuSelection = new MenuSelection();
        UserFunction userFunction;
        public LibraryProgram()
        {
            userFunction= new UserFunction(listData.memberList);
        }
        public void start()
        {
            int selectedMenu;
            bool isExit = false;
            while (!isExit) {
                selectedMenu = menuSelection.SelectMenu();
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
}