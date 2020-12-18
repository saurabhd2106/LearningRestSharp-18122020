using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;

namespace BestBuyAPITest
{
    [TestClass]
    public class BestBuyAPITest
    {
        [TestMethod]
        public void VerifyGetAPITest()
        {
            // 1. IRestClient -- This is the client which sends the request
            // 2. IRestRequest -- This is a used to prepare a request
            // 3. IRestResponse -- Which represents the response

            //Process
            //1. Initialize IRestCLient
            //2. Initialize IRestRequest
            //3. Send a reqquest using IRest CLient
            //4. Recieve the response
            //5. Process the response
            //6. Validate the response

            string endpointUrl = "http://ec2-3-129-89-35.us-east-2.compute.amazonaws.com:3030/products";

            IRestClient restClient = new RestClient();

            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse restResponse =  restClient.Get(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

            Assert.AreEqual((200), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);
        }
    }
}
