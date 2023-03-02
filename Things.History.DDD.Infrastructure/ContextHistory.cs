using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Things.DDD.Infrastructure.Configuration;
using Things.History.DDD.Domain.Entities;

namespace Things.History.DDD.Infrastructure
{
    public class ContextHistory : DbContext
    {
        #region Ctor
        public ContextHistory(DbContextOptions<ContextHistory> options) : base(options) { }

        #endregion

        #region Variables

        public DbSet<GameHistory> Games { get; set; }

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
            new GameHistoryEntityConfig(ModelBuilder.Entity<GameHistory>());
        }
        #endregion
    }
}
