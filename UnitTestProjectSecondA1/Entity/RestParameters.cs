﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Entity
{
    public class RestParameters
    {
        public Dictionary<string, string> Parameters { get; private set; }

        public RestParameters()
        {
            Parameters = new Dictionary<string, string>();
        }

        public RestParameters AddParameters(string key, string url)
        {
            Parameters.Add(key, url);
            return this;
        }

        public string GetParameters(string key)
        {
            return Parameters[key];
        }

    }
}
