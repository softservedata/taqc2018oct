using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestResult;
using System.Text.RegularExpressions;

namespace UnitTestProject
{


    [TestFixture]
    public class Tests
    {
        private string token;
        private static readonly string url = "http://localhost:8080/"; //??
        private RestClient client = new RestClient(url);
        private string NewUserName { get; set; } = "NewUser"; 

        [Test]
        public void VerifyLogin()
        {


            //           
            var loginRequest = new RestRequest("/login", Method.POST);
            loginRequest.AddParameter("name", "admin");
            loginRequest.AddParameter("password", "qwerty");

            //RestSharp deserialization
            IRestResponse<RestResult1> loginResponse = client.Execute<RestResult1>(loginRequest);
            token = loginResponse.Data.Content;
            Assert.IsTrue(token.Length > 0);
        }
        [Test]
        public void VerifyUserCreation()
        {

            //var userCreationRequest = new RestRequest("/user", Method.POST);
            //userCreationRequest.AddParameter("token", token);
            //userCreationRequest.AddParameter("name", newUserName);
            //userCreationRequest.AddParameter("password", "PasswordOfNewUser");
            //userCreationRequest.AddParameter("rights", "false");
            //IRestResponse userCreationResponse = client.Execute(userCreationRequest);

            var usersRequest = new RestRequest("/users", Method.GET);
            usersRequest.AddParameter("token", token);
            IRestResponse CreatedUserVerificationResponse = client.Execute(usersRequest);
            var createdUser = CreatedUserVerificationResponse.Content;

            Regex patern = new Regex(@"\\t("+NewUserName+@")\\n\d*");
            Match match = patern.Match(createdUser);
            string actual = match.Groups[1].Value;
            Assert.AreEqual(NewUserName, actual);
        }


    }


}
