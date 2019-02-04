using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit.Data
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

        public static User NewUser()
        {

            return new User("...", "...");
        }

    }
}
