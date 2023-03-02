using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.API.DataStorage;
using Things.DDD.API.HubConfig;
using Things.DDD.API.Queries;
using Things.DDD.API.TimerFeatures;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<AllGamesSummary> _hub;
        private readonly TimerManager _timer;
        private readonly RecordBetQueries _RecordBetQueries;

        public ChartController(IHubContext<AllGamesSummary> hub, TimerManager timer, RecordBetQueries RecordBetQueries)
        {
            _hub = hub;
            _timer = timer;
            _RecordBetQueries = RecordBetQueries;
        }

        /// <summary>
        /// Función que consulta las apuestas relacionadas de un usuario.
        /// </summary>        
        /// <param name = "user" > Cpodigo de la sesión</param>
        /// <returns>Resultado de la petición</returns>
        /// <author>Jozsef Acosta</author>
        [HttpGet("{user}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(string user)
        {
            object obj = null;
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() =>
                {
                    obj = _hub.Clients.All.SendAsync("AllGamesSummary", _RecordBetQueries.GetRecordsByUser(user));

                });
            return Ok(new { obj });
        }

    }
}