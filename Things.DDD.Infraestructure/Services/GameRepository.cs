
using Microsoft.EntityFrameworkCore;
using Service.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Entities;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.Infrastructure.Services
{
    public class GameRepository : IReadGameRepository
    {
        #region Variables
        private readonly Context _context;
        #endregion

        #region Ctor
        public GameRepository(Context context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /* Función que permite consultar todos los partidos que no han finalizado y están pendientes por jugar */
        public async Task<dynamic> GetAllByStatus(bool Finalized)
        {
            return await _context.Games
                .Include(x => x.TeamANavigation)
                .Include(x => x.TeamBNavigation).Where(x => x.Finalized == Finalized)
                .Select(
                x => new
                {
                    TeamA = x.TeamANavigation.Description,
                    TeamB = x.TeamBNavigation.Description,
                    DateInitial = x.DateInitial,
                    DateFinal = x.DateFinal,
                    Finalized = x.Finalized,
                    resultScore = "(" + x.GoalsA + ") - (" + x.GoalsB + ")",
                    GoalsA = x.GoalsA,
                    GoalsB = x.GoalsB,
                    ID = x.ID
                })
                .OrderByDescending(x => x.DateInitial)
                .ToListAsync();
        }
        /* Función que permite consultar todos los partidos que no han finalizado y están pendientes por jugar */
        public async Task<dynamic> GetAllForSession()
        {
            return await _context.Games
                .Include(x => x.TeamANavigation)
                .Include(x => x.TeamBNavigation).Where(x => x.Finalized == false && x.DateInitial > DateTime.Now)
                .Select(
                x => new
                {
                    TeamA = x.TeamANavigation.Description,
                    TeamB = x.TeamBNavigation.Description,
                    DateInitial = x.DateInitial,
                    DateFinal = x.DateFinal,
                    Finalized = x.Finalized,
                    resultScore = "(" + x.GoalsA + ") - (" + x.GoalsB + ")",
                    GoalsA = x.GoalsA,
                    GoalsB = x.GoalsB,
                    ID = x.ID
                })
                .OrderByDescending(x => x.DateInitial)
                .ToListAsync();
        }
        /* Función que permite consultar un partido por ID */
        public async Task<GameDTO> GetByID(Guid id)
        {
            return (await _context.Games.Where(x => x.ID == id).FirstOrDefaultAsync()).MapTo<GameDTO>();
        }
        #endregion
    }
}
