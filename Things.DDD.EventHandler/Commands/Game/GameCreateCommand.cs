using MediatR;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.Commands.Game
{
    public class GameCreateCommand: IRequest<PetitionResponse>
    {
        public Guid TeamA { get; set; }
        public Guid TeamB { get; set; }
        public DateTime GameDate { get; set; }
    }
}
