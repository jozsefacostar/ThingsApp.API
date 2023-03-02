using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.HubConfig
{
    public class CreateRecordByUserHub : Hub
    {
        public async Task BroadcastChartData(object data) =>
            await Clients.All.SendAsync("broadcastCretRBUHubdata", data);
    }
}
