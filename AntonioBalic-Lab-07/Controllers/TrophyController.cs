using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AntonioBalic_Lab_07.Repositories;
using AntonioBalic_Lab_07.Models;
using AntonioBalic_Lab_07.Logic;
using AntonioBalic_Lab_07.Filters;
using AntonioBalic_Lab_07.DTO;

namespace AntonioBalic_Lab_07.Controllers
{
    //[ErrorFilter]
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
        public IEnumerable<TrophyDTO> GetTrophies()
        {
            var trophyList = _trophyLogic.GetTrophies();

            return trophyList.Select(x => TrophyDTO.FromModel(x));
        }

        [HttpPost("new")]
        public IEnumerable<TrophyDTO> AddNewTrophy([FromBody] NewTrophyRequestDTO trophy)
        {
            Trophy model = trophy.ToModel();
            var trophyList = _trophyLogic.AddTrophy(model);

            return trophyList.Select(x => TrophyDTO.FromModel(x));
        }

        [HttpDelete("delete/{id}")]
        public IEnumerable<TrophyDTO> DeleteTrophy([FromRoute] long id)
        {
            var trophyList = _trophyLogic.DeleteTrophy(id);

            return trophyList.Select(x => TrophyDTO.FromModel(x));
        }

        [HttpPut("update/{id}")]
        public IEnumerable<TrophyDTO> EditTrophy([FromRoute] long id, [FromBody] NewTrophyRequestDTO updatedTrophy)
        {
            Trophy model = updatedTrophy.ToModel();
            var trophyList = _trophyLogic.UpdateTrophy(id, model);

            return trophyList.Select(x => TrophyDTO.FromModel(x));
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
