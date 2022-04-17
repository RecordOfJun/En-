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
            major = "";
            distribution = "";
            professor = "";
            lectureName = "";
            course = "";
            lectureNumber = "";
            division = "";
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
            Regex days = new Regex(@"[월|화|수|목|금]");
            Regex times = new Regex(@"[0-9]{2}:[0-9]{2}");
            MatchCollection dayResult = days.Matches(time);
            MatchCollection timeResult = times.Matches(time);
            //수업 날짜, 수업시작 시간, 종료시간을 시간 관리 클래스에 넣어줌
            if (dayResult.Count == 1)//날짜가 하루뿐일 때
            {
                AddTimeTable(dayResult, timeResult, 0, 0);
            }
            else if (dayResult.Count == 2 && timeResult.Count == 2)//날짜 두개의 시간이 같을 때
            {
                AddTimeTable(dayResult, timeResult, 0, 0);
                AddTimeTable(dayResult, timeResult, 1, 0);

            }
            else if (dayResult.Count == 2 && timeResult.Count == 4)//날짜 두개의 시간이 서로 다를 때
            {
                AddTimeTable(dayResult, timeResult, 0, 0);
                AddTimeTable(dayResult, timeResult, 1, 2);
            }
        }
        private void AddTimeTable(MatchCollection dayResult, MatchCollection timeResult,int dayIndex,int timeIndex)
        {
            TimeTable timeTable = new TimeTable();
            timeTable.day = dayResult[dayIndex].Value.ToString();
            timeTable.startTime = DateTime.Parse(timeResult[timeIndex].Value.ToString());
            timeTable.finishTime = DateTime.Parse(timeResult[timeIndex+1].Value.ToString());
            timeTables.Add(timeTable);
        }
    }
}
