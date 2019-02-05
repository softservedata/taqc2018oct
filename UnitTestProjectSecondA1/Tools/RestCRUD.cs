using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSecondA1.Data;
using UnitTestProjectSecondA1.Entity;

namespace UnitTestProjectSecondA1.Tools
{
    public abstract class RestCRUD<T>
    {
        public RestUrl restUrl;
        private RestClient client;
        private JsonDeserializer deserial;

        public RestCRUD(RestUrl restUrl)
        {
            this.restUrl = restUrl;
            client = new RestClient(restUrl.ReadBaseUrl());
            deserial = new JsonDeserializer();
        }

        // private - - - - - - - - - - - - - - - - - - - -

        private T ConvertToObject(IRestResponse response)
        {
            T result = default(T);
            try
            {
                result = deserial.Deserialize<T>(response);
            }
            catch (Exception ex)
            {
                // TODO Save to Log File
                Console.Error.WriteLine("Exception: {0}\n{1}", ex.Message, ex.StackTrace);
                // TODO Develop Custom Exception
                throw new Exception("ConvertToObject Error. " + ex.Message);
            }
            return result;
        }

        private RestRequest PrepareRequest(RestRequest request, RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            if (bodyParameters != null)
            {
                foreach (KeyValuePair<string, string> current in bodyParameters.Parameters)
                {
                    Console.WriteLine("bodyParameters: " + current.Key + "   " + current.Value);
                    request.AddParameter(current.Key, current.Value);
                }
            }
            //
            if (urlSegment != null)
            {
                foreach (KeyValuePair<string, string> current in urlSegment.Parameters)
                {
                    Console.WriteLine("urlSegment: " + current.Key + "   " + current.Value);
                    request.AddUrlSegment(current.Key, current.Value);
                }
            }
            //
            if (urlParameters != null)
            {
                foreach (KeyValuePair<string, string> current in urlParameters.Parameters)
                {
                    Console.WriteLine("urlParameters: " + current.Key + "   " + current.Value);
                    // TODO
                    //request.AddUrlSegment(current.Key, current.Value);
                }
            }
            //
            return request;
        }

        private IRestResponse ExecuteRequest(RestRequest request, RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            return client.Execute(PrepareRequest(request, bodyParameters, urlSegment, urlParameters));
        }

        // Http Get - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpGetAsResponse(RestParameters urlSegment, RestParameters urlParameters)
        {
            var request = new RestRequest(restUrl.ReadGetUrl(), Method.GET);
            return ExecuteRequest(request, null, urlSegment, urlParameters);
        }

        public string HttpGetAsString(RestParameters urlSegment, RestParameters urlParameters)
        {
            return HttpGetAsResponse(urlSegment, urlParameters).Content;
        }

        public T HttpGetAsObject(RestParameters urlSegment, RestParameters urlParameters)
        {
            return ConvertToObject(HttpGetAsResponse(urlSegment, urlParameters));
        }

        // Http Post - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpPostAsResponse(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            var request = new RestRequest(restUrl.ReadPostUrl(), Method.POST);
            return ExecuteRequest(request, bodyParameters, urlSegment, urlParameters);
        }

        public string HttpPostAsString(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            return HttpPostAsResponse(bodyParameters, urlSegment, urlParameters).Content;
        }

        public T HttpPostAsObject(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            return ConvertToObject(HttpPostAsResponse(bodyParameters, urlSegment, urlParameters));
        }

        // Http Put - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpPutAsResponse(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            var request = new RestRequest(restUrl.ReadPutUrl(), Method.PUT);
            return ExecuteRequest(request, bodyParameters, urlSegment, urlParameters);
        }

        public string HttpPutAsString(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            return HttpPutAsResponse(bodyParameters, urlSegment, urlParameters).Content;
        }

        public T HttpPutAsObject(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            return ConvertToObject(HttpPutAsResponse(bodyParameters, urlSegment, urlParameters));
        }

        // Http Delete - - - - - - - - - - - - - - - - - - - -

        public virtual IRestResponse HttpDeleteAsResponse(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            var request = new RestRequest(restUrl.ReadDeleteUrl(), Method.DELETE);
            return ExecuteRequest(request, bodyParameters, urlSegment, urlParameters);
        }

        public string HttpDeleteAsString(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            return HttpDeleteAsResponse(bodyParameters, urlSegment, urlParameters).Content;
        }

        public T HttpDeleteAsObject(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            return ConvertToObject(HttpDeleteAsResponse(bodyParameters, urlSegment, urlParameters));
        }

    }
}
