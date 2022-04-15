using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
namespace LTT.Controller
{
    class InterestSelection : WholeLecture
    {
        protected InterestLecture interestLecture;
        public InterestSelection(Instances instances):base (instances)
        {
            this.interestLecture = instances.InterestLecture;
        }


        public void SelectMenu()
        {
            Console.CursorVisible = false;
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                Console.Clear();
                basicView.InterestForm();
                selected = input.SwicthMenu(5);
                switch (selected)
                {
                    case 0://관심과목 담기
                        SearchLecture(interestLecture.interestList);
                        break;
                    case 1://관심과목 조회
                        ShowInsertLectures(interestLecture.interestList,1);
                        break;
                    case 2://관심과목 시간표

                        break;
                    case 3://관심과목 삭제
                        DeleteLectures(interestLecture.interestList);
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


        public void SearchLecture(List<LectureVO> insertList)
        {
            Console.Clear();
            lectureView.SelectInterstForm();
            storage.Init();
            int selected;
            bool isNotEscape = true;
            while (isNotEscape)
            {
                selected = SwicthRow();
                switch (selected)
                {
                    case 0:
                        SelectMajor();
                        break;
                    case 1:
                        SelectDivision();
                        break;
                    case 2:
                        SelectLectureName();
                        break;
                    case 3:
                        SelectProfessor();
                        break;
                    case 4:
                        SelectCourse();
                        break;
                    case 5:
                        ShowRemainLectures();
                        InsertInterest(insertList);
                        Console.Clear();
                        lectureView.SelectInterstForm();
                        break;
                    case Constant.ESCAPE_INT:
                        return;
                }
            }
        }

        protected void SelectDivision()
        {
            Console.CursorVisible = true;
            storage.LectureNumber = "";
            storage.Division = "";
            Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
            basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
            lectureView.SelectDivisionForm();
            while (storage.LectureNumber.Length < 2)
            {
                Console.SetCursorPosition(Constant.SEARCH_LEFT+34, Console.CursorTop);
                storage.LectureNumber = input.GetUserString(6, 2);//예외처리 숫자만 입력 2글자 이상 입력
            }
            if (storage.LectureNumber == Constant.ESCAPE_STRING)
            {
                storage.LectureNumber = "";
                basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                return;
            }
            while (storage.Division.Length < 2)
            {
                Console.SetCursorPosition(Constant.SEARCH_LEFT + 64, Console.CursorTop);
                storage.Division = input.GetUserString(3, 2);//예외처리 숫자만 입력 2글자 이상 입력
            }
            if (storage.Division == Constant.ESCAPE_STRING)
            {
                storage.LectureNumber = "";
                storage.Division = "";
                basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
            }
            Console.CursorVisible = false;
        }

        protected void InsertInterest(List<LectureVO> insertList)
        {
            string sequence;
            while (true)
            {
                basicView.DeleteString(0, Console.CursorTop, 150);
                Console.CursorVisible = true;
                lectureView.CheckGrades(interestLecture.MaximumGrades, interestLecture.CurrentGrades);
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
                sequence =GetSequence(insertList);//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                AddInterest(sequence);
                Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
                lectureView.SelectMore();
                int selected = SwitchColumn(2);
                if (selected == 1 || selected == Constant.ESCAPE_INT)
                    break;
            }
        }
        protected string GetSequence(List<LectureVO> insertList)//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
        {
            string sequence;
            while (true)
            {
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
                sequence = input.GetUserString(3, 2);
                if (sequence == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_STRING;
                //숫자만 입력 예외처리
                if (!searchTable.Exists(element => element.Sequence == sequence))//동일 과목
                {
                    //예외처리
                }
                else
                {
                    string compare = searchTable.Find(element => element.Sequence == sequence).LectureNumber;
                    if(insertList.Exists(element => element.LectureNumber == compare))
                    {
                        //예외처리
                    }
                   else
                        return sequence;
                }
            }
        }
        protected void AddInterest(string sequence)
        {
            LectureVO lecture = searchTable.Find(element => element.Sequence == sequence);
            if (interestLecture.interestList.Exists(element => element.Sequence == sequence))//관심과목에 같은 시퀀스가 존재할때
            {
                //예외처리
                return;
            }
            if (int.Parse(lecture.Grade) + interestLecture.CurrentGrades > interestLecture.MaximumGrades)//학점 초과시
            {
                //예외처리
                return;
            }
            interestLecture.interestList.Add(lecture);
            interestLecture.CurrentGrades += int.Parse(lecture.Grade);
        }
        private void ShowRemainLectures()
        {
            Console.SetCursorPosition(0, 7);
            searchTable.RemoveAll(element => true);
            foreach (LectureVO table in lectureTable)
            {
                if (table.Sequence == "NO" || !interestLecture.interestList.Exists(element=>element.Sequence==table.Sequence)&&(table.Division.Contains(storage.Division) && table.LectureNumber.Contains(storage.LectureNumber) && table.Major.Contains(storage.Major) && table.Professor.ToUpper().Contains(storage.Professor.ToUpper()) && table.LectureName.ToUpper().Contains(storage.LectureName.ToUpper()) && table.Course.Contains(storage.Course)))
                {
                    if (table.Sequence != "NO")
                        searchTable.Add(table);
                    for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
                    {
                        lectureView.ShowLecture(column, table);
                    }
                    if (table.Sequence == "NO")
                    {
                        Console.WriteLine();
                        Console.Write(new string('=', Console.WindowWidth));
                    }
                    else
                        Console.WriteLine();
                }
            }
        }
        protected void ShowInsertLectures(List<LectureVO> insertList,int type)
        {
            Console.Clear();
            Console.SetCursorPosition(70, 0);
            Console.WriteLine("관심과목 조회");
            Console.Write(new string('=', Console.WindowWidth));
            foreach (LectureVO table in insertList)
            {
                for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
                {
                    lectureView.ShowLecture(column, table);
                }
                Console.WriteLine();
            }
            Console.Write(new string('=', Console.WindowWidth));
            if (type == 1)//단순조회
            {
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                        return;
                }
            }
        }
        protected void DeleteLectures(List<LectureVO> insertList)
        {
            string sequence;
            while (true)
            {
                ShowInsertLectures(insertList, 2);
                lectureView.CheckLectureNumber();
                sequence = GetDeleteSequence(insertList);
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                LectureVO toDelete = insertList.Find(element => element.Sequence == sequence);
                insertList.Remove(toDelete);
            }
            
        }
        protected string GetDeleteSequence(List<LectureVO> insertList)//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
        {
            string sequence;
            while (true)
            {
                Console.SetCursorPosition(128, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 10);
                sequence = input.GetUserString(3, 2);
                if (sequence == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_STRING;
                //숫자만 입력 예외처리
                else
                {
                    if (insertList.Exists(element => element.Sequence == sequence))
                        return sequence;
                    else
                    {
                        //없는 시퀀스 예외처리
                    }
                }
            }
        }
    }
}
