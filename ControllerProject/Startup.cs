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
using ControllerProject.Interfaces;

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
            services.AddScoped<INameContextDAO, NamesContextDAO>();
            services.AddScoped<ICountryContextDAO, CountryContextDAO>();
            services.AddScoped<IMajorContextDAO, MajorContextDAO>();
            services.AddScoped<IWonderContextDAO, WonderContextDAO>();
            services.AddControllers();
            services.AddSwaggerDocument();
            var connStr1 = "Server=(localdb)\\mssqllocaldb;Database=FullNameContext;Trusted_Connection=True;MultipleActiveResultSets=true";
            var connStr2 = "Server=(localdb)\\mssqllocaldb;Database=UCMajorContext;Trusted_Connection=True;MultipleActiveResultSets=true";
            var connStr3 = "Server=(localdb)\\mssqllocaldb;Database=CountryContext;Trusted_Connection=True;MultipleActiveResultSets=true";
            var connStr4 = "Server=(localdb)\\mssqllocaldb;Database=WonderContext;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<NamesContext>(Options => Options.UseSqlServer(connStr1));
            services.AddDbContext<MajorContext>(Options => Options.UseSqlServer(connStr2));
            services.AddDbContext<CountryContext>(Options => Options.UseSqlServer(connStr3));
            services.AddDbContext<WonderContext>(Options => Options.UseSqlServer(connStr4));
            //System.Console.WriteLine(connStr);
            //services.AddDbContext<DbContext>(options => options.UseSqlServer(connStr));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NamesContext context, MajorContext context1, CountryContext context2, WonderContext context3)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.Database.Migrate();

            context1.Database.Migrate();

            context2.Database.Migrate();

            context3.Database.Migrate();

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
