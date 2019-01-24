using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleApplicationSecondGit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            //           
            var loginTest = new RestRequest("/login", Method.POST);
            loginTest.AddParameter("name", "admin");
            loginTest.AddParameter("password", "qwerty");

            IRestResponse loginResponse = client.Execute(loginTest);
            var loginData = loginResponse.Content;

            //RegeX parth 
            string token = "";
            Regex pattern = new Regex("{\"content\":\\s*\"(\\w+)\"}");
            MatchCollection matchCollection = pattern.Matches(loginData);
            foreach (Match current in matchCollection)
            {
                token = current.Groups[1].ToString();
                Console.WriteLine("REGEX token: " + token);
            }
            //JObject parth
            //JObject jObject = JObject.Parse(loginData);
            //token = (string)jObject.SelectToken("content");
            //Console.WriteLine("token: " + token);

            //
            var tokenLifeChange = new RestRequest("/tokenlifetime", Method.PUT);
            tokenLifeChange.AddParameter("token", token);
            tokenLifeChange.AddParameter("time", 700000);
            IRestResponse tokenLifeChangeResponse = client.Execute(tokenLifeChange);

            //
            var tokenRequest = new RestRequest("/tokenlifetime", Method.GET);
            IRestResponse tokenResponse = client.Execute(tokenRequest);
            var tokenContent = tokenResponse.Content;

            //

            var userRequest = new RestRequest("/user", Method.GET);
            userRequest.AddParameter("token", token);
            IRestResponse userResponse = client.Execute(userRequest);
            var userContent = userResponse.Content;

            //
            Console.WriteLine("loginData: " + loginData);
            Console.WriteLine("content: " + tokenContent);
            Console.WriteLine("userContent: " + userContent);
            Console.ReadLine();
        }
    }
}
