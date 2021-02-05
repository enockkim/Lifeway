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


            var _dataResponse = JToken.Parse(JsonConvert.SerializeObject(response.Content));
            //var access_token = _dataResponse["access_token"];

            //MpesaApiConfiguration api = new MpesaApiConfiguration
            //{
            //    token = access_token
            //};
            JavaScriptSerializer js = new JavaScriptSerializer();
            MpesaApiConfiguration[] persons = js.Deserialize<MpesaApiConfiguration[]>(access_token);

            var token = JObject.Parse(response.Content);

            return View(_dataResponse);
        }



        [HttpPost]
        static async Task AllStudents()
        {

        
        }
    }
}
