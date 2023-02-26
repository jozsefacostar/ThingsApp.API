using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Infrastructure;
using Things.DDD.Domain.Entities;

namespace Things.DDD.EventHandler.SessionBet.Commands.Validators
{
    public class SessionBetValidators
    {
        private readonly Context _context;
        public string Message { get; set; }
        public SessionBetValidators(Context context)
        {
            _context = context;
        }

        /* Función que permite validar si es partido seleccionado aún no ha finalizado */
        public async Task<bool> CanCreateSessionBet(Guid game)
        {
            var gamee = await _context.Games.Where(x => x.ID.Equals(game)).FirstOrDefaultAsync();
            if (gamee != null && gamee.Finalized)
            {
                Message = "El partido seleccionado ya finalizó.";
                return false;
            }
            return true;
        }
        /* Función que permite validar si el nombre de apuesta ya existe o no */
        public async Task<bool> CodeBetExist(string name)
        {
            var gamee = await _context.SessionBets.Where(x => x.Name.Equals(name.Trim())).FirstOrDefaultAsync();
            if (gamee != null)
            {
                Message = "Ya existe una sesión con el nombre de apuesta indicado.";
                return false;
            }
            return true;
        }
    }
}
