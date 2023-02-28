using MediatR;
using Service.Common.Response;
using System;

namespace Things.DDD.EventHandler.User.Commands
{
    public class UserLoginCommand : IRequest<PetitionResponse>
    {
        public string NIT { get; set; }
        public string Pass { get; set; }
    }
}
