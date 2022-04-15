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
        private int currentGrades = 0;
        private int maximumGrades;
        public LectureStorage(int maximumGrades)
        {
            storeList = new List<LectureVO>();
            this.maximumGrades = maximumGrades;
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
