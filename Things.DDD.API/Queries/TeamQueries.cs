using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
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
        public async Task<PetitionResponse> GetAll()
        {
            try
            {
                var result = await _teamRepository.GetAll();
                return new PetitionResponse { success = true, message = "Equipos consultados con éxito", module = "Team", result = result };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible consultar: " + ex.StackTrace, module = "Team" };
            }
        }
        /* Query de consulta para ID de equipo */
        public async Task<PetitionResponse> GetByID(Guid id)
        {
            try
            {
                var result = await _teamRepository.GetByID(id);
                return new PetitionResponse { success = true, message = "Equipo consultado con éxito", module = "Team", result = result };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible consultar: " + ex.StackTrace, module = "Team" };
            }

        }
        #endregion

    }
}
