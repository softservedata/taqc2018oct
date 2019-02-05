using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Data
{
    public sealed class UrlRepository
    {
        private static string server = "http://localhost:8080/";
        public static string Server
        {
            get { return server; }
            set { server = value; }
        }

        private UrlRepository()
        {
        }

        public static RestUrl GetLogin()
        {
            return new RestUrl()
                .AddBaseUrl(Server + "login/")
                .AddGetUrl("")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetLogout()
        {
            return new RestUrl()
                .AddBaseUrl(Server + "logout/")
                .AddGetUrl("")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

        public static RestUrl GetTokenLifetime()
        {
            return new RestUrl()
                .AddBaseUrl(Server + "tokenlifetime/")
                .AddGetUrl("")
                .AddPostUrl("")
                .AddPutUrl("")
                .AddDeleteUrl("");
        }

    }
}
