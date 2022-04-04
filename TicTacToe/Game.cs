using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game//게임 시작 및 게임 내 여러 기능을 관리하는 클래스
    {
        Data gameData = new Data();
        Utility gameUtility = new Utility();


        public Game()
        {
        }


        public void Start()//게임 시작 메소드
        {
            int seletedNumber;
            bool isStart = true;
            gameData.ShowLabel();//레이블과 메뉴 출력
            gameData.ShowMenu();
            while (isStart)
            {
                seletedNumber = SelectNumber(1, 4);//메뉴 선택
                switch (seletedNumber)
                {
                    case 1://1번 선택 시 Player간 대결
                        PlayWithUser();
                        break;
                    case 2://2번 선택 시 컴퓨터와 대결
                        break;
                    case 3://3번 선택 시 스코어보드 출력
                        ShowScore();
                        break;
                    case 4://4번 선택 시 종료한번 더 물어보기
                        ConfirmExit();
                        break;
                }
                Reset();
            }
            
        }
        private void Reset()//메뉴 선택 창 다시 보여주기
        {
            Console.Clear();
            gameData.ShowLabel();
            gameData.ShowMenu();
            for(int index= 0; index < 9; index++)//틱택토 리스트 초기화
            {
                gameData.stateOfSquare[index] = (index + 1).ToString();
            }
        }


        private int SelectNumber(int startNumber, int endNumber)// 정해진 숫자 범위를 인자로 받는 사용자 입력받기 메소드
        {
            string userInput;
            bool isException = false;//예외발생 판단 변수
            userInput = Console.ReadLine();
            while (gameUtility.IsParseException(userInput, startNumber, endNumber) == isException)//예외 발생하는 동안 계속해서 새로 입력 받기
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("다시 입력해 주세요!:");
                userInput = Console.ReadLine();
            }
            return int.Parse(userInput);//예외가 없을 경우 사용자가 입력한 숫자를 리턴
        }


        private void PlayWithUser()//플레이어간 틱택토 대결 메소드
        {
            int keepGoing = 3;//틱택토 진행판단 변수
            int gameCount = 0;//게임 진행 횟수 판단 변수
            int firstPlayer = 1;
            int selectedNumber;
            string inputToSquare;//틱택토 리스트에 넣을 문자를 설정할 변수
            int gameResult = gameUtility.CheckResult(gameData.stateOfSquare);//게임의 결과를 판단할 변수
            while (gameResult == keepGoing)//게임 결과가 계속해서 진행일 때
            {
                gameCount++;//진행 횟수 증가
                Console.Clear();
                ShowTicTacToe();
                if (gameCount % 2 == firstPlayer)//진행 횟수를 2로 나눈 나머지가 1이면 player1찰{
                {
                    Console.Write("Player1  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = "X";//리스트에 X를 넣어준다.
                }
                else//0이면 player 2차례
                {
                    Console.Write("Player2  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = "O";//리스트에 O를 넣어준다
                }
                selectedNumber = SelectNumber(1, 9);//선택할 틱택토 영역을 입력받기
                Console.WriteLine("----------------------------------------------------------------------------------------");

                selectedNumber = CheckSelected(selectedNumber, gameData.stateOfSquare[selectedNumber - 1]);

                gameData.stateOfSquare[selectedNumber - 1] = inputToSquare;//리스트의 인덱스와 틱택토 출력 인덱스가 1씩 차이나므로 입력 숫자에 -1하여 문자 대입
                gameResult = gameUtility.CheckResult(gameData.stateOfSquare);
                if (gameCount >= 9 && gameResult == keepGoing)//게임 횟수가 9번째인데 계속 진행하려 한다면 무승부로 판별
                {
                    gameResult = 2;
                }
            }
            Console.Clear();
            ShowTicTacToe();
            if (gameResult == 1) {//게임 결과가 1일 때 플레이어1의 승리, 승리횟수 +1
                Console.WriteLine("Player1 승리!");
                gameData.firstPlayerWin++;
            }
            else if (gameResult == 0)//게임 결과가 0일 때 플레이어2의 승리, 승리횟수 +1
            {
                Console.WriteLine("Player2 승리!");
                gameData.secondPlayerWin++;
            }
            else//무승부일 때, 승리횟수 변화없음
                Console.WriteLine("무승부 입니다!");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            AfterMethod();//게임이 끝난 후 메뉴로 돌아갈지 종료할지 물어본다.
        }

        /*private void PlayWithComputer()
        {
            int keepGoing = 3;//틱택토 진행판단 변수
            int gameCount = 0;//게임 진행 횟수 판단 변수
            int userSequence;
            int selectedNumber;
            string inputToSquare;//틱택토 리스트에 넣을 문자를 설정할 변수
            string[] strSequence = { "O", "X" };
            int gameResult = gameUtility.CheckResult(gameData.stateOfSquare);//게임의 결과를 판단할 변수

            Console.Write("당신의 순서를 선택해 주세요! 첫번째로 하고싶으면 1, 두번째로 하고싶으면 2를 입력해 주세요:");
            userSequence = SelectNumber(1, 2) % 2;
            
            while (gameResult == keepGoing)//게임 결과가 계속해서 진행일 때
            {
                gameCount++;//진행 횟수 증가
                Console.Clear();
                ShowTicTacToe();
                if (gameCount % 2 == userSequence)//유저차례
                {
                    Console.Write("당신의  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = strSequence[userSequence];
                    selectedNumber = SelectNumber(1, 9);//선택할 틱택토 영역을 입력받기
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    selectedNumber = CheckSelected(selectedNumber, gameData.stateOfSquare[selectedNumber - 1]);
                }
                else//computer
                {
                    inputToSquare = strSequence[gameCount % 2];
                    selectedNumber=//컴퓨터 선택 메소드
                }

                gameData.indexOfSquare.Remove(selectedNumber - 1);
                gameData.stateOfSquare[selectedNumber - 1] = inputToSquare;//리스트의 인덱스와 틱택토 출력 인덱스가 1씩 차이나므로 입력 숫자에 -1하여 문자 대입
                gameResult = gameUtility.CheckResult(gameData.stateOfSquare);
                if (gameCount >= 9 && gameResult == keepGoing)//게임 횟수가 9번째인데 계속 진행하려 한다면 무승부로 판별
                {
                    gameResult = 0;
                }
            }
            Console.Clear();
            ShowTicTacToe();
            if (gameResult == userSequence)
            {//게임 결과가 1일 때 플레이어1의 승리, 승리횟수 +1
                Console.WriteLine("Player1 승리!");
                gameData.firstPlayerWin++;
            }
            else if (gameResult == 2)//게임 결과가 2일 때 플레이어2의 승리, 승리횟수 +1
            {
                Console.WriteLine("Player2 승리!");
                gameData.secondPlayerWin++;
            }
            else//무승부일 때, 승리횟수 변화없음
                Console.WriteLine("무승부 입니다!");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            AfterMethod();//게임이 끝난 후 메뉴로 돌아갈지 종료할지 물어본다.
        }
        */
        private void ShowScore()//스코어보드를 보여주는 함수
        {
            Console.Clear();
            gameData.ShowLabel();//레이블과 스코어 결과를 보여준다.
            gameData.ScoreBoard();
            AfterMethod();//스코어보드 출력 후 종료할지 메뉴로 돌아갈지 물어본다.
        }


        private void AfterMethod()//게임을 하거나 스코어보드를 출력하고 나서 마지막에 진행여부를 물어보는 메소드
        {
            Console.Write("게임을 종료하고 싶으면 1, 메뉴로 돌아가고 싶으면 2를 입력해 주세요:");
            if (SelectNumber(1, 2) == 1)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                ConfirmExit();//종료할지 한번 더 확인
            }

        }


        private void ConfirmExit()//종료확인 메소드
        {
            int selectedNumber;
            Console.Write("정말 종료하시겠습니까?  맞으면 1, 아니면 2를 입력해 주세요: ");
            selectedNumber = SelectNumber(1, 2);//1과2중 하나를 입력받는다.
            Console.WriteLine("----------------------------------------------------------------------------------------");
            if (selectedNumber == 1)//프로그램 종료
            {
                Console.WriteLine("프로그램을 종료합니다.");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Environment.Exit(0);
            }
        }


        private void ShowTicTacToe()//3X3 틱택토 matrix출력 함수
        {
            int numberOfLine;
            int lastLine = 3;
            for(numberOfLine=0; numberOfLine < lastLine; numberOfLine++)//1x3으로 이루어진 출력물을 세번에 걸쳐 출력함
            {
                gameData.PrintSqaure(numberOfLine);
            }
        }

        private int CheckSelected(int selectedNumber, string stateOfSquare)
        {
            while (stateOfSquare == "O" || stateOfSquare == "X")//이미 선택된 영역에 대해 예외처리
            {
                Console.Write("이미 선택된 영역입니다! 다시 선택해 주세요!:");
                selectedNumber = SelectNumber(1, 9);
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            return selectedNumber;
        }

        /*private int ComputerChoice(string inputToSqaure,int )
        {
            foreach(int index in gameData.indexOfSquare)
            {
                gameData.stateOfSquare[index] = inputToSqaure;
                if(gameUtility.CheckResult(gameData.stateOfSquare)==)
            }
        }
        */
    }
}
