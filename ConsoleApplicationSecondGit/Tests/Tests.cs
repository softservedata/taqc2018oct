using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplicationSecondGit.Services;
using ConsoleApplicationSecondGit.Data;
using NUnit.Framework;

namespace ConsoleApplicationSecondGit.Tests
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void VerifyLogin()
        {
            LoginBLL bll = new LoginBLL();

            User user = UserRepository.GetAdmin();
            bll.SuccesAdminLogin(user);
        }
    }
}
