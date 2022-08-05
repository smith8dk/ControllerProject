using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{
    public class Countries
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public string Capital { get; set; }

        public string Continent { get; set; }

        public int Population  { get; set; }
    }
}
