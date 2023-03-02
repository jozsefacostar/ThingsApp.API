using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;
using Things.DDD.EventHandler.Commands.Game;
using Things.DDD.EventHandler.Commands.Game.Validators;
using Things.DDD.EventHandler.HubConfig;
using Things.DDD.EventHandler.RecordBet.Commands;
using Things.DDD.EventHandler.RecordBet.Commands.Validators;
using Things.DDD.Infrastructure;

namespace Things.DDD.EventHandler.RecordBet
{
    public class RecordBetCreateEventHandler :
        IRequestHandler<RecordBetCreateCommand, PetitionResponse>
    {
        private readonly Context _context;
        private RecordBetValidator _RecordBetValidator;
        private readonly IHubContext<CreateRecordByUserHub> _hub;
        private readonly IHubContext<AllGamesSummary> _hub_AllGamesSummary;

        /* Constructor */
        public RecordBetCreateEventHandler(Context context, IHubContext<CreateRecordByUserHub> hub, IHubContext<AllGamesSummary> hub_AllGamesSummary)
        {
            _context = context;
            _hub = hub;
            _hub_AllGamesSummary = hub_AllGamesSummary;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(RecordBetCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _RecordBetValidator = new RecordBetValidator(_context);
                if (!await _RecordBetValidator.CanCreateRecordBet(command.Game))
                    return new PetitionResponse { success = false, message = _RecordBetValidator.Message, module = "RecordBet" };
                if (!await _RecordBetValidator.ValidateRepeatRecord(command))
                    return new PetitionResponse { success = false, message = _RecordBetValidator.Message, module = "RecordBet" };

                Things.DDD.Domain.Entities.SessionBet _RecordBet = await _context.SessionBets.Where(x => x.ID.Equals(command.SessionBet)).Include(x => x.GameNavigation).ThenInclude(x => x.TeamANavigation)
                 .Include(x => x.GameNavigation).ThenInclude(x => x.TeamBNavigation).FirstOrDefaultAsync();
                Things.DDD.Domain.Entities.User _User = await _context.Users.Where(x => x.ID.Equals(command.User)).FirstOrDefaultAsync();

                await _context.AddAsync(new Things.DDD.Domain.Entities.RecordBet() { ID = Guid.NewGuid(), SessionBet = command.SessionBet, User = command.User, GoalsA = command.GoalsA, GoalsB = command.GoalsB, Inactive = false, CreatedAt = DateTime.Now, CreatedBy = "MANAGER" });
                await _context.SaveChangesAsync();
                var dateGame = _User?.Name + " Hizo su apuesta: (" + _RecordBet?.GameNavigation?.TeamANavigation?.Description + "(" + command.GoalsA + ") - (" + command.GoalsB + ")" + _RecordBet?.GameNavigation?.TeamBNavigation?.Description;
                await _hub.Clients.All.SendAsync("createRecordBetByUser", dateGame);
                await _hub_AllGamesSummary.Clients.All.SendAsync("AllGamesSummary", dateGame);
                return new PetitionResponse { success = true, message = "Apuesta creada con éxito", module = "RecordBet" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible crear apuesta: " + ex.Message, module = "RecordBet" };
            }
        }
    }
}
