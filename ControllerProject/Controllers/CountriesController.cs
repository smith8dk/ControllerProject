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
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;

        private readonly ICountryContextDAO _context;

        public CountriesController(ILogger<CountriesController> logger, ICountryContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllCountries());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var country = _context.GetCountry(id);
            if (country == null)
            {
                return NotFound(id);
            }
            return Ok(country);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveCountry(id);

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
        public IActionResult Put(Countries country)
        {
            var result = _context.UpdateCountry(country);

            if (result == null)
            {
                return NotFound(country.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while proccessing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Countries country)
        {
            var result = _context.Add(country);
            if (result == null)
            {
                return (StatusCode(500, "Country already exist"));
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
