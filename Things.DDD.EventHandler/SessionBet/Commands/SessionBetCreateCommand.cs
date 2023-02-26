using MediatR;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.EventHandler.Commands.Game
{
    public class SessionBetCreateCommand : IRequest<PetitionResponse>
    {
        public string Name{ get; set; }
        public Guid Game { get; set; }
    }
}
