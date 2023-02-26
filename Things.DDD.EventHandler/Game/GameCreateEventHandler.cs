using MediatR;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;
using Things.DDD.EventHandler.Commands.Game;
using Things.DDD.Infrastructure;

namespace Things.DDD.EventHandler.Games
{
    public class GameCreateEventHandler :
        IRequestHandler<GameCreateCommand, PetitionResponse>
    {
        private readonly Context _context;

        /* Constructor */
        public GameCreateEventHandler(Context context)
        {
            _context = context;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(GameCreateCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                await _context.AddAsync(new Game() { ID = Guid.NewGuid(), TeamA = notification.TeamA, TeamB = notification.TeamB, GoalsA = 0, GoalsB = 0, CreatedAt = DateTime.Now, CreatedBy = "MANAGER", DateGame = notification.GameDate });
                await _context.SaveChangesAsync();
                return new PetitionResponse { success = true, message = "Partido creado con éxito", module = "Game" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "Excepcion: " + ex.Message, module = "Games" };
            }
        }
    }
}
