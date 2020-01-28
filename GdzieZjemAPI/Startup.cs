using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GdzieZjemAPI
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
            services.AddDbContext<ApiContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("ApiDBConnection")));
            services.AddTransient<IGenericRepository<City>, GenericRepository<City>>();
            services.AddTransient<IGenericRepository<Dish>, GenericRepository<Dish>>();
            services.AddTransient<IGenericRepository<Kitchen>, GenericRepository<Kitchen>>();
            services.AddTransient<IGenericRepository<Restaurant>, GenericRepository<Restaurant>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}