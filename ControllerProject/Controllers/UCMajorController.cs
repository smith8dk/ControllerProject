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
    public class UCMajorController : ControllerBase
    {
        private readonly ILogger<UCMajorController> _logger;

        private readonly IMajorContextDAO _context;

        public UCMajorController(ILogger<UCMajorController> logger, IMajorContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllMajors());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var major = _context.GetMajor(id);
            if (major == null)
            {
                return NotFound(id);
            }
            return Ok(major);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveMajor(id);

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
        public IActionResult Put(UCMajors major)
        {
            var result = _context.UpdateMajor(major);

            if (result == null)
            {
                return NotFound(major.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while proccessing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(UCMajors major)
        {
            var result = _context.Add(major);
            if (result == null)
            {
                return (StatusCode(500, "Major already exist"));
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
