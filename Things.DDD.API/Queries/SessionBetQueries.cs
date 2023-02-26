using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.API.Queries
{
    public class SessionBetQueries
    {
        #region Varibles
        private readonly IReadSessionBetRepository _IReadSessionBetRepository;
        #endregion

        #region Ctor
        public SessionBetQueries(IReadSessionBetRepository IReadSessionBetRepository)
        {
            _IReadSessionBetRepository = IReadSessionBetRepository;
        }
        #endregion

        #region Public Methods
        /* Query de consulta para una sesión por su código */
        public async Task<PetitionResponse> GetSessionBetByCode(string code)
        {
            try
            {
                var result = await _IReadSessionBetRepository.GetSessionBetByCode(code);
                if (result.Equals(Guid.Empty))
                    return new PetitionResponse { success = false, message = "No se encuentra la sesión con el código indicado", module = "SessionBet", result = result };
                else
                    return new PetitionResponse { success = true, message = "Sesión consultada con éxito", module = "SessionBet", result = result };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible consultar sesión: " + ex.StackTrace, module = "Team" };
            }
        }
        #endregion

    }
}
