
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
    public class TeamRepository : IReadTeamRepository
    {
        #region Variables
        private readonly Context _context;
        #endregion

        #region Ctor
        public TeamRepository(Context context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /* Función que permite consultar todos los equipos */
        public async Task<List<TeamDTO>> GetAll()
        {
            return (await _context.Teams.Where(x => !x.Inactive).ToListAsync()).MapTo<List<TeamDTO>>();
        }
        /* Función que permite consultar un equipo por ID */
        public async Task<TeamDTO> GetByID(Guid id)
        {
            return (await _context.Teams.Where(x => x.ID == id).FirstOrDefaultAsync()).MapTo<TeamDTO>();
        }
        #endregion
    }
}
