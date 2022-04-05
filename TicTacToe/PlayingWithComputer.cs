using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class PlayingWithComputer : PlayingWithUser
    {
        public PlayingWithComputer()
        {
        }
        
        public void PlayGame()//VS컴퓨터
        {
            int userSequence;//유저의 순서를 저장하는 변수
            int computerSequence;//컴퓨터의 순서를 저장하는 변수
            string[] strSequence = { "O", "X" };//순서에 따른 선택시 표기 배열
            gameResult = gameUtility.CheckResult(stateOfSquare);//게임의 결과를 판단할 변수
            Console.Write("당신의 순서를 선택해 주세요! 첫번째로 하고싶으면 1, 두번째로 하고싶으면 2를 입력해 주세요:");


            //첫번째를 시작하면 1저장,두번째를 선택하면 0 저장
            userSequence = gameUtility.SelectNumber(2) % 2;//사용자의 순서 저장
            computerSequence = (userSequence + 1) % 2;//컴퓨터의 순서 저장


            while (gameResult == Constant.KEEPGOING)//게임 결과가 계속해서 진행일 때
            {
                gameCount++;//진행 횟수 증가
                Console.Clear();
                ShowTicTacToe();//틱택토 현황 보여주기
                if (gameCount % 2 == userSequence)//유저차례 일 때
                {
                    Console.Write("당신의  차례입니다! 1~9 중에서 하나를 선택해 주세요:");
                    inputToSquare = strSequence[userSequence];//유저 선택 시 틱택토에 표기할 문자 설정
                    selectedNumber = gameUtility.SelectNumber(9);//선택할 틱택토 영역을 입력받기
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    selectedNumber = gameUtility.CheckSelected(selectedNumber, indexOfSquare);//이미 선택되었는지 확인
                }
                else//computer차례
                {
                    inputToSquare = strSequence[computerSequence];//컴퓨터가 선택 시 표기할 문자 설정
                    selectedNumber = ComputerChoice(inputToSquare, strSequence[userSequence], computerSequence) + 1;//컴퓨터의 영역 선택 메소드
                }

                ManageListAndResult();
            }
            Console.Clear();
            ShowTicTacToe();

            ShowResult( userSequence, computerSequence, "User", "Computer");

        }

        private int ComputerChoice(string computerString, string userString, int squenceOfComputer)//컴퓨터 영역선택 메소드
        {
            int userSequence = (squenceOfComputer + 1) % 2;
            //우선순위1 놓으면 게임 끝날 때
            foreach (int index in indexOfSquare)
            {
                stateOfSquare[index] = computerString;
                if (gameUtility.CheckResult(stateOfSquare) == squenceOfComputer)
                {
                    stateOfSquare[index] = (index + 1).ToString();
                    return index;
                }
                stateOfSquare[index] = (index + 1).ToString();
            }
            //우선순위2 놓으면 상대방의 승리를 막을 때
            foreach (int index in indexOfSquare)
            {
                stateOfSquare[index] = userString;
                if (gameUtility.CheckResult(stateOfSquare) == userSequence)
                {
                    stateOfSquare[index] = (index + 1).ToString();
                    return index;
                }
                stateOfSquare[index] = (index + 1).ToString();
            }
            //우선순위3 2목 2줄을 만들 수 있을 때
            foreach (int index in indexOfSquare)
            {
                int row = index / 3;//행 검사를 위한 정수
                int column = index;
                bool rowExisted = false;
                bool columnExisted = false;
                bool otherExisted = false;
                for (int count = 0; count < 3; count++)
                {
                    int rowSequence = row * 3 + count;
                    if (stateOfSquare[rowSequence] == computerString)
                        rowExisted = true;
                    else if (stateOfSquare[rowSequence] == userString)
                        otherExisted = true;
                }
                for (int count = 0; count < 3; count++)
                {
                    column = (column + 3) % 9;//열을 검사하기위한 변수
                    if (stateOfSquare[column] == computerString)
                        columnExisted = true;
                    else if (stateOfSquare[column] == userString)
                        otherExisted = true;
                }
                if (rowExisted == true && columnExisted == true && otherExisted == false)
                    return index;
            }
            //우선순위4 상대방의 2목 2줄을 막을 때
            foreach (int index in indexOfSquare)
            {
                int row = index / 3;//행 검사를 위한 정수
                int column = index;
                bool rowExisted = false;
                bool columnExisted = false;
                bool otherExisted = false;
                for (int count = 0; count < 3; count++)
                {
                    int rowSequence = row * 3 + count;
                    if (stateOfSquare[rowSequence] == userString)
                        rowExisted = true;
                    else if (stateOfSquare[rowSequence] == computerString)
                        otherExisted = true;
                }
                for (int count = 0; count < 3; count++)
                {
                    column = (column + 3) % 9;//열을 검사하기위한 변수
                    if (stateOfSquare[column] == userString)
                        columnExisted = true;
                    else if (stateOfSquare[column] == computerString)
                        otherExisted = true;
                }
                if (rowExisted == true && columnExisted == true && otherExisted == false)
                    return index;
            }
            //우선순위5 모서리에 이미 돌이 있다면 반대편 모서리에 두기
            for (int startIndex = 0; startIndex < 9; startIndex += 2)
            {
                if (startIndex != 4)
                {
                    int oppositIndex = 8 - startIndex;//반대편 모서리 인덱스
                    if (stateOfSquare[startIndex] == (startIndex + 1).ToString() && stateOfSquare[oppositIndex] == computerString)
                    {
                        return startIndex;
                    }
                }
            }
            //우선순위6 중간에 두기
            if (stateOfSquare[4] == "5")
                return 4;
            //우선순위7 모서리에 두기
            for (int startIndex = 0; startIndex < 9; startIndex += 2)
            {
                if (stateOfSquare[startIndex] == (startIndex + 1).ToString())
                    return startIndex;
            }
            //아무곳이나 두기
            return indexOfSquare[0];
        }
    }
}
