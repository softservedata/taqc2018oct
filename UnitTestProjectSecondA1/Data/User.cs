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

    public enum UserFields : int
    {
        Name = 0,
        Password,
        Address,
        Email,
        Token
    }

    public class User : IName, IPassword, IAddress, IUserBuild, IUser
    {
        public const string EMAIL_SEPARATOR = "@";
        //
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
            return "Name: " + Name + " Password: " + Password + " Tocken: " + Token + " Address: " + Address;
        }

        // Static Factory

        public static IUser GetUser(IList<string> row)
        {
            IList<string> fields = new List<string>(row);
            for (int i = fields.Count; i < ((UserFields[])Enum.GetValues(typeof(UserFields))).Length; i++)
            {
                fields.Add("");
            }
            return Get()
               .SetName(fields[(int)UserFields.Name])
               .SetPassword(fields[(int)UserFields.Password])
               .SetAddress(fields[(int)UserFields.Address])
               .SetEmail(fields[(int)UserFields.Email])
               .SetToken(fields[(int)UserFields.Token])
               .Build();
        }


        public static IList<IUser> GetAllUsers(IList<IList<string>> rows)
        {
            //logger.Debug("Start GetAllUsers, path = " + path);
            IList<IUser> users = new List<IUser>();
            //if ((rows[0][(int)UserFields.Email] != null)
            //    && (!rows[0][(int)UserFields.Email].Contains(EMAIL_SEPARATOR)))
            //{
            //    rows.Remove(rows[0]);
            //}
            foreach (IList<string> row in rows)
            {
                if (row[(int)UserFields.Name].ToLower().Equals("name")
                        && row[(int)UserFields.Password].ToLower().Equals("password"))
                {
                    continue;
                }
                users.Add(GetUser(row));
            }
            return users;
        }

    }
}
