using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Infrastructure;
using Things.DDD.Domain.Entities;

namespace Things.DDD.EventHandler.RecordBet.Commands.Validators
{
    public class RecordBetValidator
    {
        private readonly Context _context;
        public string Message { get; set; }
        public RecordBetValidator(Context context)
        {
            _context = context;
        }

        /* Función que permite validar se puede apostar al partido indicado */
        public async Task<bool> CanCreateRecordBet(Guid game)
        {
            var DateNow = DateTime.Now;
            var gameee = await _context.Games.Where(x => x.ID.Equals(game)).FirstOrDefaultAsync();
            if (gameee != null)
            {
                var initalDateLess5Min = gameee.DateInitial.AddMinutes(-5);
                if (DateNow >= initalDateLess5Min && DateNow <= gameee.DateInitial)
                    return true;
            }
            Message = "Puede apostar sólo 5 minutos antes del partido";
            return false;
        }
        /* Función que permite validar se puede actualizar un partido ya existente */
        public async Task<bool> CanUpdateRecordBet(Guid RecordBet)
        {
            var DateNow = DateTime.Now;
            var gameee = await _context.RecordBets
                .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                .Where(x => x.ID.Equals(RecordBet)).FirstOrDefaultAsync();
            if (gameee != null)
            {
                var initalDateMore1Min = gameee.SessionBetNavigation.GameNavigation.DateInitial.AddMinutes(1);
                if (DateNow >= initalDateMore1Min)
                {
                    Message = "Sólo es posible actualizar la apuesta 1 minuto despues de apostar";
                    return false;
                }
            }
            return true;
        }
    }
}
