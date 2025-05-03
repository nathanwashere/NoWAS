using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class Person
    {
        private string userName;
        private string password;

        public Person(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public string getUserName()
        {
            return this.userName;
        }
        public string getPassword()
        {
            return this.password;
        }
    }
}
