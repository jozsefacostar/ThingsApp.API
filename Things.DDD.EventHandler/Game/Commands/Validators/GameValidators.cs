using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Infrastructure;
using Things.DDD.Domain.Entities;

namespace Things.DDD.EventHandler.Commands.Game.Validators
{
    public class GameValidators
    {
        private readonly Context _context;
        public string Message { get; set; }
        public GameValidators(Context context)
        {
            _context = context;
        }

        /* Función que permite validar cruces entre fechas de equipos */
        public async Task<bool> ExistDateCrossing(Guid TeamA, Guid TeamB, DateTime DateGame)
        {
            if (DateGame <= DateTime.Now)
            {
                Message = "La fecha y hora del partido no puede ser menor a la actual";
                return false;
            }

            if (TeamA.Equals(TeamB))
            {
                Message = "No hay suficientes jugadores del mismo equipo para que se enfrenten entre si";
                return false;
            }
            var existProgramateA = await _context.Games.Where(x => (x.TeamA.Equals(TeamA) || x.TeamB.Equals(TeamA)) && (x.DateInitial <= DateGame && x.DateFinal >= DateGame)).FirstOrDefaultAsync();
            if (existProgramateA != null)
            {
                Message = "El equipo A, ya tiene una programación de partidos que se cruza con fecha indicada";
                return false;
            }
            var existProgramateB = await _context.Games.Where(x => (x.TeamA.Equals(TeamB) || x.TeamB.Equals(TeamB)) && (x.DateInitial <= DateGame && x.DateFinal >= DateGame)).FirstOrDefaultAsync();
            if (existProgramateB != null)
            {
                Message = "El equipo B, ya tiene una programación de partidos que se cruza con fecha indicada";
                return false;
            }
            return true;
        }

        /* Función que permite validar si el partido es del dia actual */
        public async Task<bool> IsTodayGame(DateTime DateGame)
        {
            if (DateGame.Date != DateTime.Now.Date)
            {
                Message = "Sólo es posible programar partidos con la fecha actual";
                return false;
            }
            return true;
        }

        /* Función que valida existencia de partido por ID */
        public async Task<Domain.Entities.Game> GetGame(Guid ID)
        {
            return await _context.Games.Where(x => x.ID.Equals(ID)).FirstOrDefaultAsync();
        }
    }
}
