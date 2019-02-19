using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSecondA1.Data;
using UnitTestProjectSecondA1.Entity;

namespace UnitTestProjectSecondA1.Tools
{
    public class TokenlifetimeCRUD : RestCRUD<SimpleEntity>
    {
        public TokenlifetimeCRUD() : base(UrlRepository.GetTokenLifetime())
        {
        }

        public override IRestResponse HttpPostAsResponse(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            ThrowException("POST");
            return null;
        }

        public override IRestResponse HttpDeleteAsResponse(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            ThrowException("DELETE");
            return null;
        }

    }
}
