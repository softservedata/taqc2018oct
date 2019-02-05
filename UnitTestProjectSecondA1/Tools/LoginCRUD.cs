﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProjectSecondA1.Data;
using UnitTestProjectSecondA1.Entity;

namespace UnitTestProjectSecondA1.Tools
{
    public class LoginCRUD : RestCRUD<SimpleEntity>
    {
        public LoginCRUD() : base(UrlRepository.GetLogin())
        {
        }

        private void ThrowException(string message)
        {
            // TODO Develop Custom Exception
            throw new Exception(string.Format("Method {0} not Support for Login Resource", message));
        }

        public override IRestResponse HttpGetAsResponse(RestParameters urlSegment, RestParameters urlParameters)
        {
            ThrowException("GET");
            return null;
        }

        public override IRestResponse HttpPutAsResponse(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            ThrowException("PUT");
            return null;
        }

        public override IRestResponse HttpDeleteAsResponse(RestParameters bodyParameters, RestParameters urlSegment, RestParameters urlParameters)
        {
            ThrowException("DELETE");
            return null;
        }

    }
}
