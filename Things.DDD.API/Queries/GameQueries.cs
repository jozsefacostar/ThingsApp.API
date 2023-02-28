using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.API.Queries
{
    public class GameQueries
    {
        #region Varibles
        private readonly IReadGameRepository _GameRepository;
        #endregion

        #region Ctor
        public GameQueries(IReadGameRepository GameRepository)
        {
            _GameRepository = GameRepository;
        }
        #endregion

        #region Public Methods
        /* Query de consulta para todos los partidos */
        public async Task<PetitionResponse> GetAllByStatus(bool Finalized)
        {
            try
            {
                var result = await _GameRepository.GetAllByStatus(Finalized);
                return new PetitionResponse { success = true, message = "Partidos consultados con éxito", module = "Game", result = result };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible consultar: " + ex.StackTrace, module = "Game" };
            }
        }
        /* Query de consulta para todos los partidos habilitados para crear una sesión */
        public async Task<PetitionResponse> GetAllForSession()
        {
            try
            {
                var result = await _GameRepository.GetAllForSession();
                return new PetitionResponse { success = true, message = "Partidos consultados con éxito", module = "Game", result = result };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible consultar: " + ex.StackTrace, module = "Game" };
            }
        }
        #endregion

    }
}
