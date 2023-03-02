using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Response;
using System.Threading.Tasks;
using Things.History.DDD.EventHandler.GameHistory.Commands;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameHistoryController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public GameHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region APIs

        /// <summary>
        /// Función que crea un partido.
        /// </summary>        
        /// <param name = "GameCreateCommand" > Objeto que contiene variables para crear partido</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PetitionResponse> Create(GameHistoryCreateCommand GameCreateCommand)
        {

            return await _mediator.Send(GameCreateCommand);
        }
        #endregion
    }
}
