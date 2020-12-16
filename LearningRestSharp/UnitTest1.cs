using LearningHttpClient.Model.JsonModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Net;

namespace LearningRestSharp
{
    [TestClass]
    public class UnitTest1
    {

        string endpointUrl = "http://localhost:3030/products";

        [TestMethod]
        public void VerifyGetProduct()
        {


            IRestClient restClient = new RestClient();

            IRestRequest restRequest = new RestRequest(endpointUrl);

            restRequest.AddHeader("Accept","application/json");

            IRestResponse restResponse =  restClient.Get(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

            Assert.AreEqual(200,(int)restResponse.StatusCode);

            string responseContent = restResponse.Content;

            Console.WriteLine(responseContent);

            

        }

        [TestMethod]
        public void VerifyGetProductWithDeserializeResponse()
        {


            IRestClient restClient = new RestClient();

            restClient.AddDefaultHeader("ContentType","application/json");

            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse<ProductRootObject> restResponse = restClient.Get<ProductRootObject>(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

            Assert.AreEqual(200, (int)restResponse.StatusCode);

            int limit = restResponse.Data.limit;

            Console.WriteLine(limit);

        }

        [TestMethod]
        public void VerifyPostRequest()
        {

            IRestClient restClient = new RestClient();

            restClient.AddDefaultHeader("ContentType", "application/json");

            IRestRequest restRequest = new RestRequest(endpointUrl);
            


        }

        [TestMethod]
        public void GetProjectList()
        {
            string endpointUrl = "https://dev.azure.com/qatechhub/_apis/projects";

            IRestClient client = new RestClient
            {
                Authenticator = new HttpBasicAuthenticator("saurabh.d2106@gmail.com", "tlikmpcshqwzxzgnwhtrcj4jjezd6bd3meocdiz5u46hh5vqoo5q")
            };

            var request = new RestRequest(endpointUrl);

            IRestResponse response = client.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Console.WriteLine(response.StatusCode);

            Console.WriteLine(response.Content);
        }


    }
}
