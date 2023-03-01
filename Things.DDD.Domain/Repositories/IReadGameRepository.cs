using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Entities;

namespace Things.DDD.Domain.Repositories
{
    public interface IReadGameRepository
    {
        Task<dynamic> GetAllByStatus(bool Finalized);
        Task<dynamic> GetAllForSession();
        Task<GameDTO> GetByID(Guid id);
        Task<List<dynamic>> FinalizedGames();
    }
}
