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
    public class WondersController : Controller
    {
        private readonly ILogger<WondersController> _logger;

        private readonly IWonderContextDAO _context;

        public WondersController(ILogger<WondersController> logger, IWonderContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllWonders());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var wonder = _context.GetWonder(id);
            if (wonder == null)
            {
                return NotFound(id);
            }
            return Ok(wonder);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveWonder(id);

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
        public IActionResult Put(Wonders wonder)
        {
            var result = _context.UpdateWonder(wonder);

            if (result == null)
            {
                return NotFound(wonder.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while proccessing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Wonders wonder)
        {
            var result = _context.Add(wonder);
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
