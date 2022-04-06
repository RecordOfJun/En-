using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class PlayingWithUser
    {
        public View gameData;
        public Utility gameUtility;
        public List<string> stateOfSquare;
        public List<int> indexOfSquare;

        
        public int gameCount ;//게임 진행 횟수 판단 변수
        public int selectedNumber;
        public string inputToSquare;//틱택토 리스트에 넣을 문자를 설정할 변수
        public int gameResult;
        public PlayingWithUser()
        {

            stateOfSquare = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            indexOfSquare = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            gameCount = 0;//게임 진행 횟수 판단 변수
        }
        public void Init(View gameData,Utility gameUtility)
        {
            this.gameData = gameData;
            this.gameUtility = gameUtility;
        }
        public void PlayGame()
        {
            for(int index=0;index<9;index++)
            {
                stateOfSquare[index] = (index + 1).ToString();
                indexOfSquare[index] = index;
            }
            gameCount = 0;
            gameResult = gameUtility.CheckResult(stateOfSquare);
            while (gameResult == Constant.KEEPGOING)//게임 결과가 계속해서 진행일 때
            {
                gameCount++;//진행 횟수 증가
                
                ShowTicTacToe();
                if (gameCount % 2 == Constant.FIRSTPLAYER)//진행 횟수를 2로 나눈 나머지가 1이면 player1차례
                {
                    Console.Write("Player1  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = "X";//리스트에 X를 넣어준다.
                }
                else//0이면 player 2차례
                {
                    Console.Write("Player2  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = "O";//리스트에 O를 넣어준다
                }
                selectedNumber = gameUtility.SelectNumber(10);//선택할 틱택토 영역을 입력받기
                Console.WriteLine("----------------------------------------------------------------------------------------");

                if (selectedNumber == Constant.GOBACK)
                    return;
                selectedNumber = gameUtility.CheckSelected(selectedNumber, indexOfSquare);//영역선택 예외처리

                ManageListAndResult();//선택영역 관리,게임결과 관리
            }
            ShowTicTacToe();
            ShowResult(Constant.FIRSTPLAYER, Constant.SECONDPLAYER, "Player1", "Player2");

        }
        public void ShowTicTacToe()//3X3 틱택토 matrix출력 함수
        {
            Console.Clear();
            int numberOfLine;
            int lastLine = 3;
            for (numberOfLine = 0; numberOfLine < lastLine; numberOfLine++)//1x3으로 이루어진 출력물을 세번에 걸쳐 출력함
            {
                gameData.PrintSqaure(numberOfLine,stateOfSquare);
            }
            Console.WriteLine("");
            Console.WriteLine("프로그램을 종료하거나 뒤(메뉴)로 돌아가고 싶으면 10을 입력하세요.");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
        public void ManageListAndResult()
        {
            indexOfSquare.Remove(selectedNumber - 1);//영역 선택 시 별도의 정수형 리스트에서 선택한 원소 삭제=>영역 탐색 편의를 위해

            stateOfSquare[selectedNumber - 1] = inputToSquare;//문자열 리스트의 인덱스와 틱택토 출력 인덱스가 1씩 차이나므로 입력 숫자에 -1하여 문자 대입

            gameResult = gameUtility.CheckResult(stateOfSquare);//게임의 결과 판단. 0이면 두번째 순서 승리,1이면 첫번째 순서 승리,계속 진행한다면 3 
            if (gameCount >= 9 && gameResult == Constant.KEEPGOING)//게임 횟수가 9번째인데 계속 진행하려 한다면 무승부로 판별
            {
                gameResult = 2;//무승부일때 2로 설정
            }
        }
        public void ShowResult(int firstCondition, int secondCondition, string firstName, string secondName)
        {//게임 결과를 보여주는 메소드
            if (gameResult == firstCondition)
            {//게임 결과가 유저 순서와 일치할 때
                Console.WriteLine(firstName + " 승리!");
                if (firstName == "User")
                    gameData.userWin++;
                else
                    gameData.firstPlayerWin++;
            }
            else if (gameResult == secondCondition)
            {// 게임 결과가 컴퓨터 순서와 일치할 때              
                Console.WriteLine(secondName + " 승리!");
                if (secondName == "Computer")
                    gameData.computerWin++;
                else
                    gameData.secondPlayerWin++;
            }
            else
            {//무승부일 때, 승리횟수 변화없음
                Console.WriteLine("무승부 입니다!");
                if (firstName == "User")
                    gameData.drawVersusComputer++;
                else
                    gameData.drawVersusPlayer++;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
    }
}
