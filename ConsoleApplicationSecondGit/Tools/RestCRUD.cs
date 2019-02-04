using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit.Tools
{


    public class RestCRUD<T>
    {

        public string Url { get; set; }
        private RestClient client;
        private JsonDeserializer deserializer;

        public RestCRUD(string url){
            Url = url;
        }

        public IRestResponse GetResponseAsJSON() {

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            
            return response;
        }
        public string GetResponseAsString()
        {

           return GetResponseAsJSON().Content;
        }

        public T GetResponseAsObject<T>()
        {
            return deserializer.Deserialize<T>(GetResponseAsJSON());
        }

        public IRestResponse PostResponseAsJSON(Dictionary<string, string> parameters) {

            var request = new RestRequest(Method.POST);
            foreach (KeyValuePair<string, string> current in parameters) {
                request.AddParameter(current.Key, current.Value);
            }

            return client.Execute(request);
        }
        public string PostResponseAsString(Dictionary<string, string> parameters)
        {

            return PostResponseAsJSON(parameters).Content;
        }

        public T PostResponseAsObject<T>(Dictionary<string, string> parameters)
        {
            return deserializer.Deserialize<T>(PostResponseAsJSON(parameters));
        }

        public IRestResponse PutResponseAsJSON(Dictionary<string, string> parameters)
        {

            var request = new RestRequest(Method.PUT);
            foreach (KeyValuePair<string, string> current in parameters)
            {
                request.AddParameter(current.Key, current.Value);
            }

            return client.Execute(request);
        }

        public string PutResponseAsString(Dictionary<string, string> parameters)
        {

            return PostResponseAsJSON(parameters).Content;
        }

        public T PutResponseAsObject<T>(Dictionary<string, string> parameters)
        {
            return deserializer.Deserialize<T>(PostResponseAsJSON(parameters));
        }

    }
}
