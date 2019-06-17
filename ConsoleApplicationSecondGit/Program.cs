using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public class RestResult
    {
        public string content { get; set; }

        public override string ToString()
        {
            return content;
        }
    }

    public class RestResult2
    {
        [JsonProperty("content")]
        public string Answer { get; set; }

        public override string ToString()
        {
            return Answer;
        }
    }

    public class RestResult3
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }

    public class RestResult4
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        public override string ToString()
        {
            return Email;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //test creating branch OK_testing

            //string url = "http://localhost:8080/";
            //string url = "https://api.github.com/orgs/dotnet/repos";
            string url = "https://api.github.com";
            var client = new RestClient(url);
            //var request = new RestRequest("orgs/dotnet", Method.GET);
            //var request = new RestRequest(Method.GET);
            var request = new RestRequest("/orgs/dotnet/repos", Method.GET);
            //var request = new RestRequest("/orgs/dotnet", Method.GET);
            //
            //var request = new RestRequest("/tokenlifetime", Method.GET);
            //var request = new RestRequest("/", Method.GET);
            //var request = new RestRequest("item/125", Method.POST);
            //var request = new RestRequest("item/125", Method.PUT);
            //var request = new RestRequest("item/125", Method.DELETE);
            //var request = new RestRequest("/users", Method.GET);
            //
            //var request = new RestRequest("/", Method.GET);
            //var request = new RestRequest("/login", Method.POST);
            //request.AddParameter("name", "admin");
            //request.AddParameter("password", "qwerty");
            //
            //var request = new RestRequest("/tokenlifetime", Method.PUT);
            //request.AddParameter("token", "S3J851OE19VVZA44ZZRXI3PCPP0ONJLX");
            //request.AddParameter("time", "800000");
            //
            //request.RequestFormat = DataFormat.Json;
            // Add HTTP Headers
            //request.AddHeader("cache-control", "no-cache");
            //
            IRestResponse response = client.Execute(request);
            //Thread.Sleep(5000);
            //var response = client.ExecuteTaskAsync<string>(request);
            var content = response.Content;
            Console.WriteLine("content: " + content);
            //
            JsonDeserializer deserial = new JsonDeserializer();
            //var obj = deserial.Deserialize<RestResult>(response);
            //var obj = JsonConvert.DeserializeObject<RestResult2>(response.Content);
            var obj = JsonConvert.DeserializeObject<List<RestResult3>>(response.Content);
            //var obj = JsonConvert.DeserializeObject<RestResult4>(response.Content);
            //Console.WriteLine("Deserialize content: " + obj);
            Console.WriteLine("Deserialize content: " + obj[0]);
            foreach (RestResult3 current in obj)
            {
                Console.WriteLine("Deserialize content: " + current);
            }
            //
            //IRestResponse<RestResult> response2 = client.Execute<RestResult>(request);
            //Console.WriteLine("content: " + response2.Data.content);
            //
            //
            // Async Support
            //int i = 0;
            //Console.WriteLine("Start");
            //var asyncHandle = client.ExecuteAsync(request, response =>
            //{
            //    i = 1;
            //    Console.Write("content: ");
            //    Console.WriteLine(response.Content);
            //    i = 2;
            //});
            //Console.WriteLine("i= " + i);
            //
            // Async with Deserialization
            //var asyncHandle = client.ExecuteAsync<RestResult>(request, response =>
            //{
            //    Console.Write("content: ");
            //    Console.WriteLine(response.Data.content);
            //});
            //
            // abort the request on demand
            //asyncHandle.Abort();
        }
    }
}
