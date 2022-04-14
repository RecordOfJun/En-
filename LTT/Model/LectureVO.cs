using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace LTT.Model
{
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
            set {  division= value; }
        }
        public string Grade 
        {
            get { return grade; }
            set {  grade= value; }
        }
        public string Place
        {
            get { return place; }
            set {  place= value; }
        }
        public string Time
        {
            get { return time; }
            set {  time= value; }
        }
        public string Language 
        {
            get { return language; }
            set {  language= value; }
        }
    }
}
