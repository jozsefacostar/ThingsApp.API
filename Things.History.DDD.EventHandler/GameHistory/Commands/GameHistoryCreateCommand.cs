using MediatR;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.History.DDD.EventHandler.GameHistory.Commands
{
    public class GameHistoryCreateCommand : IRequest<PetitionResponse>
    {
        public Guid TeamA { get; set; }
        public Guid TeamB { get; set; }
        public DateTime DateInitial { get; set; }
    }
}
