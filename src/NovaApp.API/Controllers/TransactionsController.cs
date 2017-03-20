using System;
using Microsoft.AspNetCore.Mvc;
using NovaApp.API.DataObjects;
using NovaApp.API.DataProvider;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class TransactionsController : BaseController
    {
        public TransactionsController(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        // GET: rest/transactions
        [HttpGet]
        public IActionResult Get()
        {
            var transactions = DataProvider.GetTransactions();
            return Ok(transactions);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransactionDataObject transaction)
        {
            var resTransaction = DataProvider.AddTransaction(transaction);

            var url = AbsoluteAction(ControllerContext, "Get", "transactions", new { id = resTransaction.Id });

            return Created(url, resTransaction);
        }

        // GET rest/transactions/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var transaction = DataProvider.GetTransactionById(id);
            return Ok(transaction);
        }
    }
}
