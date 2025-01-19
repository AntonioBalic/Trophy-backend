using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioBalic_Lab_07.Repositories;
using AntonioBalic_Lab_07.Models;
using AntonioBalic_Lab_07.Logic;
using AntonioBalic_Lab_07.Filters;

namespace AntonioBalic_Lab_07.Controllers
{
    [ErrorFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class TrophyController : ControllerBase
    {      
        private ITrophyLogic _trophyLogic;

        public TrophyController(ITrophyLogic trophyLogic)
        {
            _trophyLogic = trophyLogic;
        }

        [HttpGet("all")]
        public IEnumerable<Trophy> GetTrophies()
        {
            return _trophyLogic.GetTrophies();
        }

        [HttpPost("new")]
        public IEnumerable<Trophy> AddNewTrophy([FromBody] Trophy trophy)
        {
            return _trophyLogic.AddTrophy(trophy);
        }

        [HttpDelete("delete/{id}")]
        public IEnumerable<Trophy> DeleteTrophy([FromRoute] long id)
        {
            return _trophyLogic.DeleteTrophy(id);
        }

        [HttpPut("update/{id}")]
        public IEnumerable<Trophy> UpdateTrophy([FromRoute] long id, [FromBody] Trophy updatedTrophy)
        {
            return _trophyLogic.UpdateTrophy(id, updatedTrophy);
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
