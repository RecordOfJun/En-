using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class MemberVO
    {
        private string id;
        private string password;
        private string name;
        private string phoneNumber;
        private string address;
        private List<BookVO> borrowedBook;
        public MemberVO()
        {
        }
        public MemberVO(string id,string password,string name,string phoneNumber,string address)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.address = address;
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
    }
}
