using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;
using Things.DDD.EventHandler.Commands.Game;
using Things.DDD.EventHandler.Games;
using Things.DDD.Infrastructure;

namespace Things.DDD.API.HostedService
{
    public class IntervalTaskHostedService : IHostedService, IDisposable
    {
        #region Varibles
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;
        #endregion

        #region Constructor
        public IntervalTaskHostedService(IServiceScopeFactory scopeFactory, Context context)
        {
            //_scopeFactory = scopeFactory;
        }
        #endregion

        #region Methods
        /* Evento que se ejecutará en 2do plano cada 10 segundos para actualizar estado del partido */
        public void UpdateStatusGames(object state)
        {
            //using var scope = _scopeFactory.CreateScope();
            //var context = scope.ServiceProvider
            //    .GetRequiredService<Context>();

            //List<Game> LstIQuerable = context.Games.Where(x => !x.Finalized && x.DateFinal < DateTime.Now).AsQueryable().ToList();
            //foreach (var drGame in LstIQuerable)
            //{
            //    drGame.Finalized = true;
            //    context.Entry(drGame).State = EntityState.Modified;
            //    context.SaveChangesAsync();
            //}
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateStatusGames, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
        #endregion


    }
}
