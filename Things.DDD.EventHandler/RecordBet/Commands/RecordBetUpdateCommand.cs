using MediatR;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.RecordBet.Commands
{
    public class RecordBetUpdateCommand : IRequest<PetitionResponse>
    {
        public Guid RecordBet { get; set; }
        public int GoalsA { get; set; }
        public int GoalsB { get; set; }
    }
}
