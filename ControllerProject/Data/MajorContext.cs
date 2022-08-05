using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControllerProject.Models;

namespace ControllerProject.Data
{
    public class MajorContext : DbContext
    {
        public MajorContext(DbContextOptions<MajorContext> options) : base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UCMajors>().HasData(
                new UCMajors { Id = 1, MajorName = "Psychology", PopularityRank = 3, AnnualGraduates = 274, AverageSalary = 55831m },
                new UCMajors { Id = 2, MajorName = "Accounting", PopularityRank = 10, AnnualGraduates = 179, AverageSalary = 51812m },
                new UCMajors { Id = 3, MajorName = "Marketing", PopularityRank = 1, AnnualGraduates = 434, AverageSalary = 40256m });
        }
        public DbSet<UCMajors> Majors { get; set; }

    }
}
