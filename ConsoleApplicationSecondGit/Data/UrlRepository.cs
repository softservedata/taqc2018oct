using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit.Data
{
    public sealed class UrlRepository
    {
        private static string Url { get; set; }

        private UrlRepository()
        {
            Url = "http://localhost:8080/";
        }

        public static string GetLoginUrl() {

            return Url + "login";
        }
        public static string GetLogoutUrl()
        {
            return Url + "logout";
        }
        public static string GetTokenLifetimeUrl()
        {
            return Url + "tokenlifetime";
        }
    }
}
