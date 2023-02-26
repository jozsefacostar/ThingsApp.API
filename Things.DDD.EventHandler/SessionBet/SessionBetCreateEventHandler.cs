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
using Things.DDD.EventHandler.Commands.Game.Validators;
using Things.DDD.EventHandler.SessionBet.Commands.Validators;
using Things.DDD.Infrastructure;

namespace Things.DDD.EventHandler.SessionBet
{
    public class SessionBetCreateEventHandler :
        IRequestHandler<SessionBetCreateCommand, PetitionResponse>
    {
        private readonly Context _context;
        private SessionBetValidators _sessionBetValidators;

        /* Constructor */
        public SessionBetCreateEventHandler(Context context)
        {
            _context = context;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(SessionBetCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _sessionBetValidators = new SessionBetValidators(_context);
                if (!await _sessionBetValidators.CanCreateSessionBet(command.Game))
                    return new PetitionResponse { success = false, message = _sessionBetValidators.Message, module = "SessionBet" };
                if (!await _sessionBetValidators.CodeBetExist(command.Name))
                    return new PetitionResponse { success = false, message = _sessionBetValidators.Message, module = "SessionBet" };
                var codeGenerated = Guid.NewGuid().ToString();
                await _context.AddAsync(new Things.DDD.Domain.Entities.SessionBet() { ID = Guid.NewGuid(), Name = command.Name, Game = command.Game, Code = codeGenerated, Inactive = false, CreatedAt = DateTime.Now, CreatedBy = "MANAGER" });
                await _context.SaveChangesAsync();
                return new PetitionResponse { success = true, message = "Sesión creada con éxito", module = "SessionBet", result = codeGenerated };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible crear sesión: " + ex.Message, module = "SessionBet" };
            }
        }
    }
}
