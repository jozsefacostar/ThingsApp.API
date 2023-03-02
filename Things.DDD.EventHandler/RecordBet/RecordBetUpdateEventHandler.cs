using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Service.Common.Response;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Things.DDD.EventHandler.HubConfig;
using Things.DDD.EventHandler.RecordBet.Commands;
using Things.DDD.EventHandler.RecordBet.Commands.Validators;
using Things.DDD.Infrastructure;

namespace Things.DDD.EventHandler.RecordBet
{
    public class RecordBetUpdateEventHandler :
        IRequestHandler<RecordBetUpdateCommand, PetitionResponse>
    {
        private readonly Context _context;
        private RecordBetValidator _RecordBetValidator;
        private readonly IHubContext<RecordUpdateScoresGameHub> _hub;

        /* Constructor */
        public RecordBetUpdateEventHandler(Context context, IHubContext<RecordUpdateScoresGameHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(RecordBetUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _RecordBetValidator = new RecordBetValidator(_context);
                if (!await _RecordBetValidator.CanUpdateRecordBet(command.RecordBet))
                    return new PetitionResponse { success = false, message = _RecordBetValidator.Message, module = "RecordBet" };

                Things.DDD.Domain.Entities.RecordBet _RecordBet = await _context.RecordBets
                    .Where(x => x.ID.Equals(command.RecordBet))
                    .Include(x => x.UserNavigation)
                    .Include(x => x.SessionBetNavigation)
                        .ThenInclude(x => x.GameNavigation)
                            .ThenInclude(x => x.TeamANavigation)
                    .Include(x => x.SessionBetNavigation)
                        .ThenInclude(x => x.GameNavigation)
                            .ThenInclude(x => x.TeamBNavigation)

                    .FirstOrDefaultAsync();

                if (_RecordBet == null)
                    return new PetitionResponse { success = false, message = "Apuesta indicada no existe", module = "RecordBet" };
                _RecordBet.GoalsA = command.GoalsA;
                _RecordBet.GoalsB = command.GoalsB;
                _context.Entry(_RecordBet).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var teamA = await _context.Users.Where(x => x.ID.Equals(command.RecordBet)).FirstOrDefaultAsync();
                var dateGame = _RecordBet.UserNavigation.Name +
                    " cambió su apuesta: (" + _RecordBet.SessionBetNavigation.GameNavigation.TeamANavigation.Description + "(" + command.GoalsA + ") - (" + command.GoalsB + ")" + _RecordBet.SessionBetNavigation.GameNavigation.TeamBNavigation.Description;
                await _hub.Clients.All.SendAsync("UpdateScoresByUser", dateGame);
                return new PetitionResponse { success = true, message = "Apuesta modificada con éxito", module = "RecordBet" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible modificar apuesta: " + ex.Message, module = "RecordBet" };
            }
        }
    }
}
