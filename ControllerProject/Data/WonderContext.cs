using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControllerProject.Models;

namespace ControllerProject.Data
{
    public class WonderContext : DbContext
    {
        public WonderContext(DbContextOptions<WonderContext> options) : base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Wonders>().HasData(
                new Wonders { Id = 1, Name = "Machu Picchu", Location = "Peru", TouristPerYear= 1200000, YearCreated = "1450AD" },
                new Wonders { Id = 2, Name = "Great Pyramid of Giza", Location = "Egypt", TouristPerYear = 14700000, YearCreated = "2550BC" },
                new Wonders { Id = 3, Name = "Effiel Tower", Location = "France", TouristPerYear = 7000000, YearCreated = "1887AD" });
        }
        public DbSet<Wonders> Wonders { get; set; }

    }
}