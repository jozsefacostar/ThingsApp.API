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
    public class UserEntityConf
    {
        /* Configuración de relaciones para la entidad de Usuarios */
        public UserEntityConf(EntityTypeBuilder<User> entity) { 
            entity.HasOne( x=>x.ProfileNavigation)
                  .WithMany(x=>x.Users)
                  .HasForeignKey(x=>x.Profile)
                  .HasConstraintName("FK_User_Profile");

        }

    }
}
