using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Entities;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.API.Queries
{
    public class TeamQueries
    {
        #region Varibles
        private readonly IReadTeamRepository _teamRepository;
        #endregion

        #region Ctor
        public TeamQueries(IReadTeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        #endregion

        #region Public Methods
        /* Query de consulta para todos los equipos */
        public async Task<List<TeamDTO>> GetAll()
        {
            return await _teamRepository.GetAll();
        }
        /* Query de consulta para ID de equipo */
        public async Task<TeamDTO> GetByID(Guid id)
        {
            return await _teamRepository.GetByID(id);
        }
        #endregion

    }
}
