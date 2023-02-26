
using Microsoft.EntityFrameworkCore;
using Service.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Entities;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.Infrastructure.Services
{
    public class GameRepository : IReadGameRepository
    {
        #region Variables
        private readonly Context _context;
        #endregion

        #region Ctor
        public GameRepository(Context context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /* Función que permite consultar todos los partidos que no han finalizado y están pendientes por jugar */
        public async Task<List<GameDTO>> GetAllByStatus(bool Finalized)
        {
            return (await _context.Games.Where(x=> x.Finalized == Finalized).ToListAsync()).MapTo<List<GameDTO>>();
        }
        /* Función que permite consultar un partido por ID */
        public async Task<GameDTO> GetByID(Guid id)
        {
            return (await _context.Games.Where(x => x.ID == id).FirstOrDefaultAsync()).MapTo<GameDTO>();
        }
        #endregion
    }
}
