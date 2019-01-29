using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Tools
{
    public class RestCRUD<T>
    {
        public string Url { get; private set; }
        private RestClient client;
        private JsonDeserializer deserial;

        public RestCRUD(string url)
        {
            Url = url;
            client = new RestClient(url);
            deserial = new JsonDeserializer();
        }

        public IRestResponse HttpGetAsResponse()
        {
            var request = new RestRequest(Method.GET);
            return client.Execute(request);
        }

        public string HttpGetAsString()
        {
            return HttpGetAsResponse().Content;
        }

        public T HttpGetAsObject()
        {
            // TODO try{} catch()
            return deserial.Deserialize<T>(HttpGetAsResponse());
        }

        public IRestResponse HttpPostAsResponse(Dictionary<string, string> parameters)
        {
            var request = new RestRequest(Method.POST);
            foreach (KeyValuePair<string, string> current in parameters)
            {
                Console.WriteLine(current.Key + "   " + current.Value);
                request.AddParameter(current.Key, current.Value);
            }
            return client.Execute(request);
        }

        public string HttpPostAsString(Dictionary<string, string> parameters)
        {
            return HttpPostAsResponse(parameters).Content;
        }

        public T HttpPostAsObject(Dictionary<string, string> parameters)
        {
            // TODO try{} catch()
            return deserial.Deserialize<T>(HttpPostAsResponse(parameters));
        }

        public IRestResponse HttpPutAsResponse(Dictionary<string, string> parameters)
        {
            var request = new RestRequest(Method.PUT);
            foreach (KeyValuePair<string, string> current in parameters)
            {
                Console.WriteLine(current.Key + "   " + current.Value);
                request.AddParameter(current.Key, current.Value);
            }
            return client.Execute(request);
        }

        public string HttpPutAsString(Dictionary<string, string> parameters)
        {
            return HttpPutAsResponse(parameters).Content;
        }

        public T HttpPutAsObject(Dictionary<string, string> parameters)
        {
            // TODO try{} catch()
            return deserial.Deserialize<T>(HttpPutAsResponse(parameters));
        }

    }
}
