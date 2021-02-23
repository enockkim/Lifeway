using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MpesaSdk.Dtos;
using MpesaSdk.Exceptions;
using MpesaSdk.Interfaces;
using MpesaSdk.Response;
using MpesaSdk.Validators;
using Lifeway.Extensions.Alerts;
using Lifeway.Models;
//using Lifeway.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Lifeway.Controllers
{
    public class FinanceController : Controller
    {


        public IActionResult Summary()
        {
            var client = new RestClient("https://api.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic dUJDekJZd09wQmpnbFNTVUdlZnk4ZWI4UGRlUXptWDU6elBCR3ZIS0JMblBDamF1Rw==");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);


            //var _dataResponse = JToken.Parse(JsonConvert.erializeObject(response.Content));
            //var access_token = _dataResponse["access_token"];
            var tkn = JsonConvert.DeserializeObject<dynamic>(response.Content);
            string a_t = (tkn.ToString(Formatting.None));
            JObject at = JObject.Parse(a_t);
            string a_to = (string)at.SelectToken("access_token");

            var balance_client = new RestClient("https://api.safaricom.co.ke/mpesa/accountbalance/v1/query");
            client.Timeout = -1;
            var balance_request = new RestRequest(Method.POST);
            balance_request.AddHeader("Authorization", "Bearer "+a_to);
            balance_request.AddHeader("Content-Type", "application/json");
            balance_request.AddParameter("application/json", "{\r\n    \"Initiator\": \"Enock\",\r\n    \"SecurityCredential\": \"HToNsCLwNvvKMZXInHKmgn4tHjx8PNWx9zcpfw3zZc7Ss2odSR5xXCjmISB0zxchKU9zUPAMC0OawkHRD5YDP9fQ7db6UIWQuIpYJdqo/IdwowghUr8OcYwbtf6u4BpNPfHxxzgQFSSH6RnmwLbUYurzizufxMlQf4//IB+VfV7uHyh0x4iWLxHeUcaDamafluQ5iifcXR52mYs03vY31A6moo7V3/bydCRezrxaj8Ao2Zsns6Tsas457o8x1tNhtVTBnK9aDkAeO+y8ezCoys5R1l5kFmBuvhQ+aQD9y/jVpZGkRIWmMnT+xVoe5HVgxjj743T6HPo39f2wCervag==\",\r\n    \"CommandID\": \"AccountBalance\",\r\n    \"PartyA\": \"994805\",\r\n    \"IdentifierType\": \"4\",\r\n    \"Remarks\": \"check\",\r\n    \"QueueTimeOutURL\": \"http://portal.lifewaychristianacademy.sc.ke/paybill/confirmation.php\",\r\n    \"ResultURL\": \"http://portal.lifewaychristianacademy.sc.ke/paybill/confirmation.php\"\r\n}", ParameterType.RequestBody);
            IRestResponse balance_response = balance_client.Execute(balance_request);
            Console.WriteLine(balance_response.Content);

            var balance = JsonConvert.DeserializeObject<dynamic>(balance_response.Content);
            string sbalance = (balance.ToString(Formatting.None));
            JObject obalance = JObject.Parse(sbalance);
            string sebalance = (string)obalance.SelectToken("balance");

            //MpesaApiConfiguration a_token = ((JArray)a_t.access_token)[0].ToObject<MpesaApiConfiguration>();

            MpesaApiConfiguration api = new MpesaApiConfiguration
            {
                token = sebalance
            };
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //MpesaApiConfiguration[] persons = js.Deserialize<MpesaApiConfiguration[]>(access_token);

            //var token = JObject.Parse(response.Content);



            return View(api);
        }



        [HttpPost]
        static async Task AllStudents()
        {

        
        }
    }
}
