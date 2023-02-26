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
        [HttpGet()]
        public async Task<PetitionResponse> GetAll()
        {
            return await _teamQueries.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<PetitionResponse> GetByID(Guid id)
        {
            return await _teamQueries.GetByID(id);
        }
        #endregion
    }
}
