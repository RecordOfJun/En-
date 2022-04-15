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
        protected LectureStorage interestLecture;
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
                        SearchLecture(interestLecture);
                        break;
                    case 1://관심과목 조회
                        lectureView.InterestLabel();
                        ShowInsertLectures(interestLecture.storeList, 1,"관심과목 조회");
                        break;
                    case 2://관심과목 시간표

                        break;
                    case 3://관심과목 삭제
                        DeleteLectures(interestLecture, "관심과목 삭제");
                        break;
                    case 4:
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


        public void SearchLecture(LectureStorage extant)
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
                        ShowRemainLectures(extant);
                        InsertInterest(extant);
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
            bool isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.SEARCH_LEFT+34, Console.CursorTop);
                storage.LectureNumber = input.GetUserString(6, 2);//예외처리 숫자만 입력 2글자 이상 입력
                if (storage.LectureNumber == Constant.ESCAPE_STRING)
                {
                    storage.LectureNumber = "";
                    basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                    return;
                }
                isException =exception.IsLectureNumberForm(storage.LectureNumber);
            }
            isException = true;
            while (isException)
            {
                Console.SetCursorPosition(Constant.SEARCH_LEFT + 64, Console.CursorTop);
                storage.Division = input.GetUserString(3, 2);//예외처리 숫자만 입력 2글자 이상 입력
                if (storage.Division == Constant.ESCAPE_STRING)
                {
                    storage.LectureNumber = "";
                    storage.Division = "";
                    basicView.DeleteString(Constant.SEARCH_LEFT + 20, Console.CursorTop, 100);
                    return;
                }
                isException =exception.IsDivision(storage.Division);
            }
            Console.CursorVisible = false;
        }

        protected void InsertInterest(LectureStorage extant)
        {
            string sequence;
            while (true)
            {
                basicView.DeleteString(0, Console.CursorTop, 150);
                Console.CursorVisible = true;
                lectureView.CheckGrades(extant.MaximumGrades, extant.CurrentGrades);
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
                sequence =GetSequence(extant,searchTable);//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                AddInterest(sequence, extant,searchTable);
                Console.SetCursorPosition(Constant.SEARCH_LEFT + 20, Console.CursorTop);
                lectureView.SelectMore();
                int selected = SwitchColumn(2);
                if (selected == 1 || selected == Constant.ESCAPE_INT)
                    break;
            }
            storage.Init();
        }
        protected string GetSequence(LectureStorage extant,List<LectureVO> lectures)//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
        {
            bool isException=true;
            string sequence="";
            while (isException)
            {

                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 100);
                sequence = input.GetUserString(3, 2);
                if (sequence == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_STRING;
                if (exception.IsNotNumberForm(sequence))
                    isException = true;
                else if (!lectures.Exists(element => element.Sequence == sequence))//검색목록 혹은 관심과목에 없으면
                {
                    exception.NotExistException();
                    isException = true;
                }
                //시간표 겹치는거 예외처리
                else
                {
                    string compare = lectures.Find(element => element.Sequence == sequence).LectureNumber;
                    if (extant.storeList.Exists(element => element.LectureNumber == compare))//과목명 즉 학수번호 일치하는 과목 안받기
                    {
                        exception.OverlapException();
                        isException = true;
                    }
                    else
                        return sequence;
                }
            }
            return sequence;
        }
        protected void AddInterest(string sequence, LectureStorage extant,List<LectureVO> lectures)
        {
            LectureVO lecture = lectures.Find(element => element.Sequence == sequence);
            if (extant.storeList.Exists(element => element.Sequence == sequence))//관심과목에 같은 시퀀스가 존재할때
            {
                //예외처리
                return;
            }
            if (int.Parse(lecture.Grade) + extant.CurrentGrades > extant.MaximumGrades)//학점 초과시
            {
                //예외처리
                return;
            }
            extant.storeList.Add(lecture);
            extant.CurrentGrades += int.Parse(lecture.Grade);
        }
        private void ShowRemainLectures(LectureStorage extant)
        {
            Console.SetCursorPosition(0, 7);
            searchTable.RemoveAll(element => true);
            foreach (LectureVO table in lectureTable)
            {
                if (table.Sequence == "NO" || !extant.storeList.Exists(element=>element.Sequence==table.Sequence)&&(table.Division.Contains(storage.Division) && table.LectureNumber.Contains(storage.LectureNumber) && table.Major.Contains(storage.Major) && table.Professor.ToUpper().Contains(storage.Professor.ToUpper()) && table.LectureName.ToUpper().Contains(storage.LectureName.ToUpper()) && table.Course.Contains(storage.Course)))
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
        protected void ShowInsertLectures(List<LectureVO> insertList,int type,string insert)
        {
            Console.Clear();
            Console.SetCursorPosition(70, 0);
            Console.WriteLine(insert);
            for (int column = (int)Constant.SECTOR.SEQUENCE; column <= (int)Constant.SECTOR.LANGUAGE; column++)
            {
                lectureView.ShowLecture(column, lectureTable[0]);
            }
            Console.Write(new string('=', Console.WindowWidth));
            Console.WriteLine();
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
        protected void DeleteLectures(LectureStorage extant,string insert)
        {
            string sequence;
            while (true)
            {
                ShowInsertLectures(extant.storeList, 2,insert);
                lectureView.CheckLectureNumber(extant.MaximumGrades,extant.CurrentGrades);
                sequence = GetDeleteSequence(extant.storeList);
                if (sequence == Constant.ESCAPE_STRING)
                    return;
                LectureVO toDelete = extant.storeList.Find(element => element.Sequence == sequence);
                extant.CurrentGrades -= int.Parse(toDelete.Grade);
                extant.storeList.Remove(toDelete);
            }
            
        }
        protected string GetDeleteSequence(List<LectureVO> insertList)//계속받게 getsequence 만들기(예외처리로 검색목록중에 있는거 선택하게 하기,숫자만 입력받기)
        {
            bool isException = true;
            string sequence = "";
            while (isException)
            {
                Console.SetCursorPosition(42, Console.CursorTop);
                basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 10);
                sequence = input.GetUserString(3, 2);
                if (sequence == Constant.ESCAPE_STRING)
                    return Constant.ESCAPE_STRING;
                if (exception.IsNotNumberForm(sequence))
                    isException = true;
                else if (!insertList.Exists(element => element.Sequence == sequence))//검색목록 혹은 관심과목에 없으면
                {
                    exception.NotExistException();
                    isException = true;
                }
                else if (insertList.Exists(element => element.Sequence == sequence))
                    break;
            }
            return sequence;
        }
    }
}
