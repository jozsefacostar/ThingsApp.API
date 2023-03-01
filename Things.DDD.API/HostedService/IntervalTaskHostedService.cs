using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Things.DDD.Infrastructure;

namespace Things.DDD.API.HostedService
{
    public class IntervalTaskHostedService : IHostedService, IDisposable
    {
        #region Variables
        private readonly IServiceScopeFactory scopeFactory;
        private Timer _timer;
        #endregion

        #region Ctor
        public IntervalTaskHostedService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        #endregion

        #region Functions
        /* Función que se ejecuta cada 10 segundos para modificar el estado de los partidos finalizados */
        public void DoWork(object state)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
                var games = dbContext.Games.Where(x => x.Finalized == false).ToList();
                foreach (var drGame in games)
                {
                    if (drGame.DateFinal < DateTime.Now)
                    {
                        drGame.Finalized = true;
                        dbContext.Entry(drGame).State = EntityState.Modified;
                        dbContext.SaveChangesAsync();
                    }
                }
            }
        }
        /* Implementación del Start Async */
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }
        /* Implementación del Stop Async */
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        /* Dispose */
        public void Dispose()
        {
            _timer?.Dispose();
        }
        #endregion
    }
}