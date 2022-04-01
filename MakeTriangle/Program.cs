using System;

namespace MakeTriangle
{
    class Star //별찍기 클래스 생성
    {
        private string UserInsert; //ReadLine 문자열을 입력받기 위한 문자열 생성
        private int MenuNum; //선택한 메뉴를 저장 할 int변수 생성
        private int StarNum; //별찍기 층 수를 저장 할 int변수 생성
        public Star()//생성자
        {
        }
        public void Start()//프로그램 시작 메소드
        {
            ShowMenu();
            SelectMenu();
        }
        private void ShowMenu()//프로그램 내에서 실행 가능한 메뉴 출력
        {
            Console.WriteLine("메뉴");
            Console.WriteLine("1.정삼각형 별찍기");
            Console.WriteLine("2.역삼각형 별찍기");
            Console.WriteLine("3.모래시계 별찍기");
            Console.WriteLine("4.다이아몬드 별찍기");
            Console.WriteLine("5.프로그램 종료");
            Console.WriteLine("------------------------------------------------------------");
        }
        private void SelectMenu()//메뉴를 선택하는 메소드
        {
            Console.Write("메뉴 번호를 입력하세요:");
            UserInsert = Console.ReadLine();
            Console.WriteLine("------------------------------------------------------------");

            //메뉴 선택에 대한 예외처리
            if (int.TryParse(UserInsert, out MenuNum))//숫자를 입력 했을 시
            {
                //메뉴 범위 외의 숫자 입력 시 예외 처리
                if (MenuNum < 1 || MenuNum > 5)
                {
                    Console.WriteLine("범위 내의 숫자를 선택 해주세요!");
                }
                //5번 입력 시 프로그램 종료
                else if (MenuNum == 5)
                {
                    return;
                }
                //1~4 사이의 숫자 입력 시 별찍기 수행
                else
                {
                    Console.Write("삼각형의 층 수를 입력하세요:");
                    UserInsert = Console.ReadLine();
                    Console.WriteLine("------------------------------------------------------------");

                    //층 수 입력에 대한 예외처리
                    while (!int.TryParse(UserInsert, out StarNum) || StarNum <= 0)
                    {
                        //문자열 입력 시
                        if (!int.TryParse(UserInsert, out StarNum))
                        {
                            Console.WriteLine("숫자를 입력 해주세요!");
                            Console.WriteLine("------------------------------------------------------------");
                        }
                        //음수 입력 시
                        else
                        {
                            Console.WriteLine("양수를 입력 해주세요!");
                            Console.WriteLine("------------------------------------------------------------");
                        }
                        //층 수 다시 입력
                        Console.Write("삼각형의 층 수를 입력하세요:");
                        UserInsert = Console.ReadLine();
                        Console.WriteLine("------------------------------------------------------------");
                    }
                    //별찍기 과정 수행
                    if (MenuNum == 1)
                    {
                        Menu1();
                    }
                    else if (MenuNum == 2)
                    {
                        Menu2();
                    }
                    else if (MenuNum == 3)
                    {
                        Menu2();
                        Menu1();
                    }
                    else if (MenuNum == 4)
                    {
                        Menu1();
                        Menu2();
                    }
                }
            }
            //메뉴 선택에서 문자를 입력 했을 시
            else
            {
                Console.WriteLine("숫자를 입력 해주세요!");
            }
            Console.WriteLine("------------------------------------------------------------");
            SelectMenu();
        }

        private void Menu1()//정삼각형 별찍기
        {
            for (int i = 0; i < StarNum; i++)
            {
                for (int j = 0; j < StarNum - 1 - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < i * 2 + 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        private void Menu2()//역삼각형 별찍기
        {
            for (int i = StarNum - 1; i >= 0; i--)
            {
                for (int j = 0; j < StarNum - 1 - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < i * 2 + 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Star star = new Star();
            star.Start();
        }
    }
}
