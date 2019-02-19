using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public sealed class UserRepository
    {
        private UserRepository()
        {
        }

        public static User GetAdmin()
        {
            return new User("admin", "qwerty");
        }

        public static User GetNewUser()
        {
            return new User("ivan", "qwerty");
        }

    }
}
