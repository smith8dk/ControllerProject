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
                new Names { Id = 1, FirstName = "Dakota", LastName = "Smith" },
                new Names { Id = 2, FirstName = "John", LastName = "Newman" },
                new Names { Id = 3, FirstName = "Bob", LastName = "Davis" });
        }
        public DbSet<Names> Names { get; set; }

    }
}