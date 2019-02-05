using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSecondA1.Data;

namespace UnitTestProjectSecondA1.Services
{
    public class AdminBLL
    {
        private User adminUser;

        public AdminBLL(User adminUser)
        {
            this.adminUser = adminUser;
        }
    }
}
