using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using RestSharp;
using RestSharp.Serialization.Json;
using UnitTestProjectSecondA1.Services;
using UnitTestProjectSecondA1.Data;

namespace UnitTestProjectSecondA1
{
    public class RestResult
    {
        public string content { get; set; }

        public RestResult()
        {
            content = string.Empty;
        }

        public override string ToString()
        {
            return content;
        }
    }

    [TestFixture]
    public class SimpleTest
    {
        private string tokenAdmin;

        //[Test]
        public void CheckLogin()
        {
            // Precondition
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
            driver.Navigate().GoToUrl("https://softserve.academy/");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Steps
            driver.FindElement(By.LinkText("Log in")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello Temp");
            Thread.Sleep(2000); // For Presentation ONLY
            //
            //
            driver.Navigate().Refresh();
            Thread.Sleep(2000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("username")).SendKeys(" new Hello");
            Thread.Sleep(2000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(2000); // For Presentation ONLY
            //
            driver.Quit();
        }

        //[Test]
        public void CheckRest()
        {
            // RestClient
            //string url = "https://api.github.com/";
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            //
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            // var request = new RestRequest("orgs/dotnet/repos", Method.GET);
            //
            //var request = new RestRequest("/", Method.GET);
            //var request = new RestRequest("item/125", Method.POST);
            //var request = new RestRequest("item/125", Method.PUT);
            //var request = new RestRequest("item/125", Method.DELETE);
            //var request = new RestRequest("/users", Method.GET);
            //var request = new RestRequest("/login", Method.POST);
            var request = new RestRequest(Method.GET);
            //
            //request.RequestFormat = DataFormat.Json;
            //
            // Add HTTP Headers
            //request.AddHeader("header", "value");
            //
            //request.AddBody(new Item
            //{
            //    ItemName = "someName",
            //    Price = 19.99
            //});
            //
            //request.AddParameter("name", "value");
            request.AddParameter("name", "admin");
            request.AddParameter("password", "qwerty");
            //request.AddParameter("token", "9HVFA4SO13VSY4GQX0UY97HG3S7Y2MEM");
            //
            // Adds to POST or URL querystring based on Method
            //var request = new RestRequest("resource/{id}", Method.POST);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
            //
            // Sdd files to upload (works with compatible verbs)
            //request.AddFile(path);
            //
            // Execute the Request
            IRestResponse response = client.Execute(request);
            //
            // Aontent as String
            var content = response.Content;
            Console.WriteLine("content: " + content);
            //
            // Automatically Deserialize Result
            // RestResponse<Person> response2 = client.Execute<Person>(request);
            // var name = response2.Data.Name;
            //
            // Async Support
            // client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});
            //
            // Async with Deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});
            //
            // abort the request on demand
            // asyncHandle.Abort();
            //
            Console.WriteLine("done");
        }

        //[Test]
        public void CheckTime()
        {
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            //
            var request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "admin");
            request.AddParameter("password", "qwerty");
            IRestResponse response = client.Execute(request);
            //
            JsonDeserializer deserial = new JsonDeserializer();
            string adminToken = deserial.Deserialize<RestResult>(response).content;
            Assert.IsTrue(adminToken.Length > 0, "Login Error");
            //
            request = new RestRequest("/tokenlifetime", Method.GET);
            response = client.Execute(request);
            string time = deserial.Deserialize<RestResult>(response).content;
            Assert.AreEqual("300000", time, "Time Error");
            //
            request = new RestRequest("/tokenlifetime", Method.PUT);
            request.AddParameter("token", adminToken);
            request.AddParameter("time", "800000");
            response = client.Execute(request);
            string result = deserial.Deserialize<RestResult>(response).content;
            StringAssert.AreEqualIgnoringCase("true", result, "Update Time Error");
            //Assert.AreEqual("true", result, "Update Time Error");
            //
            request = new RestRequest("/logout", Method.POST);
            request.AddParameter("name", "admin");
            request.AddParameter("token", adminToken);
            response = client.Execute(request);
            result = deserial.Deserialize<RestResult>(response).content;
            StringAssert.AreEqualIgnoringCase("true", result, "Logout Error");
        }

        //[Test, Order(1)]
        public void VerifyLogin()
        {
            var client = new RestClient("http://localhost:8080/login");
            var request = new RestRequest(Method.POST);
            request.AddParameter("name", "admin");
            request.AddParameter("password", "qwerty");
            IRestResponse response = client.Execute(request);
            //
            JsonDeserializer deserial = new JsonDeserializer();
            tokenAdmin = deserial.Deserialize<RestResult>(response).content;
            Assert.IsTrue(tokenAdmin.Length > 0, "Login Error");
        }

        //[Test, Order(2)]
        public void VerifyTime()
        {
            var client = new RestClient("http://localhost:8080/tokenlifetime");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //
            JsonDeserializer deserial = new JsonDeserializer();
            string time = deserial.Deserialize<RestResult>(response).content;
            Assert.AreEqual("300000", time, "Time Error");
        }

        //[Test, Order(3)]
        public void VerifyUpdateTime()
        {
            var client = new RestClient("http://localhost:8080/tokenlifetime");
            var request = new RestRequest(Method.PUT);
            request.AddParameter("token", tokenAdmin);
            request.AddParameter("time", "800000");
            IRestResponse response = client.Execute(request);
            //
            JsonDeserializer deserial = new JsonDeserializer();
            string result = deserial.Deserialize<RestResult>(response).content;
            StringAssert.AreEqualIgnoringCase("true", result, "Update Time Error");
        }

        //[Test, Order(4)]
        public void VerifyLogout()
        {
            var client = new RestClient("http://localhost:8080/logout");
            var request = new RestRequest(Method.POST);
            request.AddParameter("name", "admin");
            request.AddParameter("token", tokenAdmin);
            IRestResponse response = client.Execute(request);
            //
            JsonDeserializer deserial = new JsonDeserializer();
            string result = deserial.Deserialize<RestResult>(response).content;
            StringAssert.AreEqualIgnoringCase("true", result, "Logout Error");
        }

        // DataProvider
        private static readonly object[] AdminUsers =
        {
            //new object[] { UserRepository.Get().Registered() },
            new object[] { UserRepository.GetAdmin(), LifetimeRepository.GetLongTime() }
        };

        [Test, TestCaseSource("AdminUsers")]
        public void ExamineTime(User adminUser, Lifetime newTokenlifetime)
        {
            GuestBLL guest = new GuestBLL();
            Lifetime currentTokenlifetime = guest.GetCurrentTokenlifetime();
            Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Current Time Error");
            //
            AdminBLL admin = guest
                .SuccessfulAdminLogin(adminUser)
                .UpdateTokenlifetime(newTokenlifetime);
            currentTokenlifetime = admin.GetCurrentTokenlifetime();
            Assert.AreEqual(LifetimeRepository.LONG_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Long Time Error");
            //
            guest = admin.LogoutAdmin();
            Assert.IsEmpty(adminUser.Token, "Logout Error");
            //
            // Return to Previous State
            currentTokenlifetime.Time = LifetimeRepository.DEFAULT_TOKEN_LIFETIME;
            guest.SuccessfulAdminLogin(adminUser)
                .UpdateTokenlifetime(currentTokenlifetime)
                .LogoutAdmin();
            //
            currentTokenlifetime = guest.GetCurrentTokenlifetime();
            Assert.AreEqual(LifetimeRepository.DEFAULT_TOKEN_LIFETIME,
                        currentTokenlifetime.Time, "Current Time Error");
        }
    }
}
