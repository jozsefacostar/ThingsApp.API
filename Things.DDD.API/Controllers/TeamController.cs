using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.Api.ApplicationServices;
using Things.DDD.API.Commands;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        #region Variables
        private readonly TeamServices _teamServices;
        #endregion

        #region Ctor
        public TeamController(TeamServices teamServices)
        {
            _teamServices = teamServices;
        }
        #endregion

        #region APIs
        [HttpPost]
        //public async Task<PetitionResponse> Create(CreateTeamCommand create)
        //{
        //    await _teamServices.HandleCommand(create);
        //    return Ok(create);
        //}

        [HttpGet()]
        public async Task<PetitionResponse> GetAll()
        {
            return await _teamServices.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<PetitionResponse> GetByID(Guid id)
        {
            return await _teamServices.GetByID(id);
        }
        #endregion
    }
}
