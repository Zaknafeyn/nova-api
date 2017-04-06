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
            var liqPayPrivateKey = _config[Consts.LiqPaySecretKeyString];

            var data = liqPayData.GetBase64String();
            var signature = LiqPayHelper.GetSignature(data, liqPayPrivateKey);

            return Ok(new {data, signature});
        }
    }
}
