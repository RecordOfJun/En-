using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    class LectureView
    {
        public void SelectLectureForm()
        {
            Console.WriteLine("  개설학과전공");
            Console.WriteLine("  이수구분");
            Console.WriteLine("  교과목명");
            Console.WriteLine("  교수명");
            Console.WriteLine("  학년");
            Console.WriteLine("  조회");
        }
        public void SelectMajorForm()
        {
            Console.Write("  전체         컴퓨터공학과     소프트웨어공학과   지능기전공학부    기계항공우주공학부");

        }
        public void SelectDistributionForm()
        {
            Console.Write("  전체         교양필수         전공필수           전공선택");
        }
        public void SelectProfessorForm()
        {
            Console.Write("교수명 입력:");
        }
        public void SelectClassNameForm()
        {
            Console.Write("교과목명 입력:");
        }
        public void SelectDivisionForm()
        {
            Console.Write("학수번호 입력:                    분반 입력:");
        }
        public void SelectCourseForm()
        {
            Console.Write("  전체         1학년            2학년              3학년");
        }
        public void SelectInterstForm()
        {
            Console.WriteLine("  개설학과전공");
            Console.WriteLine("  학수번호");
            Console.WriteLine("  교과목명");
            Console.WriteLine("  교수명");
            Console.WriteLine("  학년");
            Console.WriteLine("  조회");
        }
    }
}
