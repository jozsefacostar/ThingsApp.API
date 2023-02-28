using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Response;
using System;
using System.Threading.Tasks;
using Things.DDD.API.Queries;
using Things.DDD.EventHandler.Commands.Game;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionBetController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        private readonly SessionBetQueries _sessionBetQueries;
        #endregion

        #region Ctor
        public SessionBetController(IMediator mediator, SessionBetQueries sessionBetQueries)
        {
            _mediator = mediator;
            _sessionBetQueries = sessionBetQueries;
        }
        #endregion

        #region APIs
        /// <summary>
        /// Función que consulta una sesión a partir del código.
        /// </summary>        
        /// <param name = "id" > Cpodigo de la sesión</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> GetSessionBetByCode(string code)
        {
            return await _sessionBetQueries.GetSessionBetByCode(code);
        }

        /// <summary>
        /// Función que crea una sesión de partido.
        /// </summary>        
        /// <param name = "SessionBetCreateCommand" > Objeto que contiene variables para crear uan sesión de partido</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> Create(SessionBetCreateCommand SessionBetCreateCommand)
        {
            return await _mediator.Send(SessionBetCreateCommand);
        }


        #endregion
    }
}
