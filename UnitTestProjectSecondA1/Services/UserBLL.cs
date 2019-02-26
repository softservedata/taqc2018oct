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
    public class UserBLL : GuestBLL
    {
        protected IUser user;
        protected LogoutCRUD logoutCRUD;

        public UserBLL(IUser user)
        {
            this.user = user;
            logoutCRUD = new LogoutCRUD();
        }

        public GuestBLL LogoutAdmin()
        {
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", user.Name);
            SimpleEntity simpleEntity = logoutCRUD.HttpPostAsObject(bodyParameters, null, null);
            if (!simpleEntity.content.ToLower().Equals("true"))
            {
                ThrowException("Error Logout");
            }
            user.Token = "";
            return new GuestBLL();
        }

    }
}
