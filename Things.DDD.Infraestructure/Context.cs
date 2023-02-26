using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;
using Things.DDD.Infrastructure.Configuration;

namespace Things.DDD.Infrastructure
{
    public class Context : DbContext
    {
        #region Ctor
        public Context(DbContextOptions<Context> options) : base(options) { }

        #endregion

        #region Variables
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<SessionBet> SessionBets { get; set; }
        public DbSet<RecordBet> RecordBets { get; set; }
        #endregion

        #region Protected Methods
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            ModelConfig(model);
        }
        #endregion

        #region Private Methods
        private void ModelConfig(ModelBuilder ModelBuilder)
        {
            new TeamEntityConfig(ModelBuilder.Entity<Team>());
            new GameEntityConfig(ModelBuilder.Entity<Game>());
            new SessionBetEntityConf(ModelBuilder.Entity<SessionBet>());
            new RecordBetEntityConf(ModelBuilder.Entity<RecordBet>());
            new ProfileEntityConf(ModelBuilder.Entity<Profile>());
            new UserEntityConf(ModelBuilder.Entity<User>());
        }
        #endregion
    }
}
