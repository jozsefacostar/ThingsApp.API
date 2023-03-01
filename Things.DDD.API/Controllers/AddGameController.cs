using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.API.DataStorage;
using Things.DDD.API.HubConfig;
using Things.DDD.API.TimerFeatures;

namespace Things.DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddGameController : ControllerBase
    {
        //private readonly IHubContext<AddGameHub> _hub;

        //public AddGameController(IHubContext<AddGameHub> hub)
        //{
        //    _hub = hub;
        //}

        //[HttpGet]
        //public IActionResult GetAddGame()
        //{
        //    _hub.Clients.All.SendAsync("TransferAddGameData", "LLegó partido");
        //    return Ok(new { Message = "Request Completed" });
        //}


    }
}