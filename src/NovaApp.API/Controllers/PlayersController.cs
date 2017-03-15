using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovaApp.API.DataProvider;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IDataProvider _dataProvider;
        // GET: api/values
        public PlayersController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var players = _dataProvider.GetPlayers();
            return Ok(players);
        }

        // GET rest/players/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var player = _dataProvider.GetPlayerById(id);
            return Ok(player);
        }

        // GET rest/players/5/transactions
        [HttpGet("{id}/transactions")]
        public IActionResult GetUserTransactions(int id)
        {
            var player = _dataProvider.GetTransactionByUserId(id);
            return Ok(player);
        }
    }
}
