using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public class Lifetime
    {
        public string Time { get; set; }

        public Lifetime()
        {
            Time = String.Empty;
        }

        public Lifetime(string time)
        {
            Time = time;
        }

    }
}
