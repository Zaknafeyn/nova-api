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
    public class ClubsController : Controller
    {
        private readonly IDataProvider _dataProvider;

        public ClubsController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clubs = _dataProvider.GetClubs();
            return Ok(clubs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var club = _dataProvider.GetClubById(id);
            return Ok(club);
        }

        // GET api/values/5/players
        [HttpGet("{id}/players")]
        public IActionResult GetClubPlayers(int id)
        {
            var players = _dataProvider.GetPlayerByClubId(id);
            return Ok(players);
        }
    }
}
