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
                    case 2:
                        Console.Clear();
                        PlayWithComputer();//2번 선택 시 컴퓨터와 대결
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
                gameData.indexOfSquare = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
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

                selectedNumber = CheckSelected(selectedNumber);

                gameData.indexOfSquare.Remove(selectedNumber - 1);
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

        private void PlayWithComputer()
        {
            int keepGoing = 3;//틱택토 진행판단 변수
            int gameCount = 0;//게임 진행 횟수 판단 변수
            int userSequence;//유저의 순서를 저장하는 변수
            int computerSequence;//컴퓨터의 순서를 저장하는 변수
            int selectedNumber;//사용자의 입력을 선택하는 변수
            string inputToSquare;//틱택토 표기할 문자를 넣을 변수
            string[] strSequence = { "O", "X" };//순서에 따른 선택시 표기 배열
            int gameResult = gameUtility.CheckResult(gameData.stateOfSquare);//게임의 결과를 판단할 변수

            Console.Write("당신의 순서를 선택해 주세요! 첫번째로 하고싶으면 1, 두번째로 하고싶으면 2를 입력해 주세요:");


            //첫번째를 시작하면 1저장,두번째를 선택하면 0 저장
            userSequence = SelectNumber(1, 2) % 2;//사용자의 순서 저장
            computerSequence = (userSequence + 1) % 2;//컴퓨터의 순서 저장


            while (gameResult == keepGoing)//게임 결과가 계속해서 진행일 때
            {
                gameCount++;//진행 횟수 증가
                Console.Clear();
                ShowTicTacToe();//틱택토 현황 보여주기
                if (gameCount % 2 == userSequence)//유저차례 일 때
                {
                    Console.Write("당신의  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = strSequence[userSequence];//유저 선택 시 틱택토에 표기할 문자 설정
                    selectedNumber = SelectNumber(1, 9);//선택할 틱택토 영역을 입력받기
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    selectedNumber = CheckSelected(selectedNumber);//이미 선택되었는지 확인
                }
                else//computer차례
                {
                    inputToSquare = strSequence[computerSequence];//컴퓨터가 선택 시 표기할 문자 설정
                    selectedNumber = ComputerChoice(inputToSquare, strSequence[userSequence], computerSequence)+1;//컴퓨터의 영역 선택 메소드
                }

                gameData.indexOfSquare.Remove(selectedNumber - 1);//컴퓨터 영역 선택 메소드 활용을 위한 정수형 인덱스 리스트에서 원소값 제거

                gameData.stateOfSquare[selectedNumber - 1] = inputToSquare;//문자열 리스트의 인덱스와 틱택토 출력 인덱스가 1씩 차이나므로 입력 숫자에 -1하여 문자 대입
                
                gameResult = gameUtility.CheckResult(gameData.stateOfSquare);//게임의 결과 판단. 0이면 두번째 순서 승리,1이면 첫번째 순서 승리,계속 진행한다면 3 
                if (gameCount >= 9 && gameResult == keepGoing)//게임 횟수가 9번째인데 계속 진행하려 한다면 무승부로 판별
                {
                    gameResult = 2;//무승부일때 2로 설정
                }
            }
            Console.Clear();
            ShowTicTacToe();

            if (gameResult == userSequence)
            {//게임 결과가 유저 순서와 일치할 때
                Console.WriteLine("User 승리!");
                gameData.userWin++;
            }
            else if (gameResult == computerSequence)
            {// 게임 결과가 컴퓨터 순서와 일치할 때              
                Console.WriteLine("Computer 승리!");
                gameData.computerWin++;
            }
            else//무승부일 때, 승리횟수 변화없음
                Console.WriteLine("무승부 입니다!");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            AfterMethod();//게임이 끝난 후 메뉴로 돌아갈지 종료할지 물어본다.
        }
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

        private int CheckSelected(int selectedNumber)
        {
            while (!(gameData.indexOfSquare.Exists(element=> element==selectedNumber-1)))//이미 선택된 영역에 대해 예외처리
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("이미 선택된 영역입니다! 다시 선택해 주세요!:");
                Console.ForegroundColor = ConsoleColor.White;
                selectedNumber = SelectNumber(1, 9);//선택되지 않았을때까지 계속 선택
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            return selectedNumber;
        }

        private int ComputerChoice(string computerString,string userString ,int squenceOfComputer)
        {
            int userSequence = (squenceOfComputer + 1) % 2;
            //case1 놓으면 게임 끝날 때
            foreach (int index in gameData.indexOfSquare)
            {
                gameData.stateOfSquare[index] = computerString;
                if (gameUtility.CheckResult(gameData.stateOfSquare) == squenceOfComputer)
                {
                    gameData.stateOfSquare[index] = (index + 1).ToString();
                    return index;
                }
                gameData.stateOfSquare[index] = (index + 1).ToString();
            }
            //case2 놓으면 상대방의 승리를 막을 때
            foreach (int index in gameData.indexOfSquare)
            {
                gameData.stateOfSquare[index] = userString;
                if (gameUtility.CheckResult(gameData.stateOfSquare) == userSequence)
                {
                    gameData.stateOfSquare[index] = (index + 1).ToString();
                    return index;
                }
                gameData.stateOfSquare[index] = (index + 1).ToString();
            }
            //case3 2목 2줄을 만들 수 있을 때
            foreach (int index in gameData.indexOfSquare)
            {
                int row = index / 3;//행 검사를 위한 정수
                int column = index;
                bool rowExisted = false;
                bool columnExisted = false;
                bool otherExisted = false;
                for(int count = 0; count < 3; count++)
                {
                    int rowSequence = row * 3 + count;
                    if (gameData.stateOfSquare[rowSequence] == computerString)
                        rowExisted = true;
                    else if (gameData.stateOfSquare[rowSequence] == userString)
                        otherExisted = true;
                }
                for(int count = 0; count < 3; count++)
                {
                    column = (column + 3) % 9;//열을 검사하기위한 변수
                    if (gameData.stateOfSquare[column] == computerString)
                        columnExisted = true;
                    else if (gameData.stateOfSquare[column] == userString)
                        otherExisted = true;
                }
                if (rowExisted == true && columnExisted == true && otherExisted == false)          
                    return index;
            }
            //case4 상대방의 2목 2줄을 막을 때
            foreach (int index in gameData.indexOfSquare)
            {
                int row = index / 3;//행 검사를 위한 정수
                int column = index;
                bool rowExisted = false;
                bool columnExisted = false;
                bool otherExisted = false;
                for (int count = 0; count < 3; count++)
                {
                    int rowSequence = row * 3 + count;
                    if (gameData.stateOfSquare[rowSequence] == userString)
                        rowExisted = true;
                    else if (gameData.stateOfSquare[rowSequence] == computerString)
                        otherExisted = true;
                }
                for (int count = 0; count < 3; count++)
                {
                    column = (column + 3) % 9;//열을 검사하기위한 변수
                    if (gameData.stateOfSquare[column] == userString)
                        columnExisted = true;
                    else if (gameData.stateOfSquare[column] == computerString)
                        otherExisted = true;
                }
                if (rowExisted == true && columnExisted == true && otherExisted == false)              
                    return index;
            }
            //case5 모서리에 이미 돌이 있다면 반대편 모서리에 두기
            for(int startIndex = 0; startIndex < 9; startIndex += 2)
            {
                if (startIndex == 4)
                {

                }
                else
                {
                    int oppositIndex = 8 - startIndex;//반대편 모서리 인덱스
                    if(gameData.stateOfSquare[startIndex]==(startIndex+1).ToString()&&gameData.stateOfSquare[oppositIndex]== computerString)
                    {
                        return startIndex;
                    }
                }
            }
            //case6 중간에 두기
            if (gameData.stateOfSquare[4] == "5")
                return 4;
            //case7 구석에 두기
            for (int startIndex = 0; startIndex < 9; startIndex += 2)
            {
                if (gameData.stateOfSquare[startIndex] == (startIndex + 1).ToString())
                    return startIndex;
            }
            return gameData.indexOfSquare[0];
        }
    }
}
