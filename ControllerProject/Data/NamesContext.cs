using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControllerProject.Models;

namespace ControllerProject.Data
{
    public class NamesContext : DbContext
    {
        public NamesContext(DbContextOptions<NamesContext> options) : base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Names>().HasData(
                new Names { Id = 1, FullName = "Dakota Smith", Birthdate = new DateTime(2002, 09, 26), CollegeProgram = "IT", Year = "Sophmore" },
                new Names { Id = 2, FullName = "Jack Newman", Birthdate = new DateTime(2003, 02, 02), CollegeProgram = "Computer Science", Year = "Freshman" },
                new Names { Id = 3, FullName = "Bob Davis", Birthdate = new DateTime(2000, 11, 21), CollegeProgram = "Art", Year = "Senior" });
        }
        public DbSet<Names> Names { get; set; }

    }
}