using System;
using System.Collections.Generic;
using System.Text;
using Library.View;
namespace Library
{
    class KeyProcessing
    {
        BasicView basicView=new BasicView();
        private static KeyProcessing input;
        public static KeyProcessing GetInput()
        {
            if (input == null)
                input = new KeyProcessing();
            return input;
        }
        public int SwicthMenu(int numberOfMenu,int index)//메인메뉴,관심과목 메뉴,수강신청 메뉴 커서 이동 함수
        {
            Console.CursorVisible = false;
            int selected = index;
            bool isNotEnter = true;
            while (isNotEnter)
            {
                switch (index)//상하 방향키 감지로 인데스 조정, 메뉴 커서 조정
                {
                    case (int)Constant.Menu.FIRST_MENU:
                        Console.SetCursorPosition(Constant.MIDDLE_CURSOR, (int)Constant.MenuCursor.FIRST_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        Console.SetCursorPosition(Constant.MIDDLE_CURSOR, (int)Constant.MenuCursor.SECOND_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        Console.SetCursorPosition(Constant.MIDDLE_CURSOR, (int)Constant.MenuCursor.THIRD_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        Console.SetCursorPosition(Constant.MIDDLE_CURSOR, (int)Constant.MenuCursor.FOURTH_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        Console.SetCursorPosition(Constant.MIDDLE_CURSOR, (int)Constant.MenuCursor.FIFTH_MENU_CUSOR);
                        break;
                    case (int)Constant.Menu.SIXTH_MENU:
                        Console.SetCursorPosition(Constant.MIDDLE_CURSOR, (int)Constant.MenuCursor.SIXTH_MENU_CUSOR);
                        break;
                }
                Console.Write(">");//커서 출력
                index = GetUpDown(index, numberOfMenu);//상하 방향키 입력 및 감지
                basicView.DeleteString(Constant.MIDDLE_CURSOR, Console.CursorTop, 1);//기존 커서 삭제
                if (index == Constant.RETURN)
                    return selected;//엔터 누르면 선택값 리턴
                if (index == Constant.ESCAPE_INT)//ESC감지
                    return Constant.ESCAPE_INT;
                selected = index;
            }
            return selected;
        }
        public string GetUserString(int maximumLength, int inputType)//원하는 길이 이하로 입력을 받아주는 메소드 & 화면에 SPREAD
        {
            Console.CursorVisible = true;
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
                basicView.DeleteString(startCusorIndex, Console.CursorTop, maximumLength * 2 + 5);
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
                case ConsoleKey.Escape://esc 감지
                    return Constant.ESCAPE_INT;
                default:
                    break;
            }
            if (index < Constant.INDEX_MINIMUM)//위,아래 방향 키 입력시 커서가 가리키는 메뉴 인덱스 조정
                index += numberOfMenu;
            index = index % numberOfMenu;
            return index;
        }
        public int SwicthSector(int numberOfMenu,int index)//검색 정보 행(세로) 이동 함수
        {
            int selected = index;
            bool isNotEnter = true;
            Console.CursorVisible = false;
            while (isNotEnter)
            {
                //기존 커서 삭제

                switch (index)
                {//위아래 방향키를 감지해 커서 위치 최신화
                    case (int)Constant.Menu.FIRST_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.FIRST_SECTOR_CURSOR);
                        break;
                    case (int)Constant.Menu.SECOND_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.SECOND_SECTOR_CURSOR);
                        break;
                    case (int)Constant.Menu.THIRD_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.THIRD_SECTOR_CURSOR);
                        break;
                    case (int)Constant.Menu.FOURTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.FOURTH_SECTOR_CURSOR);
                        break;
                    case (int)Constant.Menu.FIFTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.FIFTH_SECTOR_CURSOR);
                        break;
                    case (int)Constant.Menu.SIXTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.SIXTH_SECTOR_CURSOR);
                        break;
                    case (int)Constant.Menu.SEVENTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.SEVENTH_SECTOR_CURSOR);
                        break;
                    case (int)Constant.Menu.EIGHTH_MENU:
                        Console.SetCursorPosition(Constant.SEARCH_LEFT, (int)Constant.SectorCursor.EIGHTH_SECTOR_CURSOR);
                        break;

                }
                Console.Write(">");
                index = GetUpDown(index, numberOfMenu);//위 아래 입력 감지해 현재 커서 위치가 어디인지 파악해줌
                basicView.DeleteString(Constant.SEARCH_LEFT, Console.CursorTop, 1);
                if (index == Constant.RETURN)
                    return selected;//엔터 입력 시 선택 정보 리턴
                if (index == Constant.ESCAPE_INT)
                    return Constant.ESCAPE_INT;
                selected = index;
            }
            return selected;
        }
    }
}
