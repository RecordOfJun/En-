using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Model;
using LTT.View;
namespace LTT.Controller
{
    class LectureSelection : InterestSelection
    {
        private LectureStorage myLecture;
        public LectureSelection(Instances instances) : base(instances)
        {
            this.myLecture = instances.myLecture;
        }
        public void SelectMenu()
        {
            Console.CursorVisible = false;
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                Console.Clear();
                basicView.Label();
                basicView.MyLectureForm();
                Console.CursorVisible = false;
                selected = input.SwicthMenu(6);
                switch (selected)
                {
                    case (int)Constant.Menu.FIRST_MENU://수강신청
                        SearchLecture(myLecture);
                        break;
                    case (int)Constant.Menu.SECOND_MENU://관심과목으로 신청
                        AddFromInterest();
                        break;
                    case (int)Constant.Menu.THIRD_MENU://신청한 내역
                        ShowInsertLectures(myLecture,Constant.JUST_SEARCH_TYPE,"수강신청 내역");
                        break;
                    case (int)Constant.Menu.FOURTH_MENU://시간표 조회
                        ShowTimeTable(myLecture,"신청내역 시간표");
                        break;
                    case (int)Constant.Menu.FIFTH_MENU://수강내역 삭제
                        DeleteLectures(myLecture, "삭제할 강의의 번호를 입력하세요");
                        break;
                    case (int)Constant.Menu.SIXTH_MENU://종료
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

        private void AddFromInterest()//관심과목으로부터 수강신청하기
        {
            Console.CursorVisible = true;
            string sequence;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                ShowInsertLectures(interestLecture,Constant.CONTROLL_SEARCH_TYPE,"신청할 과목의 번호를 입력하세요");
                lectureView.CheckLectureNumber(myLecture.MaximumGrades,myLecture.CurrentGrades);
                sequence = GetSequence(myLecture,interestLecture.storeList);//관심과목 내의 번호 입력
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                AddInterest(sequence, myLecture, interestLecture.storeList);//추가
            }

        }
    }
}
