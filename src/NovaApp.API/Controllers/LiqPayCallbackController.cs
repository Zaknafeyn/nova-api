using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class LiqPayCallbackController : Controller
    {
        private readonly IConfigurationRoot _config;
        private static readonly List<string> Data = new List<string>();

        // GET: api/values
        public LiqPayCallbackController(IConfigurationRoot config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = Data;
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromForm] IFormCollection form)
        {
            var data = form["data"];
            var signature = form["signature"];

            var verificationSignature = LiqPayHelper.GetSignature(data, _config[Consts.LiqPaySecretKeyString]);
            if (string.CompareOrdinal(signature, verificationSignature) != 0)
            {
                var formDataStr = form.Select(x => $"{x.Key}:{x.Value} ");
                var result = string.Join(",", formDataStr.ToArray());
                var value = $"Data corrupted. Signatures are not identical!!!! FormData: {result}";
                Data.Add(value);
                return Ok(value);
            }
            else
            {
                var formDataStr = form.Select(x => $"{x.Key}:{x.Value} ");
                var result = string.Join(",", formDataStr.ToArray());
                var value = $"FormData: {result}";
                Data.Add(value);
                return Ok(value);
                // todo add record into DB that user has made payment
            }
        }

    }
}
