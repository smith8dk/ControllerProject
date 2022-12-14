using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ControllerProject.Data;
using System.Linq;
using ControllerProject.Interfaces;
using ControllerProject.Models;

namespace ControllerProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        private readonly ILogger<NamesController> _logger;

        private readonly INameContextDAO _context;

        public NamesController(ILogger<NamesController> logger, INameContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllTeams());
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var team = _context.GetTeam(id);
            if (team == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(team);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveTeam(id);

            if (result == null)
            {
                return NotFound(id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while proccessing your request");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Names name)
        {
            var result = _context.UpdateName(name);

            if (result == null)
            {
                return NotFound(name.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while proccessing your request");
            }
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Post(Names name)
        {
            var result = _context.Add(name);
            if (result == null)
            {
                return (StatusCode(500, "Name already exist"));
            }
            else if (result == 0)
            {
                return (StatusCode(500, "An error occured while proccesing your request"));
            }
            else
            {
                return Ok();
            }

        }
    }
}
