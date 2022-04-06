using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class MenuSelection//게임 시작 및 게임 내 여러 기능을 관리하는 클래스
    {
        public View gameData = new View();
        public Utility gameUtility = new Utility();
        PlayingWithUser firstMenu = new PlayingWithUser();
        PlayingWithComputer secondMenu = new PlayingWithComputer();

        public MenuSelection()
        {
            firstMenu.Init(gameData, gameUtility);
            secondMenu.Init(gameData, gameUtility);
        }


        public void Start()//게임 시작 메소드
        {
            int seletedNumber;
            bool isStart = true;
            gameData.ShowLabel();//레이블과 메뉴 출력
            gameData.ShowMenu();
            while (isStart)
            {
                seletedNumber = gameUtility.SelectNumber(4);//메뉴 선택
                switch (seletedNumber)
                {
                    case 1://1번 선택 시 Player간 대결
                        Console.Clear();
                        firstMenu.PlayGame();
                        break;
                    case 2:
                        Console.Clear();
                        secondMenu.PlayGame();
                        break;
                    case 3://3번 선택 시 스코어보드 출력
                        ShowScore();
                        break;
                    case 4:
                        gameData.ShowRule();
                        break;
                    case 5://4번 선택 시 종료한번 더 물어보기
                        ConfirmExit();
                        break;
                }
                if(seletedNumber!=5)
                    AfterMethod();//게임이 끝난 후 메뉴로 돌아갈지 종료할지 물어본다.
                Reset();
            }
            
        }
        private void Reset()//메뉴 선택 창 다시 보여주기
        {
            Console.Clear();
            gameData.ShowLabel();
            gameData.ShowMenu();
        }

        private void ShowScore()//스코어보드를 보여주는 함수
        {
            Console.Clear();
            gameData.ShowLabel();//레이블과 스코어 결과를 보여준다.
            gameData.ScoreBoard();
            
        }


        private void AfterMethod()//게임을 하거나 스코어보드를 출력하고 나서 마지막에 진행여부를 물어보는 메소드
        {
            Console.Write("게임을 종료하고 싶으면 1, 메뉴로 돌아가고 싶으면 2를 입력해 주세요:");
            if (gameUtility.SelectNumber(2) == 1)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                ConfirmExit();//종료할지 한번 더 확인
            }

        }


        private void ConfirmExit()//종료확인 메소드
        {
            int selectedNumber;
            Console.Write("정말 종료하시겠습니까?  맞으면 1, 아니면 2를 입력해 주세요: ");
            selectedNumber = gameUtility.SelectNumber(2);//1과2중 하나를 입력받는다.
            Console.WriteLine("----------------------------------------------------------------------------------------");
            if (selectedNumber == 1)//프로그램 종료
            {
                Console.WriteLine("프로그램을 종료합니다.");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Environment.Exit(0);
            }
        }
        
    }
}
