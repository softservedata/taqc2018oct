using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestResult
{
    public class RestResult1
    {
        private string _content = String.Empty; //should be the name of Json field

        public string Content { get => _content; set => _content = value; }

        public override string ToString()
        {
            return Content;
        }
    }

    public class RestResult2
    {
        [JsonProperty("content")]
        private string _token = String.Empty; //should be the name of Json field

        public string Token { get => _token; set => _token = value; }

        public override string ToString()
        {
            return Token;
        }
    }

}
