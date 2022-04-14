﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
namespace LTT.Controller
{
    class MainMenu
    {
        BasicView basicView;
        Input input;
        WholeLecture wholeLecture;
        InterestSelection interestSelection;
        public MainMenu(Instances instances)
        {
            this.basicView = instances.basicView;
            this.input = instances.input;
            instances.lectureView = new LectureView();
            instances.myLecture = new MyLecture();
            instances.InterestLecture = new InterestLecture();
            wholeLecture = new WholeLecture(instances) ;
            interestSelection = new InterestSelection(instances);
        }
        public void SelectMenu()
        {
            Console.CursorVisible = false;
            int selected;
            bool isNotEscape = true;
            while (isNotEscape) {
                Console.Clear();
                basicView.MainMenuForm();
                selected = input.SwicthMenu(5);
                switch (selected)
                {
                    case 0:
                        wholeLecture.SearchLecture();
                        break;
                    case 1:
                        interestSelection.SelectMenu();
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
    }
}
