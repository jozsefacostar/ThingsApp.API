using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.API.Models;

namespace Things.DDD.API.HubConfig
{
    public class AllGamesSummary : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) =>
            await Clients.All.SendAsync("broadcastallGamesdata", data);
    }
}
