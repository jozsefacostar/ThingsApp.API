using MediatR;
using Service.Common.Response;
using System;

namespace Things.DDD.EventHandler.User.Commands
{
    public class UserLogoutCommand : IRequest<PetitionResponse>
    {
        public string ID { get; set; }
    }
}
