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
        LectureSelection lectureSelection;
        Exception exception;
        public MainMenu(Instances instances)
        {
            this.basicView = instances.basicView;
            this.input = instances.input;
            this.exception = instances.exception;
            instances.lectureView = new LectureView();
            instances.myLecture = new LectureStorage(Constant.MY_MAX);
            instances.InterestLecture = new LectureStorage(Constant.INTEREST_MAX);
            wholeLecture = new WholeLecture(instances) ;
            interestSelection = new InterestSelection(instances);
            lectureSelection = new LectureSelection(instances);
        }
        public void SelectMenu()
        {
            Console.CursorVisible = false;
            int selected;
            bool isNotEscape = true;
            while (isNotEscape) {
                Console.Clear();
                basicView.Label();
                basicView.MainMenuForm();
                selected = input.SwicthMenu(Constant.MAIN_MENU_COUNT);//위아래 커서이동 함수 호출
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        wholeLecture.SearchLecture();//전체 시간표 조회
                        break;
                    case (int)Constant.Menu.SECOND_MENU://관심과목 메뉴 이동
                        interestSelection.SelectMenu();
                        break;
                    case (int)Constant.Menu.THIRD_MENU://수강신청 메뉴 이동
                        lectureSelection.SelectMenu();
                        break;
                    case (int)Constant.Menu.FOURTH_MENU://프로그램 종료
                        exception.ExitProgramm();
                        break;
                    case Constant.ESCAPE_INT:
                        Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐 방지
                        basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.CUSOR_DELETE);
                        isNotEscape = false;
                        break;
                }
            }
        }
    }
}
