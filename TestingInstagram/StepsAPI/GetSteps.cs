using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace TestingInstagram.StepsAPI
{
    [Binding]
    public class GetSteps:BaseSteps
    {
        [Given(@"sen an api request for a luke skywalker")]
        public void GivenSenAnApiRequestForALukeSkywalker()
        {
            restRequest = new RestRequest(Method.GET);
        }
        
        [When(@"response code is received")]
        public void WhenResponseCodeIsReceived()
        {
            restResponse = restClient.Execute(restRequest);
        }
        
        [Then(@"Resonse code is OK")]
        public void ThenResonseCodeIsOK()
        {
            HttpStatusCode statusCode = restResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Console.WriteLine(numericStatusCode);
        }
    }
}
