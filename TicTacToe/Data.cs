using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Data//게임에 필요한 각종 데이터 및 출력물들을 관리하는 클래스
    {
        public List<string> stateOfSquare = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };//영역 선택을 반영해 출력하기 위한 문자열 리스트
        public List<int> indexOfSquare  = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };//각종 메소드 활용 용도 정수 리스트
        //게임 결과에 따른 승리 횟수
        public int userWin;
        public int computerWin;
        public int firstPlayerWin;
        public int secondPlayerWin;
        public int drawVersusPlayer;
        public int drawVersusComputer;
        public Data()
        {
            userWin = 0;
            computerWin = 0;
            firstPlayerWin = 0;
            secondPlayerWin = 0;
            drawVersusComputer = 0;
            drawVersusPlayer = 0;
        }
        public void PrintSqaure(int numberOfLine)//틱택토 1x3 한줄 출력 메소드, 3x3 matrix에서 행의 seauence를 인자로 받는다.
        {
            int leftSquareNum = numberOfLine*3;//해당 행의 사각형들에 리스트 인덱스 부착
            int middleSquareNum = numberOfLine * 3 + 1;
            int rightSquareNum = numberOfLine * 3 + 2;
            if (numberOfLine==0)
                Console.WriteLine("###########################################");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("#             #             #             #");
            Console.Write("#      ");
            CheckSelected(stateOfSquare[leftSquareNum]);//선택 여부에 따라 색깔 표기
            Console.Write("      #      "); 
            CheckSelected(stateOfSquare[middleSquareNum]);
            Console.Write("      #      ");
            CheckSelected(stateOfSquare[rightSquareNum]);
            Console.WriteLine("      #");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("#             #             #             #");
            Console.WriteLine("###########################################");
            
        }
        private void CheckSelected(string squareLocation )//영역별 선택 여부에 따라 색깔을 다르게 표현해주는 메소드
        {
            if (squareLocation == "O")//첫번째 순서가 선택한 영역을 빨간색으로 출력
                Console.ForegroundColor = ConsoleColor.Red;
            else if (squareLocation == "X")//두번째 순서가 선택한 영역을 파란색으로 출력
                Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(squareLocation);//나머지는 흰색
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowLabel()//틱택토 레이블 출력물
        {
            Console.WriteLine(" #########  #     ###     #########      #        ###    #########     ##      ######## ");
            Console.WriteLine("     #      #    #            #         # #      #           #        #  #     #        ");
            Console.WriteLine("     #      #   #             #        #####    #            #       #    #    ######## ");
            Console.WriteLine("     #      #    #            #       #     #    #           #        #  #     #        ");
            Console.WriteLine("     #      #     ###         #      #       #    ###        #         ##      ######## ");
            Console.WriteLine("                                                                                        ");
            Console.WriteLine("                                                                                        ");

        }
        public void ShowMenu()//틱택토 메뉴 선택 출력물
        {
            Console.WriteLine("                                 메뉴를 선택해 주세요!                                  ");
            Console.WriteLine("                                1. Player1 vs Player2                                   ");
            Console.WriteLine("                                2.   User vs Computer                                   ");
            Console.WriteLine("                                3.    SocreBoard                                        ");
            Console.WriteLine("                                4.   프로그램 종료                                       ");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.Write("메뉴 번호 중 하나를 골라 입력해 주세요!:");
        }
        public void ScoreBoard()//스코어보드 출력물
        {
            Console.WriteLine("                                     SCORE BOARD                                  ");
            Console.WriteLine("");
            Console.WriteLine("                             승                      승             ");
            Console.WriteLine("                             {0}   Player1 vs Player2  {0}                                   ", firstPlayerWin,secondPlayerWin);
            Console.WriteLine("                                     무승부 수:{0}",drawVersusPlayer);
            Console.WriteLine("");
            Console.WriteLine("                             {0}    User   vs Computer {0}                                    ", userWin, computerWin);
            Console.WriteLine("                                     무승부 수:{0}",drawVersusComputer);
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
    }
}
