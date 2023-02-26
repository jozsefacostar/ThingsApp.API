using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Response;
using System;
using System.Threading.Tasks;
using Things.DDD.API.Queries;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        #region Variables
        private readonly TeamQueries _teamQueries;
        #endregion

        #region Ctor
        public TeamController(TeamQueries teamServices)
        {
            _teamQueries = teamServices;
        }
        #endregion

        #region APIs
        /// <summary>
        /// Función que consulta todos los equipos.
        /// </summary>        
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> GetAll()
        {
            return await _teamQueries.GetAll();
        }

        /// <summary>
        /// Función que consulta un equipo.
        /// </summary>        
        /// <param name = "id" > ID de equipo</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> GetByID(Guid id)
        {
            return await _teamQueries.GetByID(id);
        }
        #endregion
    }
}
