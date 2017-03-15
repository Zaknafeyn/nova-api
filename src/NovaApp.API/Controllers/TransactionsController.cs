using Microsoft.AspNetCore.Mvc;
using NovaApp.API.DataProvider;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly IDataProvider _dataProvider;
        
        public TransactionsController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        // GET: rest/transactions
        [HttpGet]
        public IActionResult Get()
        {
            var transactions = _dataProvider.GetTransactions();
            return Ok(transactions);
        }

        // GET rest/transactions/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var transaction = _dataProvider.GetTransactionById(id);
            return Ok(transaction);
        }
    }
}
