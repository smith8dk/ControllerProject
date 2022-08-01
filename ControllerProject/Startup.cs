using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ControllerProject.Data;
using ControllerProject.Models;
using ControllerProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ControllerProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocument();
            var connStr = "Server=(localdb)\\mssqllocaldb;Database=NamesContext;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<NamesContext>(Options => Options.UseSqlServer(connStr));
            //System.Console.WriteLine(connStr);
            //services.AddDbContext<DbContext>(options => options.UseSqlServer(connStr));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//, NamesContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //context.Database.Migrate();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
