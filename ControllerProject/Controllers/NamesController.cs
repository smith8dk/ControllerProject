using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ControllerProject.Data;
using ControllerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        private readonly ILogger<NamesController> _logger;

        private readonly NamesContext _context;

        public NamesController(ILogger<NamesController> logger, NamesContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Names.ToList());
        }
    }
}
