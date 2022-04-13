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
        BasicView ui;
        public Input(BasicView ui)
        {
            this.ui = ui;
        }
        public string GetUserInput(int maximumLength,int inputType)//원하는 길이 이하로 입력을 받아주는 메소드 & 화면에 SPREAD
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
                    //
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
                ui.DeleteSting(startCusorIndex, maximumLength);
                RefreshString(inputString, inputType);//입력한 문자열 출력
            }
            return inputString;
        }
        private void RefreshString(string inputString, int inputType)//예외필터를 거쳐 입력된 문자열을 출력해주는 함수
        {
            if (inputType == Constant.HIDE_INPUT)
                ui.WritePassword(inputString);
            else
                ui.SetInputCursor(inputString);
        }
    }
}
