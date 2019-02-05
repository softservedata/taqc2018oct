using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSecondA1.Data;
using UnitTestProjectSecondA1.Entity;
using UnitTestProjectSecondA1.Tools;

namespace UnitTestProjectSecondA1.Services
{
    public class LoginBLL
    {
        private LoginCRUD loginCRUD;

        public LoginBLL()
        {
            loginCRUD = new LoginCRUD();
        }

        public void SuccessfulUserLogin(User user)
        {
        }

        public void UnsuccessfulUserLogin(User user)
        {
        }

        public AdminBLL SuccessfulAdminLogin(User adminUser)
        {
            // Paraneters //TODO
            SimpleEntity simpleEntity = loginCRUD.HttpPostAsObject(null, null, null);
            // save adminUser //TODO
            return new AdminBLL(adminUser);
        }

        public AdminBLL UnsuccessfulAdminLogin(User adminUser)
        {
            return null;
        }
    }
}
