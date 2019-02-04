using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit.Data
{
    class LifetimeRepository
    {
        private LifetimeRepository()
        {

        }

        public static Lifetime GetAdmin()
        {
            return new Lifetime("300000");
        }


    }
}
