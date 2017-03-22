using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using NovaApp.API.DataObjects;
using NovaApp.API.DataObjects.PlayerObjects;
using NovaApp.API.DataProvider;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class PlayersController : BaseController
    {
        public PlayersController(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var players = DataProvider.GetPlayers();
            return Ok(players);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExtendedPlayerDataObject player)
        {
            var resPlayer = DataProvider.AddPlayer(player);

            var url = AbsoluteAction(ControllerContext, "Get", "players", new {id = resPlayer.Id});

            return Created(url, resPlayer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExtendedPlayerDataObject player)
        {
            var resPlayer = DataProvider.PutPlayer(id, player);

            return Ok(resPlayer);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] ExtendedPlayerDataObject player)
        {
            var resPlayer = DataProvider.PatchPlayer(id, player);

            return Ok(resPlayer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataProvider.DeletePlayer(id);

            return Ok();
        }

        // GET rest/players/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var player = DataProvider.GetPlayerById(id);
            return Ok(player);
        }

        // GET rest/players/5/transactions
        [HttpGet("{id}/transactions")]
        public IActionResult GetUserTransactions(int id)
        {
            var player = DataProvider.GetTransactionByUserId(id);
            return Ok(player);
        }
    }
}
