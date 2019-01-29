using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public sealed class LifetimeRepository
    {
        private LifetimeRepository()
        {
        }

        public static Lifetime GetDefault()
        {
            return new Lifetime("300000");
        }
    }
}
