using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSecondA1.Data;
using UnitTestProjectSecondA1.Tools;

namespace UnitTestProjectSecondA1.Services
{
    public class LoginBLL
    {
        private RestCRUD<string> service;

        public LoginBLL()
        {
            service = new RestCRUD<string>(UrlRepository.GetLogin());
        }

        public void SuccesUserLogin(User user)
        {
        }

        public void SuccesAdminLogin(User adminUser)
        {
        }

    }
}
