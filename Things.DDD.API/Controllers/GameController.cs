using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Response;
using System.Threading.Tasks;
using Things.DDD.EventHandler.Commands.Game;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region APIs
        /// <summary>
        /// Función que crea partido por un administrador.
        /// </summary>        
        /// <param name = "GameCreateCommand" > Objeto que crea partido</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpPost()]
        public async Task<PetitionResponse> Create(GameCreateCommand GameCreateCommand)
        {
            return await _mediator.Send(GameCreateCommand);
        }
        #endregion
    }
}
