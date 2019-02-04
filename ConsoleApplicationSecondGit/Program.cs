using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;
using RestResult;

namespace ConsoleApplicationSecondGit
{

    public class Program
    {
        public static void Main(string[] args)
        {
            //RestResult restResult = new RestResult();
            //string token = restResult.ToString();
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            //           
            var loginRequest = new RestRequest("/login", Method.POST);
            loginRequest.AddParameter("name", "admin");
            loginRequest.AddParameter("password", "qwerty");

            //RestSharp deserialization
            IRestResponse<RestResult1> loginResponse = client.Execute<RestResult1>(loginRequest);
            var token = loginResponse.Data.Content;
            //IRestResponse loginResponse = client.Execute(loginRequest);
            var loginData = loginResponse.Content;

            //RegeX parth 
            //Regex pattern = new Regex("{\"content\":\\s*\"(\\w+)\"}");
            //MatchCollection matchCollection = pattern.Matches(loginData);
            //foreach (Match current in matchCollection)
            //{
            //    token = current.Groups[1].ToString();
            //    Console.WriteLine("REGEX token: " + token);
            //}
            //Newtonsoft.Json.Linq
            //JObject jObject = JObject.Parse(loginData);
            //token = (string)jObject.SelectToken("content");
            //Console.WriteLine("token: " + token);

            //RestSharp.Serialization
            //JsonDeserializer deserial = new JsonDeserializer();
            //var token = deserial.Deserialize<RestResult1>(loginResponse);
            //Console.WriteLine("obj: " + obj);

            //Newtonsoft.Json
            //JsonDeserializer deserial = new JsonDeserializer();
            //var token = JsonConvert.DeserializeObject<RestResult2>(loginResponse.Content);


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
