
using MediatR;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.RecordBet.Commands
{
    public class RecordBetCreateCommand : IRequest<PetitionResponse>
    {
        public Guid SessionBet { get; set; }
        public Guid User { get; set; }
        public int GoalsA { get; set; }
        public int GoalsB { get; set; }
        public Guid Game { get; set; }
    }
}
