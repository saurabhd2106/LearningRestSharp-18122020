using BestBuyAPITest.Model;
using BestBuyAPITest.Model.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace BestBuyAPITest
{
    [TestClass]
    public class BestBuyAPITest
    {
        string endpointUrl = "http://ec2-3-129-89-35.us-east-2.compute.amazonaws.com:3030";

        string productResource = "/products";

        IRestClient restClient;

        [TestInitialize]
        public void Setup()
        {
            Console.WriteLine("Before every test method");
            restClient = new RestClient();
        }

        [TestMethod]
        public void VerifyGetAPITest()
        {
            // 1. IRestClient -- This is the client which sends the request
            // 2. IRestRequest -- This is a used to prepare a request
            // 3. IRestResponse -- Which represents the response

            //Process
            //1. Initialize IRestCLient
            //2. Initialize IRestRequest
            //3. Send a request using IRest CLient
            //4. Recieve the response
            //5. Process the response
            //6. Validate the response


            IRestRequest restRequest = new RestRequest(endpointUrl + productResource);

            IRestResponse restResponse =  restClient.Get(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Assert.AreEqual((200), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);
        }

        [TestMethod]
        public void VerifyGetAPITestWithPathParam()
        {
            string id = "43900";

            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}/{id}");

            IRestResponse restResponse = restClient.Get(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Assert.AreEqual((200), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);
        }

        [TestMethod]
        public void VerifyGetAPITestWithQueryParam()
        {
            
            int limit = 5;

            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");

            restRequest.AddParameter("$limit",limit);

            IRestResponse restResponse = restClient.Get(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Assert.AreEqual((200), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);
        }

        [TestMethod]
        public void VerifyGetAPITestWithQueryParamAndDeserializeResponse()
        {

            int limit = 2;

            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");

            restRequest.AddParameter("$limit", limit);

            IRestResponse<RootProduct> restResponse = restClient.Get<RootProduct>(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Assert.AreEqual((200), (int)restResponse.StatusCode);

            Assert.AreEqual(limit, restResponse.Data.limit);

            Console.WriteLine(restResponse.Data.data[1].name);

            foreach(var data in restResponse.Data.data)
            {
                Console.WriteLine(  data.id);
            }

            Console.WriteLine(restResponse.Data.data[1].categories[1].id);
        }

        [TestMethod]
        public void VerifyCreateAPITestWithPostRequest()
        {
            

            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");

            string requestPayload = "{\r\n  \"name\": \"IPhone\",\r\n  \"type\": \"Mobile\",\r\n  \"price\": 1000,\r\n  \"shipping\": 20,\r\n  \"upc\": \"ABC@123\",\r\n  \"description\": \"Best Mobile\",\r\n  \"manufacturer\": \"Apple\",\r\n  \"model\": \"IPhone 12\",\r\n  \"url\": \"string\",\r\n  \"image\": \"string\"\r\n}";

            restRequest.AddJsonBody(requestPayload);

            IRestResponse<DatumDto> restResponse = restClient.Post<DatumDto>(restRequest);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Assert.AreEqual((201), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);

            Console.WriteLine( restResponse.Data.id);
        }

        [TestMethod]
        public void VerifyCreateAPITestWithPostRequestWithDictionaryObject()
        {


            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");

          //  string requestPayload = "{\r\n  \"name\": \"IPhone\",\r\n  \"type\": \"Mobile\",\r\n  \"price\": 1000,\r\n  \"shipping\": 20,\r\n  \"upc\": \"ABC@123\",\r\n  \"description\": \"Best Mobile\",\r\n  \"manufacturer\": \"Apple\",\r\n  \"model\": \"IPhone 12\",\r\n  \"url\": \"string\",\r\n  \"image\": \"string\"\r\n}";


            Dictionary<string, object> requestPayload = new Dictionary<string, object>();

            requestPayload.Add("name", "IPhone");
            requestPayload.Add("type", "Mobile");
            requestPayload.Add("price", 1000);
            requestPayload.Add("shipping", 30);
            requestPayload.Add("upc", "IPhone 123");
            requestPayload.Add("description", "Best IPhone");
            requestPayload.Add("manufacturer", "Apple");
            requestPayload.Add("model", "IPhone 12");
            requestPayload.Add("url", "asfdsd");
            requestPayload.Add("image", "Apple");


            restRequest.AddJsonBody(requestPayload);

            IRestResponse<DatumDto> restResponse = restClient.Post<DatumDto>(restRequest);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Assert.AreEqual((201), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);

            Console.WriteLine(restResponse.Data.id);
        }

        [TestMethod]
        public void VerifyCreateAPITestWithPostRequestWithDtoObject()
        {


            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");


            Product requestPayload = new Product();

            requestPayload.name = "Samsung Mobile";
            requestPayload.type = "Mobile";
            requestPayload.price = 1000;
            requestPayload.shipping = 10;
            requestPayload.upc = "asd@udfg";
            requestPayload.description = "Best Mobile";
            requestPayload.manufacturer = "Samsung";
            requestPayload.model = "M21";
            requestPayload.url = "asfhgsdjh";
            requestPayload.image = "asfskd";


            restRequest.AddJsonBody(requestPayload);

            IRestResponse<DatumDto> restResponse = restClient.Post<DatumDto>(restRequest);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Assert.AreEqual((201), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);

            Console.WriteLine(restResponse.Data.id);
        }


        [TestMethod]
        public void VerifyEditAPITestWithPutRequestWithDtoObject()
        {

            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");

            Product requestPayload = new Product();

            requestPayload.name = "Samsung Mobile";
            requestPayload.type = "Mobile";
            requestPayload.price = 1000;
            requestPayload.shipping = 10;
            requestPayload.upc = "asd@udfg";
            requestPayload.description = "Best Mobile";
            requestPayload.manufacturer = "Samsung";
            requestPayload.model = "M21";
            requestPayload.url = "asfhgsdjh";
            requestPayload.image = "asfskd";


            restRequest.AddJsonBody(requestPayload);

            IRestResponse<DatumDto> restResponse = restClient.Post<DatumDto>(restRequest);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


            int id = restResponse.Data.id;

            //PUT request 

            IRestRequest restRequestForPut = new RestRequest($"{endpointUrl}{productResource}/{id}");

            Product requestPayloadForUpdate = new Product();

            requestPayloadForUpdate.name = "Iphone";
            requestPayloadForUpdate.type = "Mobile";
            requestPayloadForUpdate.price = 1000;
            requestPayloadForUpdate.shipping = 10;
            requestPayloadForUpdate.upc = "asd@udfg";
            requestPayloadForUpdate.description = "Best Mobile";
            requestPayloadForUpdate.manufacturer = "Apple";
            requestPayloadForUpdate.model = "IPhone 12";
            requestPayloadForUpdate.url = "asfhgsdjh";
            requestPayloadForUpdate.image = "asfskd";

            restRequestForPut.AddJsonBody(requestPayloadForUpdate);

            IRestResponse<DatumDto> restResponseFromUpdate = restClient.Put<DatumDto>(restRequestForPut);

            Assert.AreEqual(HttpStatusCode.OK, restResponseFromUpdate.StatusCode);

            //GET Request

            IRestRequest restRequestForGet = new RestRequest($"{endpointUrl}{productResource}/{id}");

            IRestResponse<DatumDto> restResponseFromGet = restClient.Get<DatumDto>(restRequestForGet);

            Assert.AreEqual(HttpStatusCode.OK, restResponseFromGet.StatusCode);

            Assert.AreEqual(requestPayloadForUpdate.name, restResponseFromGet.Data.name);
        }

        [TestMethod]
        public void VerifyEditAPITestWithPatchRequestWithDtoObject()
        {

            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");

            Product requestPayload = new Product();

            requestPayload.name = "Samsung Mobile";
            requestPayload.type = "Mobile";
            requestPayload.price = 1000;
            requestPayload.shipping = 10;
            requestPayload.upc = "asd@udfg";
            requestPayload.description = "Best Mobile";
            requestPayload.manufacturer = "Samsung";
            requestPayload.model = "M21";
            requestPayload.url = "asfhgsdjh";
            requestPayload.image = "asfskd";


            restRequest.AddJsonBody(requestPayload);

            IRestResponse<DatumDto> restResponse = restClient.Post<DatumDto>(restRequest);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


            int id = restResponse.Data.id;

            //PATCH request 

            IRestRequest restRequestForPatch = new RestRequest($"{endpointUrl}{productResource}/{id}");

            Product requestPayloadForUpdate = new Product();

            requestPayloadForUpdate.name = "Iphone";
            requestPayloadForUpdate.type = "ITab";


            restRequestForPatch.AddJsonBody(requestPayloadForUpdate);

            IRestResponse<DatumDto> restResponseFromUpdate = restClient.Patch<DatumDto>(restRequestForPatch);

            Assert.AreEqual(HttpStatusCode.OK, restResponseFromUpdate.StatusCode);

            //GET Request

            IRestRequest restRequestForGet = new RestRequest($"{endpointUrl}{productResource}/{id}");

            IRestResponse<DatumDto> restResponseFromGet = restClient.Get<DatumDto>(restRequestForGet);

            Assert.AreEqual(HttpStatusCode.OK, restResponseFromGet.StatusCode);

            Assert.AreEqual(requestPayloadForUpdate.name, restResponseFromGet.Data.name);
        }

        [TestMethod]
        public void VerifyCreateAPITestWithPostRequestWithRequestPayloadAsJsonFile()
        {


            IRestRequest restRequest = new RestRequest($"{endpointUrl}{productResource}");


            string requestPayload;

            requestPayload = File.ReadAllText("C:/Users/Admin/source/repos/LearningRestSharp/BestBuyAPITest/product.json");

            restRequest.AddJsonBody(requestPayload);

            IRestResponse<DatumDto> restResponse = restClient.Post<DatumDto>(restRequest);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Assert.AreEqual((201), (int)restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);

            Console.WriteLine(restResponse.Data.id);
        }


        public void SampleDictionaryObject()
        {

            Dictionary<string, object> requestPayload = new Dictionary<string, object>();

            requestPayload.Add("firstName", "Saurabh");
            requestPayload.Add("lastName","Dhingra");
            requestPayload.Add("employeeId",32748324);

            List<long> phoneNumbers = new List<long>();

            phoneNumbers.Add(2347834959);
            phoneNumbers.Add(238947938);

            requestPayload.Add("phoneNumber", phoneNumbers);

            List<Dictionary<string, object>> allAddresses = new List<Dictionary<string, object>>();

            Dictionary<string, object> address1 = new Dictionary<string, object>();

            address1.Add("type","home");
            address1.Add("houseNumber",567);
            address1.Add("city","Gurgaon");

            Dictionary<string, object> address2 = new Dictionary<string, object>();

            address2.Add("type", "office");
            address2.Add("houseNumber", 567);
            address2.Add("city", "Bangalore");

            allAddresses.Add(address1);
            allAddresses.Add(address2);


            requestPayload.Add("address", allAddresses);
        }

        public void SampleTestData2()
        {
            EmployeeDetails requestPayload = new EmployeeDetails();

            requestPayload.firstName = "Saurabh";
            requestPayload.lastName = "Dhingra";
            requestPayload.employeeId = 8947358934;

            List<long> phoneNumbers = new List<long>();

            phoneNumbers.Add(32462374);
            phoneNumbers.Add(324534875);
            phoneNumbers.Add(324634095);

            requestPayload.phoneNumber = phoneNumbers;

            Address address = new Address();

            address.type = "home";
            address.city = "Gurgaon";
            address.houseNumber = 2937;

            Address address2 = new Address();

            address2.type = "Office";
            address2.city = "Bangalore";
            address2.houseNumber = 2937;

            List<Address> allAddresses = new List<Address>();

            allAddresses.Add(address);
            allAddresses.Add(address2);

            requestPayload.address = allAddresses;
        }


        [TestCleanup]
        public void Cleanup()
        {
           Console.WriteLine("After every test method");
        }
    }
}
