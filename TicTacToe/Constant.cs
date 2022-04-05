using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Constant
    {
        //exception 관리
        public const bool ISEXCEPTION = true;

        //행렬 인덱스 관리
        public const int LEFTINDEX = -1;//좌측 영역 인덱스 관리
        public const int RIGHTINDEX = 1;//우측 영역 인덱스 관리
        public const int UPINDEX = -3;//상단 영역 인덱스 관리
        public const int DOWNINDEX = 3;

        //게임 관리
        public const int FIRSTPLAYER = 1;
        public const int SECONDPLAYER = 0;
        public const int KEEPGOING = 3;
        public const int GOBACK = 10;
    }
}
