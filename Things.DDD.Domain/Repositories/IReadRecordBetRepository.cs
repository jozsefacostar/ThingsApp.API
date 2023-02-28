using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.Domain.Repositories
{
    public interface IReadRecordBetRepository
    {
        Task<dynamic> GetRecordsByUser(string User);
    }
}

