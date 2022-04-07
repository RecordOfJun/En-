using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using Library.View;

namespace Library.Controller
{
    class UserFunction
    {
        UI ui = new UI();
        private string id;
        private string password;
        private string name;
        private string personalCode;
        private string phoneNumber;
        private string address;
        public UserFunction()
        {

        }
        public void Login()
        {

        }
        public void AddMember()
        {
            Console.Clear();
            ui.LibraryLabel();
            ui.AddMemberForm();
        }
    }
}
