using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MpesaSdk.Callbacks;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MpesaSdk.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCallbackController : ControllerBase
    {
        private readonly ILogger<PaymentCallbackController> _logger;
        private readonly IWebHostEnvironment _environment;

        public PaymentCallbackController(ILogger<PaymentCallbackController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        [HttpPost("AccountBalance")]
        public async Task<IActionResult> MpesaAccountBalanceResultCallback([FromBody] AccountBalanceCallback response)
        {
            if (response is null)
            {
                return Ok(new
                {
                    ResultCode = 1,
                    ResultDesc = "Rejecting the transaction"
                });
            }

            var filename = $"{Guid.NewGuid()}.json";

            // Get root path directory
            var rootPath = Path.Combine(_environment.WebRootPath, "Application_Files\\MpesaAccountBalanceResults\\");
            // To check if directory exists. If the directory does not exists we create a new directory
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            // Get the path of filename
            var filePath = Path.Combine(_environment.WebRootPath, "Application_Files\\MpesaAccountBalanceResults\\", filename);

            await System.IO.File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(response, Formatting.Indented));

            _logger.LogInformation(JsonConvert.SerializeObject(response, Formatting.Indented));

            return Ok(new
            {
                ResultCode = "00000000",
                ResponseDesc = "success"
            });
        }

        [HttpPost("AccountBalance/timeout")]
        public async Task<IActionResult> MpesaAccountBalanceTimeoutCallback([FromBody] AccountBalanceCallback response)
        {
            if (response is null)
            {
                return Ok(new
                {
                    ResultCode = 1,
                    ResultDesc = "Rejecting the transaction"
                });
            }

            var filename = $"{Guid.NewGuid()}.json";

            // Get root path directory
            var rootPath = Path.Combine(_environment.WebRootPath, "Application_Files\\MpesaAccountBalanceTimeout\\");
            // To check if directory exists. If the directory does not exists we create a new directory
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            // Get the path of filename
            var filePath = Path.Combine(_environment.WebRootPath, "Application_Files\\MpesaAccountBalanceTimeout\\", filename);

            await System.IO.File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(response, Formatting.Indented));

            _logger.LogInformation(JsonConvert.SerializeObject(response, Formatting.Indented));

            return Ok(new
            {
                ResultCode = "00000000",
                ResponseDesc = "success"
            });
        }
    }
}
