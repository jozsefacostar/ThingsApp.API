using System;
using System.Collections.Generic;
using MediatR;
using Service.Common.Response;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Things.History.DDD.EventHandler.GameHistory.Commands;
using Things.History.DDD.Infrastructure;

namespace Things.History.DDD.EventHandler.GameHistory
{
    public class GameHistoryCreateEventHandler :
        IRequestHandler<GameHistoryCreateCommand, PetitionResponse>
    {
        private readonly ContextHistory _context;

        /* Constructor */
        public GameHistoryCreateEventHandler(ContextHistory context)
        {
            _context = context;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(GameHistoryCreateCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                await _context.AddAsync(new Things.History.DDD.Domain.Entities.GameHistory() { ID = Guid.NewGuid(), TeamA = notification.TeamA, TeamB = notification.TeamB, GoalsA = 0, GoalsB = 0, Inactive = false, CreatedAt = DateTime.Now, CreatedBy = "MANAGER", DateInitial = notification.DateInitial, DateFinal = notification.DateInitial.AddHours(2) });
                await _context.SaveChangesAsync();

                return new PetitionResponse { success = true, message = "Historico de Partido creado con éxito", module = "GamesHistory" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible crear partido: " + ex.Message, module = "GamesHistory" };
            }
        }
    }
}
