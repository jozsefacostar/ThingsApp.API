using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;

namespace Things.DDD.Infrastructure.Configuration
{

    public class ProfileEntityConf
    {
        /* Configuración de la entidad de perfiles */
        public ProfileEntityConf(EntityTypeBuilder<Profile> entity) {}

    }
}
