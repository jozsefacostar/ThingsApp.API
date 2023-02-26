using MediatR;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.Commands.Game
{
    public class ScoresChangeCommand : IRequest<PetitionResponse>
    {
        public Guid ID { get; set; }
        public int GoalsA { get; set; }
        public int GoalsB { get; set; }
        public bool Finalized { get; set; }
    }
}
