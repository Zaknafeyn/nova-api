using Microsoft.AspNetCore.Mvc;
using NovaApp.API.DataObjects;
using NovaApp.API.DataProvider;
using NovaApp.API.QueryParams;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaApp.API.Controllers
{
    [Route("rest/[controller]")]
    public class ClubsController : BaseController
    {
        public ClubsController(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ClubQueryParams clubParams)
        {
            var showEmptyClub = clubParams?.ShowEmptyClub ?? true;
            var clubs = DataProvider.GetClubs(showEmptyClub);
            return Ok(clubs);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClubDataObject club)
        {
            var resClub = DataProvider.AddClub(club);

            var url = AbsoluteAction(ControllerContext, "Get", "clubs", new { id = resClub.Id });

            return Created(url, resClub);
        }

        // GET rest/clubs/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var club = DataProvider.GetClubById(id);
            return Ok(club);
        }

        // GET api/values/5/players
        [HttpGet("{id}/players")]
        public IActionResult GetClubPlayers(int id)
        {
            var players = DataProvider.GetPlayerByClubId(id);
            return Ok(players);
        }
    }
}
