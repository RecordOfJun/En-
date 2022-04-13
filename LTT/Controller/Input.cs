using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
namespace LTT.Controller
{
    class Input
    {
        BasicView basicView;
        public Input(BasicView basicView)
        {
            this.basicView = basicView;
        }
        public string GetUserString(int maximumLength,int inputType)//원하는 길이 이하로 입력을 받아주는 메소드 & 화면에 SPREAD
        {
            ConsoleKeyInfo key;
            int startCusorIndex = Console.CursorLeft;
            string userinput;
            string inputString = "";
            bool isEnter = false;
            while (!isEnter)//엔터가 입력되기 전 까지 입력
            {

                key = Console.ReadKey();
                bool isArrow = ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.DownArrow)|| (key.Key == ConsoleKey.UpArrow));
                userinput = key.KeyChar.ToString();
                if (key.Key == ConsoleKey.Escape)//ESC눌렀을 시 알림
                {
                    Console.Write("a");//ESC입력하면 다음 출력문에서 문자 하나 먹어짐
                    basicView.DeleteString(Console.CursorLeft, Console.CursorTop, 1);
                    return Constant.ESCAPE_STRING;
                }
                if (key.Key == ConsoleKey.Enter)//엔터 입력 시 입력한 문자열 리턴
                {
                    return inputString;
                }
                if (userinput == "\b")//백스페이스 입력 시 출력 스트링 조정
                {
                    if (inputString.Length > 0)
                    {
                        inputString = inputString.Substring(0, inputString.Length - 1);
                    }
                }
                else if (inputString.Length < maximumLength && !isArrow)//원하는 길이를 초과해서 입력하려고 할 때 방지
                {
                    inputString += userinput;
                }
                basicView.DeleteString(startCusorIndex,Console.CursorTop, maximumLength);
                RefreshString(inputString, inputType);//입력한 문자열 출력
            }
            return inputString;
        }
        private void RefreshString(string inputString, int inputType)//예외필터를 거쳐 입력된 문자열을 출력해주는 함수
        {
            if (inputType == Constant.HIDE_INPUT)
                basicView.WritePassword(inputString);
            else
                basicView.SetInputCursor(inputString);
        }
        public int GetLeftRight(int index,int numberOfMenu)
        {
            ConsoleKeyInfo upAndDown = Console.ReadKey();
            switch (upAndDown.Key)
            {
                case ConsoleKey.LeftArrow://위쪽 방향키 감지
                    index += Constant.UP;
                    break;
                case ConsoleKey.RightArrow://아래쪽 방향 키 감지
                    index += Constant.DOWN;
                    break;
                case ConsoleKey.Enter://엔터 감지
                    return Constant.RETURN;
                case ConsoleKey.Escape://엔터 감지
                    return Constant.ESCAPE_INT;
                default:
                    break;
            }
            if (index < Constant.INDEX_MINIMUM)//위,아래 방향 키 입력시 커서가 가리키는 메뉴 인덱스 조정
                index += numberOfMenu;
            index = index % numberOfMenu;
            return index;
        }
        public int GetUpDown(int index, int numberOfMenu)
        {
            ConsoleKeyInfo upAndDown = Console.ReadKey();
            switch (upAndDown.Key)
            {
                case ConsoleKey.UpArrow://위쪽 방향키 감지
                    index += Constant.UP;
                    break;
                case ConsoleKey.DownArrow://아래쪽 방향 키 감지
                    index += Constant.DOWN;
                    break;
                case ConsoleKey.Enter://엔터 감지
                    return Constant.RETURN;
                case ConsoleKey.Escape://엔터 감지
                    return Constant.ESCAPE_INT;
                default:
                    break;
            }
            if (index < Constant.INDEX_MINIMUM)//위,아래 방향 키 입력시 커서가 가리키는 메뉴 인덱스 조정
                index += numberOfMenu;
            index = index % numberOfMenu;
            return index;
        }
    }
}
