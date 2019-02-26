using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public interface IUser
    {
        string Name { get; }        // Required
        string Password { get; }    // Required
        string Address { get; }     // Required
        string Token { get; set; }
        string Email { get; }

        //IUserBuild SetToken(string token);
    }
}
