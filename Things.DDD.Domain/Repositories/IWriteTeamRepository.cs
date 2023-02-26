using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Entities;

namespace Things.DDD.Domain.Repositories
{
    public interface IWriteTeamRepository
    {
        Task Add(TeamDTO company);
    }
}
