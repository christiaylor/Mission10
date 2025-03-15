using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission10.Data;

namespace mission10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private BowlingLeagueContext _bowlerContext;
        public BowlerController(BowlingLeagueContext temp)
        {
            _bowlerContext = temp;
        }

        [HttpGet(Name = "GetBowler")]
        public IEnumerable<Bowler> Get()
        {
            var teamNames = new List<string> { "Marlins", "Sharks" };
            var bowlerList = _bowlerContext.Bowlers
                .Include(b => b.Team)
                .Where(b => teamNames.Contains(b.Team.TeamName))
                .ToList();

            return (bowlerList);
        }
    }
}

// I think this one is good.
