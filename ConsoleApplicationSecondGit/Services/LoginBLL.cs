using ConsoleApplicationSecondGit.Data;
using ConsoleApplicationSecondGit.Tools;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleApplicationSecondGit.Services
{
    public class LoginBLL
    {
        private RestCRUD<string> service;

        public LoginBLL() {
            service = new RestCRUD<string>(UrlRepository.GetLoginUrl());

        }

        public void SuccesUserLogin(User user)
        {
            Dictionary<string, string> userParameters = new Dictionary<string, string>();
            userParameters.Add(user.Name, user.Password);
            service.PostResponseAsString(userParameters);
            Assert.IsTrue(user.Token.Length > 0);
        }
        public void SuccesAdminLogin(User adminUser)
        {

        }


    }
}
