using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.HubConfig
{
    public class AllGamesSummary : Hub
    {
        public async Task BroadcastChartData(List<object> data) =>
            await Clients.All.SendAsync("broadcastSummarydata", data);
    }
}
