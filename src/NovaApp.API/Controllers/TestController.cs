using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class TestController : Controller
    {
        private static readonly List<string> Data = new List<string>();

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = Data;
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromQuery]string data, [FromQuery] string signature, [FromBody] dynamic bodyStr)
        {
            var body = bodyStr == null ? "body is empty" : bodyStr;
            var value = $"data: '{data}', signature: '{signature}', body: '{body}'";
            Data.Add(value);
            return Ok(value);
        }
    }
}
