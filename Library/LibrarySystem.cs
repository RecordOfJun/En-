using System;
using Library.Controller;
namespace Library
{
    class LibrarySystem
    {
        static void Main(string[] args)
        {
            //MenuSelection menuSelection = new MenuSelection();
            //menuSelection.SelectMenu();
            ConsoleKeyInfo upAndDown = Console.ReadKey();
            Console.WriteLine("{0}",upAndDown.KeyChar);
        }
    }
}
