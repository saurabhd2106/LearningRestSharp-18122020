using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BestBuyAPITest
{
    [TestClass]
    public class AzureDevOpsApiTest
    {

        string endpointUrl = "https://dev.azure.com/qatechhub/_apis/projects";


        IRestClient restClient;

        [TestInitialize]
        public void Setup()
        {
            Console.WriteLine("Before every test method");
            restClient = new RestClient();

            restClient.Authenticator = new HttpBasicAuthenticator("saurabh.d2106@gmail.com", "tlikmpcshqwzxzgnwhtrcj4jjezd6bd3meocdiz5u46hh5vqoo5q");
        }

        [TestMethod]
        public void GetProjectAPI()
        {
            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse restResponse = restClient.Get(restRequest);

            Console.WriteLine(restResponse.Content);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        }
    }
}
