﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovaApp.API.DataObjects;
using NovaApp.API.DataProvider;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class PaymentPurposesController : BaseController
    {
        public PaymentPurposesController(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool enabledOnly)
        {
            var result = DataProvider.GetPaymentPurposes();
            if (enabledOnly)
                result = result.Where(x => !x.IsDisabled).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = DataProvider.GetPaymentPurposeById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PaymentPurposeDataObject paymentPurpose)
        {
            var result = DataProvider.AddPaymentPurposes(paymentPurpose);

            var url = AbsoluteAction(ControllerContext, "Get", "paymentPurposes", new { id = result.Id });

            return Created(url, result);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] PaymentPurposeDataObject newPaymentPurpose)
        {
            var result = DataProvider.PatchPaymentPurposes(id, newPaymentPurpose);

            return Ok(result);
        }
    }
}
