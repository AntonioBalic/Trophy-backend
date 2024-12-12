using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioBalic_Lab_07.Repositories;

namespace AntonioBalic_Lab_07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrophyController : ControllerBase
    {
        
        private TrophyRepository _trophyRepository;

        public TrophyController(TrophyRepository trophyRepository)
        {
            _trophyRepository = trophyRepository;
        }

        [HttpGet("all")]
        public IEnumerable<Trophy> GetTrophies()
        {
            return _trophyRepository.Trophy;
        }

        [HttpPost("new")]
        public IEnumerable<Trophy> AddNewTrophy([FromBody] Trophy trophy)
        {
            if (trophy.Sponsors == null)
            {
                trophy.Sponsors = new List<string>();
            }
            _trophyRepository.Trophy.Add(trophy);
            return _trophyRepository.Trophy;
        }

        [HttpDelete("delete/{id}")]
        public IEnumerable<Trophy> DeleteTrophy([FromRoute] Guid id)
        {
            _trophyRepository.Trophy = _trophyRepository.Trophy.Where(x => x.Id != id).ToList();
            return _trophyRepository.Trophy;
        }

        [HttpPut("update/{id}")]
        public IEnumerable<Trophy> UpdateTrophy([FromRoute] Guid id, [FromBody] Trophy updatedTrophy)
        {
            var oldTrophy = _trophyRepository.Trophy.FirstOrDefault(x => x.Id == id);

            if (oldTrophy == null)
            {
                return _trophyRepository.Trophy;
            }
            else
            {
                oldTrophy.Sportclub = updatedTrophy.Sportclub;
                oldTrophy.Trophyname = updatedTrophy.Trophyname;
                oldTrophy.Rank = updatedTrophy.Rank;
                oldTrophy.Year = updatedTrophy.Year;
                oldTrophy.Sponsors = updatedTrophy.Sponsors;

                return _trophyRepository.Trophy;
            }
        }

        // Three endpoints: from route, query and body
        [HttpGet("route/{sportclub}/{trophyname}")]
        public IActionResult GetTrophyFromRoute(string sportclub, string trophyname)
        {
            return Ok($"Sport Club {sportclub} won this year's {trophyname} Trophy :: from route");
        }
        
        [HttpGet("query")]
        public IActionResult GetTrophyFromQuery([FromQuery] string sportclub, [FromQuery] string trophyname)
        {
            return Ok($"Sport Club {sportclub} won this year's {trophyname} Trophy :: from query");
        }
        
        [HttpPost("body")]
        public IActionResult GetTrophyFromBody([FromBody] string trophyname)
        {
            return Ok($"Hello from {trophyname} Trophy!");
        }
    }
}
