using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Response;
using System.Threading.Tasks;
using Things.DDD.API.Queries;
using Things.DDD.EventHandler.Commands.Game;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        private readonly GameQueries _gameQueries;
        #endregion

        #region Ctor
        public GameController(IMediator mediator, GameQueries gameQueries)
        {
            _mediator = mediator;
            _gameQueries = gameQueries;
        }
        #endregion

        #region APIs

        /// <summary>
        /// Función que consulta todos los partidos por un estado.
        /// </summary>        
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet("{Finalized}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> GetAllByStatus(bool Finalized)
        {
            return await _gameQueries.GetAllByStatus(Finalized);
        }

        /// <summary>
        /// Función que crea un partido.
        /// </summary>        
        /// <param name = "GameCreateCommand" > Objeto que contiene variables para crear partido</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> Create(GameCreateCommand GameCreateCommand)
        {
            return await _mediator.Send(GameCreateCommand);
        }

        /// <summary>
        /// Función que actualiza los marcadores de un partido.
        /// </summary>        
        /// <param name = "ScoresChangeCommand" > Objeto que contiene varibles para actualizar partido</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpPut]
        public async Task<PetitionResponse> UpdateScores(ScoresChangeCommand ScoresChangeCommand)
        {
            return await _mediator.Send(ScoresChangeCommand);
        }
        #endregion
    }
}
