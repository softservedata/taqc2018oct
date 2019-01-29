using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public sealed class UrlRepository
    {
        private UrlRepository()
        {
        }

        public static string GetLogin()
        {
            return "http://localhost:8080/login";
        }

        public static string GetLogout()
        {
            return "http://localhost:8080/logout";
        }

        public static string GetTokenLifetime()
        {
            return "http://localhost:8080/tokenlifetime";
        }
    }
}
