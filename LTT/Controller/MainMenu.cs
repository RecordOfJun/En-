using System;
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
                selected = input.SwicthMenu(Constant.MAIN_MENU_COUNT);
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        wholeLecture.SearchLecture();
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        interestSelection.SelectMenu();
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        lectureSelection.SelectMenu();
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        exception.ExitProgramm();
                        break;
                    case Constant.ESCAPE_INT:
                        Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐
                        basicView.DeleteString(Console.CursorLeft, Console.CursorTop, Constant.CUSOR_DELETE);
                        isNotEscape = false;
                        break;
                }
            }
        }
    }
}
