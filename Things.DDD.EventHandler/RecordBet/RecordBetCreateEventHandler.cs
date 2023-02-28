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

        /* Constructor */
        public RecordBetCreateEventHandler(Context context)
        {
            _context = context;
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

                await _context.AddAsync(new Things.DDD.Domain.Entities.RecordBet() { ID = Guid.NewGuid(), SessionBet = command.SessionBet, User = command.User, GoalsA = command.GoalsA, GoalsB = command.GoalsB, Inactive = false, CreatedAt = DateTime.Now, CreatedBy = "MANAGER" });
                await _context.SaveChangesAsync();
                return new PetitionResponse { success = true, message = "Apuesta creada con éxito", module = "RecordBet" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible crear apuesta: " + ex.Message, module = "RecordBet" };
            }
        }
    }
}
