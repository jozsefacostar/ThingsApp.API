using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Entities;

namespace Things.DDD.API.Commands
{
    public record CreateTeamCommand(TeamDTO company);
}
