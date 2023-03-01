using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.HubConfig
{
    public class AddGameHub : Hub
    {
        public async Task BroadcastChartData(object data) =>
            await Clients.All.SendAsync("broadcastaddgamedata", data);
    }
}
