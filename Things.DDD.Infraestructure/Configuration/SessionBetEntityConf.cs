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
    public class SessionBetEntityConf
    {
        public SessionBetEntityConf(EntityTypeBuilder<SessionBet> entity)
        {
            entity.HasOne(x => x.GameNavigation)
                  .WithMany(x => x.SessionBets)
                  .HasForeignKey(x => x.Game)
                  .HasConstraintName("FK_SessionBet_Game");

        }
    }
}
