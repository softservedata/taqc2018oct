using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public sealed class UserRopesitory
    {
        private UserRopesitory()
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
