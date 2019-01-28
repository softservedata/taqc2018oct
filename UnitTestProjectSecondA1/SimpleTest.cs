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

namespace UnitTestProjectSecondA1
{
    [TestFixture]
    public class SimpleTest
    {
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

        [Test]
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
            var request = new RestRequest("/login", Method.POST);
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
    }
}
