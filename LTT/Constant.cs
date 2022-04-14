using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    class Constant
    {
        //로그인
        public const int LOGIN_ID_INDEX = 0;
        public const int LOGIN_PASSWORD_INDEX = 1;
        public const int LOGIN_INDEX = 74;
        public const bool IS_CORRECT = false;
        public const bool IS_NOT_CORRECT = true;
        public const string ID = "18011514";
        public const string PASSWORD = "11111";
        public const int RETRY = 0;
        public const int EXIT = 1;
        public const string LOGIN_SUCESS = "!!!!!!!!!!!!!!";
        public const string LOGIN_FAIL = "############";
        
        //입력
        public const int NOMARL_INPUT = 0;
        public const int HIDE_INPUT = 1;
        public const int UP = -1;
        public const int DOWN = 1;
        public const int RETURN = -1;
        public const int ESCAPE_INT = -2;
        public const string ESCAPE_STRING = "@@@@@@@@@@@@@@@@@@@@";
        public const int INDEX_MINIMUM = 0;

        public enum SECTOR
        {
            SEQUENCE=1,
            MAJOR,
            LECTURE_NUMBER,
            DIVISION,
            LECTURE_NAME,
            DISTRIBUTION,
            COURSE,
            GRADE,
            DAY_AND_TIME,
            PLACE,
            PROFESSOR,
            LANGUAGE,

            MAJOR_INDEX = 4,
            LECTURE_NUMBER_INDEX = 24,
            DIVISION_INDEX = 33,
            LECTURE_NAME_INDEX = 38,
            DISTRIBUTION_INDEX=71,
            COURSE_INDEX=84,
            GRADE_INDEX=89,
            DAY_AND_TIME_INDEX=94,
            PLACE_INDEX=125,
            PROFESSOR_INDEX=139,
            LANGUAGE_INDEX=166,

        }
    }
}
