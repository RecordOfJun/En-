using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class MyBook
    {
        public BookVO book;
        public string borrowedTime;
        public string returnTime;
        public MyBook(BookVO book,string borrowedTime,string returnTime)
        {
            this.book = book;
            this.borrowedTime = borrowedTime;
            this.returnTime = returnTime;
        }
    }
    class MemberVO
    {

        private string id;
        private string password;
        private string temporalPassword;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        private string memberCode;
        public List<MyBook> borrowedBook = new List<MyBook>();
        public MemberVO()
        {
        }
        public MemberVO(string id,string password,string name,string phoneNumber,string address,string personalCode,string memberCode)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.personalCode = personalCode;
            this.memberCode = memberCode;
        }
        public void Init()
        {
            id = Constant.EMPTY;
            password = Constant.EMPTY;
            name = Constant.EMPTY;
            personalCode = Constant.EMPTY;
            phoneNumber = Constant.EMPTY;
            address = Constant.EMPTY;
            memberCode = Constant.EMPTY;
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
        
        public void AddBook(BookVO book)
        {
            MyBook myBook=new MyBook(book,DateTime.Now.ToString("yyyy-MM-dd"),DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"));
            borrowedBook.Add(myBook);
        }
        public void RemoveBook(MyBook mybook)
        {
            borrowedBook.Remove(borrowedBook.Find(element => element == mybook));
        }
        public bool IsHaveBook(BookVO book)
        {
            if (borrowedBook.Exists(element => element.book == book))
                return Constant.IS_HAVE;
            return !Constant.IS_HAVE;
        }
        public string MemberCode
        {
            get { return memberCode; }
            set { memberCode = value; }
        }
    }
}
