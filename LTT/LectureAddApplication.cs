using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Controller;
using Excel = Microsoft.Office.Interop.Excel;
namespace LTT
{
    class LectureAddApplication
    {
        static void Main(string[] args)
        {
            //"아이디: 18011514 비밀번호: 11111입니다."
            Login login = new Login();//로그인 시작 
            login.GetInProgram();
        }
    }
}
