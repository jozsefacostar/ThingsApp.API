using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Things.DDD.API.Commands;
using Things.DDD.API.Queries;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Entities;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.Api.ApplicationServices
{
    public class TeamServices
    {
        #region Variables
        private readonly IWriteTeamRepository _writeRepository;
        private readonly TeamQueries _teamQueries;
        #endregion

        #region Ctor
        public TeamServices(IWriteTeamRepository writeRepository, TeamQueries companyQueries)
        {
            _writeRepository = writeRepository;
            _teamQueries = companyQueries;
        }
        #endregion

        #region Public Methods
        /* Servicio que dispara comando de crear equipo */
        public async Task HandleCommand(CreateTeamCommand create)
        {
            await _writeRepository.Add(create.company);
        }
        /* Servicio que consulta información de todos los equipos  */
        public async Task<PetitionResponse> GetAll()
        {
            var resultGetAll = await _teamQueries.GetAll();
            return new PetitionResponse { success = true, message = "Equipos consultadas con éxito", module = "Team", result = resultGetAll };
        }
        /* Servicio que consulta información por ID de equipo  */
        public async Task<PetitionResponse> GetByID(Guid id)
        {
            var resultGetByID = await _teamQueries.GetByID(id);
            return new PetitionResponse { success = true, message = "Equipo consultado con éxito", module = "Team", result = resultGetByID };
        }
        #endregion
    }

}
