using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Response;
using System;
using System.Threading.Tasks;
using Things.DDD.API.Queries;
using Things.DDD.EventHandler.Commands.Game;
using Things.DDD.EventHandler.RecordBet.Commands;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordBetController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        private readonly RecordBetQueries _RecordBetQueries;
        #endregion

        #region Ctor
        public RecordBetController(IMediator mediator, RecordBetQueries RecordBetQueries)
        {
            _mediator = mediator;
            _RecordBetQueries = RecordBetQueries;
        }
        #endregion

        #region APIs

        /// <summary>
        /// Función que consulta las apuestas de un usuario.
        /// </summary>        
        /// <param name = "user" > Cpodigo de la sesión</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet("GetRecordsByUser/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> GetRecordsByUser(string user)
        {
            return await _RecordBetQueries.GetRecordsByUser(user);
        }

        /// <summary>
        /// Función que consulta las apuestas de varios usuaios.
        /// </summary>        
        /// <param name = "sessionBet" > Cpodigo de la sesión</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet("GetRecordBySession/{sessionBet}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> GetRecordBySession(string sessionBet)
        {
            return await _RecordBetQueries.GetRecordBySession(sessionBet);
        }

        /// <summary>
        /// Función que consulta las apuestas de los usuarios y sesiones.
        /// </summary>        
        /// <param name = "user" > Código de usuario</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet("GetRecordsByUserAndSession/{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> GetRecordsByUserAndSession(string user)
        {
            return await _RecordBetQueries.GetRecordsByUserAndSession(user);
        }




        /// <summary>
        /// Función que crea una apuesta de partido.
        /// </summary>        
        /// <param name = "RecordBetCreateCommand" > Objeto que contiene variables para crear una apuesta de partido</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> Create(RecordBetCreateCommand RecordBetCreateCommand)
        {
            return await _mediator.Send(RecordBetCreateCommand);
        }

        /// <summary>
        /// Función que actualiza una apuesta previamente realizada.
        /// </summary>        
        /// <param name = "RecordBetCreateCommand" > Objeto que contiene variables para actualizar una apuesta de partido</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> Update(RecordBetUpdateCommand RecordBetUpdateCommand)
        {
            return await _mediator.Send(RecordBetUpdateCommand);
        }
        #endregion
    }
}
