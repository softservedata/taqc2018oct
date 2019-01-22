using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            //var request = new RestRequest("/tokenlifetime", Method.GET);
            //
            var request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "admin");
            request.AddParameter("password", "qwerty");
            //
            IRestResponse response = client.Execute(request);
            //
            var content = response.Content;
            Console.WriteLine("content: " + content);
        }
    }
}
