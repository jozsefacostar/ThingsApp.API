using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Things.DDD.API.Queries;
using Things.DDD.Domain.Repositories;
using Things.DDD.EventHandler.Games;
using Things.DDD.Infrastructure;
using Things.DDD.Infrastructure.Services;

namespace Things.DDD.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Things.DDD.API", Version = "v1" });
            });
            /* Inyecci�n de ApplicationDbContext */
            services.AddDbContext<Context>(
              opts => opts.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            /* Inyecci�n de MediaTr */
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(GameCreateEventHandler).Assembly); });
            /* Inyecci�n de funcionalidads de Equipos */
            services.AddScoped<IReadTeamRepository, TeamRepository>();
            services.AddScoped<TeamQueries>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Things.DDD.API v1"));
            }

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
