using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public interface IName
    {
        IPassword SetName(string name);
    }

    public interface IPassword
    {
        IAddress SetPassword(string password);
    }

    public interface IAddress
    {
        IUserBuild SetAddress(string address);
    }

    public interface IUserBuild
    {
        IUserBuild SetToken(string token);
        IUserBuild SetEmail(string email);
        User Build();
    }


    public class User : IName, IPassword, IAddress, IUserBuild, IUser
    {
        public string Name { get; private set; }            // Required
        public string Password { get; private set; }        // Required
        public string Address { get; private set; }         // Required
        public string Token { get; set; }
        public string Email { get; private set; }

        // 1. Use Constructor.
        //public User(string name, string password, string address, string token, string email)
        //{
        //    Name = name;
        //    Password = password;
        //    Address = address;
        //    Token = token;
        //    Email = email;
        //}

        // 2. Use Default Constructor and Setters.
        //public User()
        //{
        //}

        // 4. Add Static Factory.
        private User()
        {
            Token = "not exist";
            Email = "not exist";
        }

        // 4. Add Static Factory.
        //public static User Get()
        // 5. Add Builder.
        public static IName Get()
        {
            return new User();
        }

        // 2. Use Default Constructor and Setters.
        //public void SetName(string name)
        // 3. Add Fluent Interface.
        public IPassword SetName(string name)
        {
            Name = name;
            return this;
        }

        public IAddress SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public IUserBuild SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public IUserBuild SetToken(string token)
        {
            Token = token;
            return this;
        }

        public IUserBuild SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public User Build()
        {
            return this;
        }

        public override string ToString()
        {
            return "Name: " + Name + " Password: " + Password + " Tocken" + Token;
        }
    }
}
