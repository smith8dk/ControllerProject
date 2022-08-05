using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.Models
{
    public class UCMajors
    {
        public int Id { get; set; }

        public string MajorName { get; set; }

        public int PopularityRank { get; set; }

        public int AnnualGraduates { get; set; }

        public decimal AverageSalary { get; set; }      
    }
}
