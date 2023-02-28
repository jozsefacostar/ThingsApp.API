using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Things.DDD.Domain.DTOs;
using Things.DDD.Domain.Repositories;

namespace Things.DDD.API.Queries
{
    public class RecordBetQueries
    {
        #region Varibles
        private readonly IReadRecordBetRepository _IReadRecordBetRepository;
        #endregion

        #region Ctor
        public RecordBetQueries(IReadRecordBetRepository IReadRecordBetRepository)
        {
            _IReadRecordBetRepository = IReadRecordBetRepository;
        }
        #endregion

        #region Public Methods
        /* Query de consulta para una Apuesta por su código */
        public async Task<PetitionResponse> GetRecordsByUser(string User)
        {
            try
            {
                var result = await _IReadRecordBetRepository.GetRecordsByUser(User);
                if (result.Equals(Guid.Empty))
                    return new PetitionResponse { success = false, message = "No se encuentra la Apuesta con el código indicado", module = "RecordBet", result = result };
                else
                    return new PetitionResponse { success = true, message = "Apuesta consultada con éxito", module = "RecordBet", result = result };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible consultar Apuesta: " + ex.StackTrace, module = "Team" };
            }
        }
        #endregion

    }
}
