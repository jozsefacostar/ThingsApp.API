using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.History.DDD.Domain.Entities;

namespace Things.DDD.Infrastructure.Configuration
{
    class GameHistoryEntityConfig
    {
        /* Configuración de relaciones para la entidad de GameHistory */
        public GameHistoryEntityConfig(EntityTypeBuilder<GameHistory> entity)
        {
           
        }
    }
}

