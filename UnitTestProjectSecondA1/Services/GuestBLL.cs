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
    public class GuestBLL
    {
        private LoginCRUD loginCRUD;
        private TokenlifetimeCRUD tokenlifetimeCRUD;

        public GuestBLL()
        {
            loginCRUD = new LoginCRUD();
            tokenlifetimeCRUD = new TokenlifetimeCRUD();
        }

        protected void ThrowException(string message)
        {
            // TODO Develop Custom Exception
            throw new Exception(message);
        }

        public Lifetime GetCurrentTokenlifetime()
        {
            Lifetime lifetime = new Lifetime();
            SimpleEntity simpleEntity = tokenlifetimeCRUD.HttpGetAsObject(null, null);
            lifetime.Time = simpleEntity.content;
            return lifetime;
        }

        public void SuccessfulUserLogin(IUser user)
        {
        }

        public void UnsuccessfulUserLogin(IUser user)
        {
        }

        public AdminBLL SuccessfulAdminLogin(IUser adminUser)
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("name", adminUser.Name)
                .AddParameters("password", adminUser.Password);
            SimpleEntity simpleEntity = loginCRUD.HttpPostAsObject(bodyParameters, null, null);
            adminUser.Token = simpleEntity.content;
            return new AdminBLL(adminUser);
        }

        public AdminBLL UnsuccessfulAdminLogin(User adminUser)
        {
            return null;
        }
    }
}
