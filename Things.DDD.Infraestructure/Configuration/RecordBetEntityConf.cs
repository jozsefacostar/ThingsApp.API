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
    class RecordBetEntityConf
    {
        public RecordBetEntityConf(EntityTypeBuilder<RecordBet> entity)
        {
            entity.HasOne(x => x.SessionBetNavigation)
                  .WithMany(x => x.RecordBets)
                  .HasForeignKey(x => x.SessionBet)
                  .HasConstraintName("FK_RecordBet_BetSesion");


            entity.HasOne(x => x.UserNavigation)
                  .WithMany(x => x.RecordBets)
                  .HasForeignKey(x => x.User)
                  .HasConstraintName("FK_RecordBet_User");

        }
    }
}
