using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.Infrastructure.Services
{
    public class SessionBetRepository : IReadSessionBetRepository
    {
        #region Variables
        private readonly Context _context;
        #endregion

        #region Ctor
        public SessionBetRepository(Context context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /* Función que permite consultar todos los equipos */
        public async Task<dynamic> GetSessionBetByCode(string code)
        {
            return await _context.SessionBets
                 .Include(x => x.GameNavigation)
                 .Include(x => x.GameNavigation)
                     .ThenInclude(x => x.TeamANavigation)
                 .Include(x => x.GameNavigation)
                     .ThenInclude(x => x.TeamBNavigation)
                 .Where(x => x.Code.Equals(code))
                 .Select(x => new
                 {
                     SessionBet = x.ID,
                     TeamA = x.GameNavigation.TeamANavigation.Description,
                     TeamB = x.GameNavigation.TeamBNavigation.Description,
                     Game = x.Game,
                     DateInitial = x.GameNavigation.DateInitial,
                     DateFinal = x.GameNavigation.DateFinal
                 }).FirstOrDefaultAsync();
        }
        #endregion
    }
}
