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
    class GameEntityConfig
    {
        /* Configuración de relaciones para la entidad de Game */
        public GameEntityConfig(EntityTypeBuilder<Game> entity)
        {
            entity.HasOne(x => x.TeamANavigation)
                  .WithMany(x => x.TeamsA)
                  .HasForeignKey(x => x.TeamA)
                  .HasConstraintName("FK_Game_TeamA")
                  .OnDelete(DeleteBehavior.ClientSetNull);
                  

            entity.HasOne(x => x.TeamBNavigation)
                 .WithMany(x => x.TeamsB)
                 .HasForeignKey(x => x.TeamB)
                 .HasConstraintName("FK_Game_TeamB")
                 .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

