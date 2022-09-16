using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizza_tests
{
    public class ConfigurationHostApi
    {
        private const string url = "http://localhost:50009";
        private protected HttpClient client;

        public ConfigurationHostApi()
        {
            var application = new WebApplicationFactory<Program>();
            application.ClientOptions.BaseAddress = new Uri(url);
            client = application.CreateClient();

        }
    }
}
