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
                basicView.MyLectureForm();
                selected = input.SwicthMenu(6);
                switch (selected)
                {
                    case 0://수강신청
                        SearchLecture(myLecture);
                        break;
                    case 1://관심과목으로 신청
                        AddFromInterest();
                        break;
                    case 2://신청한 내역
                        ShowInsertLectures(myLecture.storeList, 1,"수강신청 내역");
                        break;
                    case 3://시간표 조회
                        
                        break;
                    case 4://수강내역 삭제
                        DeleteLectures(myLecture, "신청내역 삭제");
                        break;
                    case 5:
                        exception.ExitProgramm();
                        break;
                    case Constant.ESCAPE_INT:
                        Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐
                        basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 1);
                        isNotEscape = false;
                        break;
                }
            }
        }

        private void AddFromInterest()
        {
            string sequence;
            while (true)
            {
                ShowInsertLectures(interestLecture.storeList, 2,"관심과목으로 수강신청");
                lectureView.CheckLectureNumber(myLecture.MaximumGrades,myLecture.CurrentGrades);
                sequence = GetSequence(myLecture,interestLecture.storeList);
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                AddInterest(sequence, myLecture, interestLecture.storeList);
            }

        }
    }
}
