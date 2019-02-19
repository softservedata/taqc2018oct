using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public User()
        {
            Name = String.Empty;
            Password = String.Empty;
            Token = String.Empty;
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
            Token = String.Empty;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Password: " + Password + " Tocken" + Token;
        }
    }
}
