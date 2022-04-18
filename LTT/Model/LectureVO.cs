using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LTT.Model
{
    class TimeTable
    {
        public string day;
        public DateTime startTime;
        public DateTime finishTime;
    }
    class LectureVO
    {
        private string sequence;
        private string major;
        private string distribution;
        private string professor;
        private string lectureName;
        private string course;
        private string lectureNumber;
        private string division;
        private string grade;
        private string time;
        private string place;
        private string language;
        public List<TimeTable> timeTables;
        public LectureVO() {
            timeTables = new List<TimeTable>();//시간 관리해주는 리스트 추가
        }
        public void Init()
        {
            major = Constant.EMPTY;
            distribution = Constant.EMPTY;
            professor = Constant.EMPTY;
            lectureName = Constant.EMPTY;
            course = Constant.EMPTY;
            lectureNumber = Constant.EMPTY;
            division = Constant.EMPTY;
        }

        public string Major
        {
            get { return major; }
            set { major = value; }
        }
        public string Distribution
        {
            get { return distribution; }
            set { distribution = value; }
        }
        public string Professor
        {
            get { return professor; }
            set { professor = value; }
        }
        public string LectureName
        {
            get { return lectureName; }
            set { lectureName = value; }
        }
        public string Course
        {
            get { return course; }
            set { course = value; }
        }
        public string Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }
        public string LectureNumber
        {
            get { return lectureNumber; }
            set { lectureNumber = value; }
        }
        public string Division
        {
            get { return division; }
            set { division = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value;
                SetTimeTable();//시간 입력받을 때 날짜와 시간 추출
            }
        }
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        private void SetTimeTable()
        {
            Regex days = new Regex(@"[월|화|수|목|금]");//강의 시간을 저장한 문자열에서 날짜 추출하기
            Regex times = new Regex(@"[0-9]{2}:[0-9]{2}");//강의 시간을 저장한 문자열에서 시작시간,종료시간 추출하기
            MatchCollection dayResult = days.Matches(time);
            MatchCollection timeResult = times.Matches(time);
            //수업 날짜, 수업시작 시간, 종료시간을 시간 관리 클래스에 넣어줌
            if (dayResult.Count == 1)//날짜가 하루뿐일 때
            {
                AddTimeTable(dayResult, timeResult, Constant.FIRST_DAY, Constant.FIRST_START_TIME);//날짜 하나에 시작시간,종료시간 넣어줌
            }
            else if (dayResult.Count == 2 && timeResult.Count == 2)//날짜 두개의 시간이 같을 때
            {
                AddTimeTable(dayResult, timeResult, Constant.FIRST_DAY, Constant.FIRST_START_TIME);//날짜 두개에 같은 시작시간과 같은 종료시간 넣어줌
                AddTimeTable(dayResult, timeResult, Constant.SECOND_DAY, Constant.FIRST_START_TIME);

            }
            else if (dayResult.Count == 2 && timeResult.Count == 4)//날짜 두개의 시간이 서로 다를 때
            {
                AddTimeTable(dayResult, timeResult, Constant.FIRST_DAY, Constant.FIRST_START_TIME);//첫번째 날짜에 첫번째 시작시간과 종료시간 넣어줌
                AddTimeTable(dayResult, timeResult, Constant.SECOND_DAY, Constant.SECOND_START_TIME);//두번째 날짜에 두번째 시작시간과 종료시간 넣어줌
            }
        }
        private void AddTimeTable(MatchCollection dayResult, MatchCollection timeResult,int dayIndex,int timeIndex)//시간 관리 객체 추가함수
        {
            TimeTable timeTable = new TimeTable();//객체 생성
            timeTable.day = dayResult[dayIndex].Value.ToString();//날자 넣어주기
            timeTable.startTime = DateTime.Parse(timeResult[timeIndex].Value.ToString());//시작시간 넣어주기
            timeTable.finishTime = DateTime.Parse(timeResult[timeIndex+1].Value.ToString());//종료시간 넣어주기
            timeTables.Add(timeTable);//리스트에 추가
        }
    }
}
