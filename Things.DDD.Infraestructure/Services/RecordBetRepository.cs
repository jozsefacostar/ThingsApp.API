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
        /* Función que permite consultar todos los equipos */
        public async Task<dynamic> GetRecordsByUser(string User)
        {
            return await _context.RecordBets
                .Where(x=>x.User.Equals(Guid.Parse(User)))
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamANavigation)
                 .Include(x => x.SessionBetNavigation)
                    .ThenInclude(x => x.GameNavigation)
                        .ThenInclude(x => x.TeamBNavigation)
                 .Select(x => new
                 {
                     RecordBets = x.ID,
                     GoalsA = x.GoalsA,
                     GoalsB = x.GoalsB,
                     TeamA = x.SessionBetNavigation.GameNavigation.TeamANavigation.Description,
                     TeamB = x.SessionBetNavigation.GameNavigation.TeamBNavigation.Description,
                     DateInitial = x.SessionBetNavigation.GameNavigation.DateInitial,
                     DateFinal = x.SessionBetNavigation.GameNavigation.DateFinal,
                     Finalized = x.SessionBetNavigation.GameNavigation.Finalized,
                     myScore = "(" + x.GoalsA + ") - (" + x.GoalsB + ")",
                     realScore = "(" + x.SessionBetNavigation.GameNavigation.GoalsA + ") - (" + x.SessionBetNavigation.GameNavigation.GoalsB + ")"
                 }).ToListAsync();
        }
        #endregion
    }
}
