using System;
using Library.Controller;
using System.Runtime.InteropServices;
using Library.Model;
namespace Library

{
    class LibrarySystem
    {

        static void Main(string[] args)
        {
            //MainMenu libraryProgram = new MainMenu();
            //libraryProgram.start();
            string[] book = new string[2];
            book = Console.ReadLine().Split(' ');
            NaverBook naverBook = new NaverBook();
            Console.WriteLine(naverBook.GetRequestResult(book[0], book[1]));
        }//관리자 아이디:1111111111,비밀번호:9999999999
    }
}
