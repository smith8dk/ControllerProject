using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{
    public class Wonders
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int TouristPerYear{ get; set; }

        public string YearCreated { get; set; }
    }
}
