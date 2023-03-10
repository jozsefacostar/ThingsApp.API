using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.Infrastructure.Services
{
    public class RecordBetRepository : IReadRecordBetRepository
    {
        #region Variables
        private readonly Context _context;
        #endregion

        #region Ctor
        public RecordBetRepository(Context context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /* Función que permite consultar todos las apuestas de un usuario */
        public async Task<dynamic> GetRecordsByUser(string User)
        {
            return await _context.RecordBets
                .Where(x => x.User.Equals(Guid.Parse(User)))
                 .Include(x => x.UserNavigation)
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamANavigation)
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamBNavigation)
                 .Select(x => new
                 {
                     RecordBets = x.ID,
                     SessionBet = x.SessionBet,
                     GoalsA = x.GoalsA,
                     Loggued = x.UserNavigation.Loggued,
                     GoalsB = x.GoalsB,
                     TeamA = x.SessionBetNavigation.GameNavigation.TeamANavigation.Description,
                     TeamB = x.SessionBetNavigation.GameNavigation.TeamBNavigation.Description,
                     DateInitial = x.SessionBetNavigation.GameNavigation.DateInitial,
                     DateFinal = x.SessionBetNavigation.GameNavigation.DateFinal,
                     Finalized = x.SessionBetNavigation.GameNavigation.Finalized,
                     StatusGame = x.SessionBetNavigation.GameNavigation.Finalized ? "0" : x.SessionBetNavigation.GameNavigation.DateInitial < DateTime.Now && x.SessionBetNavigation.GameNavigation.DateFinal > DateTime.Now ? "1" : x.SessionBetNavigation.GameNavigation.DateInitial > DateTime.Now ? "2" : "3",
                     myScore = "(" + x.GoalsA + ") - (" + x.GoalsB + ")",
                     realScore = "(" + x.SessionBetNavigation.GameNavigation.GoalsA + ") - (" + x.SessionBetNavigation.GameNavigation.GoalsB + ")"
                 })
                 .OrderByDescending(x => x.DateFinal)
                 .ToListAsync();
        }

        /* Función que permite consultar todos los apuestas de un usuario y sesiones */
        public async Task<dynamic> GetRecordsByUserAndSession(string User)
        {
            var SessionBetIDs = await _context.RecordBets
                .Where(x => x.User.Equals(Guid.Parse(User))).Select(x => x.SessionBet).ToListAsync();
            if (SessionBetIDs != null && SessionBetIDs.Count > 0)
            {
                return await _context.RecordBets
                .Where(x => SessionBetIDs.Contains(x.SessionBet))
                 .Include(x => x.UserNavigation)
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamANavigation)
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamBNavigation)
                 .Select(x => new
                 {
                     RecordBets = x.ID,
                     Name = x.UserNavigation.Name,
                     SessionBet = x.SessionBet,
                     GoalsA = x.GoalsA,
                     Loggued = x.UserNavigation.Loggued,
                     GoalsB = x.GoalsB,
                     TeamA = x.SessionBetNavigation.GameNavigation.TeamANavigation.Description,
                     TeamB = x.SessionBetNavigation.GameNavigation.TeamBNavigation.Description,
                     DateInitial = x.SessionBetNavigation.GameNavigation.DateInitial,
                     DateFinal = x.SessionBetNavigation.GameNavigation.DateFinal,
                     Finalized = x.SessionBetNavigation.GameNavigation.Finalized,
                     StatusGame = x.SessionBetNavigation.GameNavigation.Finalized ? "0" : x.SessionBetNavigation.GameNavigation.DateInitial < DateTime.Now && x.SessionBetNavigation.GameNavigation.DateFinal > DateTime.Now ? "1" : x.SessionBetNavigation.GameNavigation.DateInitial > DateTime.Now ? "2" : "3",
                     StatusGameDesc = x.SessionBetNavigation.GameNavigation.Finalized ? "¡Partido Finalizado!" : x.SessionBetNavigation.GameNavigation.DateInitial < DateTime.Now && x.SessionBetNavigation.GameNavigation.DateFinal > DateTime.Now ? "¡Partido en curso!" : x.SessionBetNavigation.GameNavigation.DateInitial > DateTime.Now ? "Pendiente por jugar" : "Triunfo",
                     myScore = "(" + x.GoalsA + ") - (" + x.GoalsB + ")",
                     realScore = "(" + x.SessionBetNavigation.GameNavigation.GoalsA + ") - (" + x.SessionBetNavigation.GameNavigation.GoalsB + ")"
                 })
                 .OrderByDescending(x => x.DateFinal)
                 .ToListAsync();
            }
            return null;
        }

        /* Función que permite consultar todos los equipos */
        public async Task<dynamic> GetRecordsBySession(string SessionBet)
        {
            return await _context.RecordBets
                .Where(x => x.SessionBet.Equals(Guid.Parse(SessionBet)))
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamANavigation)
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamBNavigation)
                 .Include(x => x.SessionBetNavigation)
                 .Include(x => x.UserNavigation)
                 .Select(x => new
                 {
                     RecordBets = x.ID,
                     SessionBet = x.SessionBet,
                     GoalsA = x.GoalsA,
                     GoalsB = x.GoalsB,
                     TeamA = x.SessionBetNavigation.GameNavigation.TeamANavigation.Description,
                     TeamB = x.SessionBetNavigation.GameNavigation.TeamBNavigation.Description,
                     DateInitial = x.SessionBetNavigation.GameNavigation.DateInitial,
                     DateFinal = x.SessionBetNavigation.GameNavigation.DateFinal,
                     Finalized = x.SessionBetNavigation.GameNavigation.Finalized,
                     myScore = "(" + x.GoalsA + ") - (" + x.GoalsB + ")",
                     realScore = "(" + x.SessionBetNavigation.GameNavigation.GoalsA + ") - (" + x.SessionBetNavigation.GameNavigation.GoalsB + ")",
                     Loggued = x.UserNavigation.Loggued,
                     NameUser = x.UserNavigation.Name
                 })
                .ToListAsync();
        }
        #endregion
    }
}
