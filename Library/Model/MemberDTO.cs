using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class MyBook
    {
        public BookDTO book;
        public string borrowedTime;
        public string returnTime;
        public MyBook(BookDTO book,string borrowedTime,string returnTime)
        {
            this.book = book;
            this.borrowedTime = borrowedTime;
            this.returnTime = returnTime;
        }
    }
    class MemberDTO
    {
        private string id;
        private string password;
        private string temporalPassword;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        private string memberCode;
        private int borrowed = 0;
        public MemberDTO(string id,string password,string name,string phoneNumber,string address,string personalCode,string memberCode)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.personalCode = personalCode;
            this.memberCode = memberCode;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string TemporalPassword
        {
            get { return temporalPassword; }
            set { temporalPassword = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PersonalCode
        {
            get { return personalCode; }
            set { personalCode = value; }
        }
        public bool IsHaveBook(string code)
        {
            if (MemberDAO.GetDBConnection().IsBorrowd(this.memberCode,code))
                return Constant.IS_HAVE;
            return !Constant.IS_HAVE;
        }
        public string MemberCode
        {
            get { return memberCode; }
            set { memberCode = value; }
        }
        public int Borrowed
        {
            get { return borrowed; }
            set { borrowed = value; }
        }
    }
}
