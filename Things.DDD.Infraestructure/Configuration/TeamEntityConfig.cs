using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;

namespace Things.DDD.Infrastructure.Configuration
{
    public class TeamEntityConfig
    {
        /* Configuración de la entidad de teams */
        public TeamEntityConfig(EntityTypeBuilder<Team> entity)
        {

        }
    }
}
