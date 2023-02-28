using MediatR;
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
using Things.DDD.Infrastructure;

namespace Things.DDD.EventHandler.Games
{
    public class ScoresChangeEventHandler :
        IRequestHandler<ScoresChangeCommand, PetitionResponse>
    {
        private readonly Context _context;
        private GameValidators _gameValidator;

        /* Constructor */
        public ScoresChangeEventHandler(Context context)
        {
            _context = context;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(ScoresChangeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _gameValidator = new GameValidators(_context);
                Game game = await _gameValidator.GetGame(command.ID);
                if (game == null)
                    return new PetitionResponse { success = false, message = "Partido indicado no existe", module = "Games" };

                if (game.DateFinal < DateTime.Now)
                    return new PetitionResponse { success = false, message = "El partido ya finalizo y no se pueden modificar marcadores", module = "Games" };

                game.ModifyDate = DateTime.Now;
                game.ModifiedBy = "MANAGER";
                game.GoalsA = command.GoalsA;
                game.GoalsB = command.GoalsB;
                game.Finalized = command.Finalized;
                _context.Entry(game).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new PetitionResponse { success = true, message = "Marcadores modificados con éxito", module = "Games" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible modificar marcadores: " + ex.Message, module = "Games" };
            }
        }
    }
}
