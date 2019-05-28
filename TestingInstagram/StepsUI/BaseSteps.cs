using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingInstagram
{
    public class BaseSteps
    {
        protected RestClient restClient;
        protected RestRequest restRequest;
        protected IRestResponse restResponse;

        protected readonly Uri BaseUri = new Uri("http://swapi.co/api/people/1");
        public BaseSteps()
        {
            restClient = new RestClient();

        }
    }
}
