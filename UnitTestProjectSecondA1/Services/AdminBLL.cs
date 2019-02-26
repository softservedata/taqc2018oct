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
    public class AdminBLL : UserBLL
    {
        //private User adminUser;
        //private LogoutCRUD logoutCRUD;
        private TokenlifetimeCRUD tokenlifetimeCRUD;

        public AdminBLL(IUser adminUser) : base(adminUser)
        {
            //this.adminUser = adminUser;
            //logoutCRUD = new LogoutCRUD();
            tokenlifetimeCRUD = new TokenlifetimeCRUD();
        }

        public AdminBLL UpdateTokenlifetime(Lifetime lifetime)
        {
            Console.WriteLine("lifetime = " + lifetime.Time + "   User = " + user);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", lifetime.Time);
            SimpleEntity simpleEntity = tokenlifetimeCRUD.HttpPutAsObject(bodyParameters, null, null);
            if (!simpleEntity.content.ToLower().Equals("true"))
            {
                ThrowException("Error Update Tokenlifetime");
            }
            return this;
        }

    }
}
