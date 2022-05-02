using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Constant
    {
        //MenuSelection
        public const int UP = -1;
        public const int DOWN = 1;

        public const int FIRST_MENU = 0;
        public const int SECOND_MENU = 1;
        public const int THIRD_MENU = 2;
        public const int FOURTH_MENU = 3;
        public const int FIFTH_MENU = 4;
        public const int SIXTH_MENU = 5;
        public const int INDEX_MINIMUM = 0;
        public const int MAIN_MENU_LENGTH = 4;
        public const int USER_MENU_LENGTH = 5;
        public const int ADMIN_MENU_LENGTH = 3;

        //Cursor
        public const int ADD_INDEX = 1;
        public const int ID_ADD_INDEX = 20;
        public const int NEXT_INDEX = 2;
        public const int PASSWORD_ADD_INDEX = 22;
        public const int PASSWORD_CONFIRM_INDEX = 24;
        public const int NAME_ADD_INDEX = 26;
        public const int PERSONAL_ADD_INDEX = 28;
        public const int PHONE_ADD_INDEX = 30;
        public const int ADDRESS_ADD_INDEX = 32;
        public const int LEFT = -1;
        public const int ID_LOGIN_INDEX = 15;
        public const int PASSWORD_LOGIN_INDEX = 17;
        public const int SEARCH_INDEX = 20;
        public const int CODE_INDEX = 26;
        public const int QUANTITY_INDEX = 28;
        public const int WIDTH = 40;
        public const int FIRST_MENU_INDEX = 15;
        public const int SECOND_MENU_INDEX = 16;
        public const int THIRD_MENU_INDEX =17;
        public const int FOURTH_MENU_INDEX = 18;
        public const int FIFTH_MENU_INDEX = 19;
        public const int DISTANCE_OF_INDEX = 1;

        public const int ARROW_INDEX = 31;

        //Exeption
        public const bool IS_EXCEPTION = false;
        public const bool IS_HAVE = true;
        public const int TWO_SECOND = 2000;
        public const string EMPTY = "";
        public const int KOREAN_FIRST = 0xAC00;
        public const int KOREAN_SECOND = 0xD7A3;
        public const int KOREAN_THIRD = 0x3131;
        public const int KOREAN_FOURTH = 0x318E;
        public const int NUMBER_START = 0x30;
        public const int NUMBER_END = 0x39;
        
        public const int ID_PASSWORD_MINIMUM_LENGTH = 6;
        public const int ID_LENGTH = 10;
        public const int PASSWORD_LENGTH = 12;
        public const int NAME_LENGTH = 4;
        public const int PERSONAL_LENGTH = 13;
        public const int PHONE_LENGTH = 11;
        public const string ESCAPE = "0000000000000000000000000000000";
        public const int BOOK_ID_LENGTH = 8;
        public const int BOOK_STRING_LENGTH = 20;
        public const int BOOK_PRICE_LENGTH = 6;
        public const int BOOK_QUANTITY_LENGTH = 2;
        public const int MEMBER_NAME_LENGTH = 4;
        public const int MEMBER_PERSONALCODE_LENGTH = 13;

        //if-else,switch
        public const int CONFRIM_LOGIN = 1;
        public const int CONFRIM_ADD = 1;
        public const int CONFIRM_REVISE = 2;
        public const int QUIT = -2;
        public const int RETURN = -1;
        public const int MONTH_INDEX = 2;
        public const int DAY_INDEX = 4;
        public const int GENDER_INDEX = 6;
        public const int MONTH_LENGTH = 12;
        public const int DAY_LENGTH = 31;
        public const int GENDER_FIRST = 1;
        public const int GENDER_LAST = 4;
        public const int BOOK_BORROW = 1;
        public const int BOOK_RETURN = 2;
        public const int BOOK_DELETE = 3;
        public const int BOOK_REVISE = 4;
        public const int MEMBER_REVISE = 1;
        public const int MEMBER_DELETE = 2;
        public const int MEMBER_SEARCH = 4;
        public const int SIGN_UP=1;
        public const int REVISE_MEMBER = 2;
        public const int SEARCH_BOOK = 5;
        public const int USER_BOOK = 1;
        public const int ADMIN_BOOK = 2;
        public const int NAVER_SEARCH = 3;

        //ADMIN
        public const string ADMIN_ID = "1111111111";
        public const string ADMIN_PASSWORD = "9999999999";

        //char
        public const char ERASE = ' ';
        public const char ARROW = '>';

        public enum Menu
        {
            FIRST_MENU = 0,
            SECOND_MENU,
            THIRD_MENU,
            FOURTH_MENU,
            FIFTH_MENU,
            SIXTH_MENU,
            SEVENTH_MENU,
            EIGHTH_MENU,
            NINETH_MENU
        }
        public enum MenuCursor
        {
            FIRST_MENU_CUSOR = 15,
            SECOND_MENU_CUSOR ,
            THIRD_MENU_CUSOR ,
            FOURTH_MENU_CUSOR ,
            FIFTH_MENU_CUSOR ,
            SIXTH_MENU_CUSOR 
        }
        public enum SectorCursor
        {
            FIRST_SECTOR_CURSOR = 19,
            SECOND_SECTOR_CURSOR=21,
            THIRD_SECTOR_CURSOR=23,
            FOURTH_SECTOR_CURSOR=25,
            FIFTH_SECTOR_CURSOR = 27,
            SIXTH_SECTOR_CURSOR = 29,
            SEVENTH_SECTOR_CURSOR = 31,
            EIGHTH_SECTOR_CURSOR = 33,
            NINETH_SECTOR_CURSOR = 35,
            BOOK_CODE_CURSOR = 29,
            BOOK_QUANTITY_CURSOR = 31,
        }
        public enum MemberSearch
        {
            ID=1,
            NAME,
            PHONE,
            QUERY,
            DISPLAY
        }
        public const int MIDDLE_CURSOR = 31;
        public const int ESCAPE_INT = -2;
        public const string ESCAPE_STRING = "@@@@@@@@@@@@@@@@@@@@";
        public const int HIDE_INPUT = 1;
        public const int SEARCH_LEFT = 0;
        public const int COLUMN_PRINT_CURSOR = 20;
        public const int COLUMN_DELETE = 50;
        public const int PASSWORD_TYPE = 1;
        public const int NOT_PASSWORD_TYPE = 2;
        public const int DATA_INSERT_CURSOR = 27;
        public const string UP_ARROW = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
        public const int SEARCH_TYPE = 1;
        public const int INSERT_TYPE = 2;
        public const int DELETE_BOOK = 1;
        public const int DELETE_BORROW = 2;

        //db connection and query
        public const string SERVER_DATA = "Server=localhost;Port=3306;Database=hyungjune;Uid=root;Pwd=0000";
        public const string INSERT_MEMBER = "Insert into member (id,password,name,personalcode,phone,adress) values ( '";
        public const string SELECT_ADMIN = "SELECT id,password from member where name = 'Adm';";
        public const string BORROW_COUNT = "SELECT COUNT(*) FROM borrowed where bookid=";
        public const string SELECT_BORROW = "SELECT book.*,B.borrowtime,B.returntime from book,( select * from borrowed where membercode=";
        
        //LOG
    }
}
