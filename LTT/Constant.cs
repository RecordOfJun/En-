using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LTT
{
    class Constant
    {
        public const int SEARCH_LEFT = 30;
        //로그인
        public const int LOGIN_ID_INDEX = 13;
        public const int LOGIN_PASSWORD_INDEX = 14;
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
        public const string EMPTY = "";
        public const int EXIT_PROGRAM = 1;
        public const int PASSWORD_TYPE = 1;
        public const int NOT_PASSWORD_TYPE = 2;
        public const int STRING_INPUT_LENGTH = 10;
        public const int JUST_SEARCH_TYPE = 1;
        public const int CONTROLL_SEARCH_TYPE = 2;

        //커서
        public const int MIDDLE_CUSOR = 70;
        public const int EXIT_CUSOR = 83;
        public const int ESC_CUSOR = 140;
        public const int LOGIN_GUIDE_CUSOR = 30;
        public const int CAN_INSERT_CUSOR = 0;
        public const int INSERT_CUSOR = 20;
        public const int NUMBER_INSERT_CUSOR = 34;
        public const int GRADES_CUSOR = 25;
        public const int SHOW_LECTURE_CUSOR = 26;
        public const int COLUMN_PRINT_CUSOR = 50;
        public const int COLUMN_SECOND_CUSOR = 63;
        public const int COLUMN_THIRD_CUSOR = 80;
        public const int COLUMN_FOURTH_CUSOR = 99;
        public const int COLUMN_FIFTH_CUSOR = 117;
        public const int DIVISION_FIRST_CUSOR = 64;
        public const int DIVISION_SECOND_CUSOR = 94;
        public const int PROFESSOR_CUSOR = 62;
        public const int LECTURENAME_CUSOR = 64;
        public const int LECTURENUMBER_INSERT_CUSOR = 42;


        //인덱스
        public const int EXCEL_MINIMUM_ROW = 1;
        public const int EXCEL_MAXIMUM_ROW = 185;
        public const int EXCEL_MINIMUM_COLUMN = 1;
        public const int EXCEL_MAXIMUM_COLUMN = 12;
        public const int MAIN_MENU_COUNT = 5;
        public const int INTEREST_MENU_COUNT = 5;
        public const int SEARCH_MENU_COUNT = 6;
        public const int INTEREST_MAX = 24;
        public const int MY_MAX = 21;
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
        public enum MenuCursor
        {
            FIRST_MENU_CUSOR=13,
            SECOND_MENU_CUSOR=15,
            THIRD_MENU_CUSOR=17,
            FOURTH_MENU_CUSOR=19,
            FIFTH_MENU_CUSOR=21,
            SIXTH_MENU_CUSOR=23
        }
        public enum Menu
        {
            FIRST_MENU = 0,
            SECOND_MENU,
            THIRD_MENU,
            FOURTH_MENU,
            FIFTH_MENU,
            SIXTH_MENU
        }

        //delete length
        public const int ID_DELETE = 16;
        public const int CUSOR_DELETE = 1;
        public const int RETRY_DELETE = 28;
        public const int COLUMN_DELETE = 100;
        public const int DELETE_LONG = 150;

        //exception cursor
        public const int NUMBER_EXCEPTION = 48;
        public const int NUMBER_EXCEPTION_LENGTH = 20;
        public const int ID_EXCEPTION = 90;
        public const int ID_EXCEPTION_LENGTH = 25;
        public const int EXIST_EXCEPTION_LENGTH = 32;
        public const int TIME_EXCEPTION_LENGTH = 35;
        public const int LECTRUENUMBER_EXCEPTION = 100;
        public const int DIVISION_EXCEPTION_LENGTH = 26;
        public const int PROFESSOR_EXCEPTION = 82;
        public const int PROFESSOR_EXCEPTION_LENGTH = 40;

        //TIME TABLE
        public const int MINIMUM_ROW = 0;
        public const int MAXIMUM_ROW = 48;
        public const int MINIMUM_COLUMN = 0;
        public const int MAXIMUM_COLUMN = 8;
        public const int MONDAY_COLUMN = 3;
    }
}
