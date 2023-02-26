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
        public async Task<Guid> GetSessionBetByCode(string code)
        {
            var sessionBet = (await _context.SessionBets.Where(x => x.Code.Equals(code)).FirstOrDefaultAsync());
            if (sessionBet != null)
                return sessionBet.ID;
            return Guid.Empty;
        }
        #endregion
    }
}
