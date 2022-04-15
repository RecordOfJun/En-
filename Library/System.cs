using System;
using Library.Controller;
using System.Runtime.InteropServices;
namespace Library

{
    class System
    {

        static void Main(string[] args)
        {
            //LibraryProgram libraryProgram = new LibraryProgram();
            // libraryProgram.start();
            try
            {
                DateTime dt = DateTime.Parse("09:00");
                Console.WriteLine("1");
            }
            catch (FormatException)
            {
                Console.WriteLine("-1");
            }
        }//관리자 아이디:1111111111,비밀번호:9999999999
    }
}
