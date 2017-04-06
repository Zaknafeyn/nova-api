using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NovaApp.API.DataObjects.LiqPayObjects;

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class LiqPayController : Controller
    {
        private readonly IConfigurationRoot _config;
        // POST api/values
        public LiqPayController(IConfigurationRoot config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult BuildCredentials([FromBody] LiqPayDataObject liqPayData)
        {
            var data = GetBase64String(liqPayData);
            var liqPayPrivateKey = _config[Consts.LiqPaySecretKeyString];
            var sigRawString = $"{liqPayPrivateKey}{data}{liqPayPrivateKey}";
            
            var buffer = Encoding.UTF8.GetBytes(sigRawString);
            var sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(buffer);
            var signature = Convert.ToBase64String(hash);

            return Ok(new {data, signature});
        }

        private string GetBase64String(LiqPayDataObject liqPayData)
        {
            var dataString = JsonConvert.SerializeObject(liqPayData);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(dataString);
            var base64String = Convert.ToBase64String(plainTextBytes);
            return base64String;
        }
    }
}
