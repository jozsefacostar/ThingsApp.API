using Hangfire;
using Hangfire.SqlServer;
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
using Things.DDD.API.Extension;
using Things.DDD.API.HubConfig;
using Things.DDD.API.Queries;
using Things.DDD.API.TimerFeatures;
using Things.DDD.Domain.Repositories;
using Things.DDD.EventHandler.Games;
using Things.DDD.EventHandler.HubConfig;
using Things.DDD.EventHandler.RecordBet;
using Things.DDD.EventHandler.SessionBet;
using Things.DDD.EventHandler.User;
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
            /* Configuración de HangFire */
            services.ConfigureHangFire(Configuration);

            /* Inyectamos los CORS */
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder => builder
                 .WithOrigins("http://localhost:4200")
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());
            });
            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Things.DDD.API", Version = "v1" });
            });
            /* Inyección de ApplicationDbContext */
            services.AddDbContext<Context>(
              opts => opts.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            /* Inyección de MediaTr */
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(GameCreateEventHandler).Assembly); });
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(ScoresChangeEventHandler).Assembly); });
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(SessionBetCreateEventHandler).Assembly); });
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(RecordBetCreateEventHandler).Assembly); });
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(UserLoginEventHandler).Assembly); });
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(UserLogoutEventHandler).Assembly); });

            /* Inyección de dependencias de servicios e interfaces */
            services.AddScoped<IReadTeamRepository, TeamRepository>();
            services.AddScoped<IReadGameRepository, GameRepository>();
            services.AddScoped<IReadSessionBetRepository, SessionBetRepository>();
            services.AddScoped<IReadRecordBetRepository, RecordBetRepository>();
            services.AddScoped<TeamQueries>();
            services.AddScoped<GameQueries>();
            services.AddScoped<SessionBetQueries>();
            services.AddScoped<RecordBetQueries>();

            /* Inyección de SignalR */
            services.AddSingleton<TimerManager>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Things.DDD.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
                endpoints.MapHub<ChartHub>("/chart");
                endpoints.MapHub<AddGameHub>("/gameAdds");
            });

            app.UseHangfireDashboard();

            /* Implementamos el Midleware Firebase */
            backgroundJobClient.Enqueue(() => Console.WriteLine("Hello"));
            var scheduleGamesFinalized = serviceProvider.GetRequiredService<GameQueries>();
            recurringJobManager.AddOrUpdate("Actualizar partidos finalizados", () => scheduleGamesFinalized.FinalizedGames(), Cron.Minutely);

        }
    }
}
