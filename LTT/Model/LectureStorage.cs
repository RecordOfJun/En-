using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    class LectureStorage
    {
        public List<LectureVO> storeList;
        public string[,] timeTable;
        private int currentGrades = 0;
        private int maximumGrades;
        public LectureStorage(int maximumGrades)
        {
            storeList = new List<LectureVO>();
            this.maximumGrades = maximumGrades;
            timeTable = new string[Constant.MAXIMUM_COLUMN,Constant.MAXIMUM_ROW];//시간표 출력을 위한 2차원 배열 선언
        }
        public void Init()//2차원 배열 초기화
        {
            DateTime dateTime = DateTime.Parse(Constant.FIRST_LECTURE_TIME);//08:30분 부터 시작
            for (int row = Constant.MINIMUM_ROW; row< Constant.MAXIMUM_ROW; row++)
            {
                if (row % 2 == 0)//짝수번째 열에
                {
                    timeTable[0, row] = dateTime.ToString("HH:mm");//시작시간
                    timeTable[1, row] = "~";
                    dateTime=dateTime.AddMinutes(Constant.HALF_HOUR);//30분 더해서 종료시간 넣어주기
                    timeTable[2, row] = dateTime.ToString("HH:mm");
                    for (int column = Constant.MONDAY_COLUMN; column < Constant.MAXIMUM_COLUMN; column++)
                        timeTable[column, row] = Constant.EMPTY;//과목명 값 다 비우기
                }
                else
                {
                    for (int column = 0; column < 8; column++)
                        timeTable[column, row] = Constant.EMPTY;//강의실 값 다 비우기
                }
            }
        }
        public void InsertTime()//2차원 배열에 신청한 강의 삽입
        {
            foreach(LectureVO lecture in storeList)
            {
                foreach(TimeTable lectureTime in lecture.timeTables)
                {
                    int startIndex = ((int.Parse(lectureTime.startTime.ToString("HH")) - 8)*2-1 + int.Parse(lectureTime.startTime.ToString("mm")) / 30)*2;//수업 시작에 해당하는 배열 인덱스 찾기
                    int finishIndex= ((int.Parse(lectureTime.finishTime.ToString("HH")) - 9)*2 + int.Parse(lectureTime.finishTime.ToString("mm")) / 30)*2;//수업 종료에 해당하는  배열인덱스 찾기
                    int dayIndex=0;
                    switch (lectureTime.day)
                    {
                        case Constant.MONDAY:
                            dayIndex = (int)Constant.TimeTableIndex.MONDAY;
                            break;
                        case Constant.TUESDAY:
                            dayIndex = (int)Constant.TimeTableIndex.TUESDAY;
                            break;
                        case Constant.WEDNESDAY:
                            dayIndex = (int)Constant.TimeTableIndex.WEDNESDAY;
                            break;
                        case Constant.THURSDAY:
                            dayIndex = (int)Constant.TimeTableIndex.THURSDAY;
                            break;
                        case Constant.FRIDAY:
                            dayIndex = (int)Constant.TimeTableIndex.FRIDAY;
                            break;
                    }
                    for(int index = startIndex; index <= finishIndex; index+=2)
                    {//찾은 배열 인덱스를 통해 배열에 강의내역 삽입
                        timeTable[dayIndex, index] = lecture.LectureName;
                        timeTable[dayIndex, index+1] = lecture.Place;
                    }
                }
            }
        }
        public int CurrentGrades{
            get { return currentGrades; }
            set {  currentGrades=value; }
        }
        public int MaximumGrades
        {
            get { return maximumGrades; }
        }
    }
}
