using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    class InterestLecture
    {
        public List<LectureVO> interestList;
        private int currentGrades = 0;
        private int maximumGrades = 24;
        public InterestLecture()
        {
            interestList = new List<LectureVO>();
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
