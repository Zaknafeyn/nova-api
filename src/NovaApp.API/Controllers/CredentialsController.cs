using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class CredentialsController : Controller
    {
        private const string LiqPaySecretKeyString = "liqPaySecretKey";

        private readonly List<string> _settingsKeys = new List<string>
        {
            LiqPaySecretKeyString
        };

        private readonly IConfigurationRoot _configuration;

        // GET: api/values
        public CredentialsController(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var settings = _configuration.AsEnumerable().Where(x => _settingsKeys.Contains(x.Key)).Select(x => new { x.Key, x.Value }).ToList();
            return Ok(settings);
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            var result = _configuration[key];
            return Ok(result);
        }
    }
}
