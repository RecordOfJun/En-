using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
namespace Library.View
{
    class MemberView
    {

        public void AddMemberForm()
        {
            Console.WriteLine("");
            Console.WriteLine("                     회원가입 후 도서 대여 및 반납이 가능합니다!                 ");
            Console.WriteLine("                   아래에 양식에 맞게 차례대로 정보를 입럭해 주세요!             ");
            Console.WriteLine(" 입력한 정보를 다시 입력하려면 방향키로 이동, 입력을 완료했으면 엔터를 눌러주세요!");
            Console.WriteLine("                           (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            InsetForm();

        }
        public void ReviseForm()
        {
            Console.WriteLine("");
            Console.WriteLine("               개인정보 수정은 비밀번호, 이름, 전화번호,주소 만 가능합니다!                 ");
            Console.WriteLine("                   아래에 양식에 맞게 차례대로 정보를 입럭해 주세요!             ");
            Console.WriteLine(" 입력한 정보를 다시 입력하려면 방향키로 이동, 입력을 완료했으면 엔터를 눌러주세요!");
            Console.WriteLine("                           (ESC입력 시 메뉴로 돌아갑니다.)             ");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
            InsetForm();

        }
        private void InsetForm()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ID[영문과 숫자를 혼합하여 6~10자 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  PASSWORD[영문과 숫자를 혼합하여 6~12자 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  PASSWORD확인");
            Console.WriteLine("  :");
            Console.WriteLine("  이름[한글만 입력해 주세요]");
            Console.WriteLine("  :");
            Console.WriteLine("  주민번호[숫자 13자리를 입력해주세요 ex)9808281111111]");
            Console.WriteLine("  :");
            Console.WriteLine("  전화번호[숫자만 입력해 주세요 EX)01026763147]");
            Console.WriteLine("  :");
            Console.WriteLine("  주소[경기도 군포시 고산로 539번길 7-12]");
            Console.WriteLine("  :");
            Console.WriteLine("  완료하기");
        }

        public void MemberInformation(MemberVO member)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write("ID:{0}", member.Id);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("회원코드:{0}", member.MemberCode);
            Console.Write("Password:{0}", member.Password);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("이름:{0}", member.Name);
            Console.Write("주민등록번호:{0}", member.PersonalCode);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("전화번호:{0}", member.PhoneNumber);
            Console.WriteLine("주소:{0}", member.Address);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        private void UserDataForm()
        {
            Console.WriteLine("  ID 입력");
            Console.WriteLine();
            Console.WriteLine("  회원명 입력");
            Console.WriteLine("");
            Console.WriteLine("  전화번호 입력");
            Console.WriteLine("");
            Console.WriteLine("  조회");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        private void UserManual()
        {
            Console.WriteLine("                         1.원하는 회원의 정보를 입력한다.");
            Console.WriteLine("                          2.조회를 눌러 회원을 검색한다.");
            Console.WriteLine("                        3.찾은 회원의 회원코드를 입력한다.");
        }
        public void MemberReviseGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                  회원정보 수정");
            UserManual();
            Console.WriteLine("                      4.엔터를 눌러 수정화면으로  넘어간다.");
            Console.WriteLine("                방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                      전체조회시 바로 조회를 눌러주세요 ");
            Console.WriteLine("                                    뒤로가기:ESC");
            Console.WriteLine("---------------------------------------------------------------------------------");
            UserDataForm();
            Console.WriteLine("회원코드를 정확하게 입력해 주세요!");
            Console.WriteLine(":");
        }
        public void MemberDeleteGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                    회원 삭제");
            UserManual();
            Console.WriteLine("                           4.엔터를 눌러 회원을 삭제한다.");
            Console.WriteLine("                 방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                        전체조회시 바로 조회를 눌러주세요 ");
            Console.WriteLine("                                    뒤로가기:ESC");
            Console.WriteLine("---------------------------------------------------------------------------------");
            UserDataForm();
            Console.WriteLine("회원코드를 정확하게 입력해 주세요!");
            Console.WriteLine(":");
        }
        public void MemberSearchGuide()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("                                    회원 조회");
            UserManual();
            Console.WriteLine();
            Console.WriteLine("                  방향키를 이용해 입력을 원하는 정보를 선택하세요!");
            Console.WriteLine("                           메뉴로 돌아가고 싶으면ESC ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            UserDataForm();
        }
    }
}
