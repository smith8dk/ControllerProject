using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControllerProject.Models;

namespace ControllerProject.Data
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Countries>().HasData(
                new Countries { Id = 1, CountryName = "Nepal", Capital = "Kathmandu", Continent = "Asia", Population = 29136808 },
                new Countries { Id = 2, CountryName = "Slovakia", Capital = "Bratislava", Continent = "Europe", Population = 5459642 },
                new Countries { Id = 3, CountryName = "Tanzania", Capital = "Dodoma", Continent = "Africa", Population = 59734218 });
        }
        public DbSet<Countries> Countries { get; set; }

    }
}