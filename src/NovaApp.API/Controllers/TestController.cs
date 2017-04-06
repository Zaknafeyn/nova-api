using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Post([FromForm] IFormCollection form)
        {
            var formDataStr = form.Select(x => $"{x.Key}:{x.Value} ");
            var result = string.Join(",", formDataStr.ToArray());
            var value = $"FormData: {result}";
            Data.Add(value);
            return Ok(value);
        }
    }
}
