namespace MercadoLibre.OperacionQuasar.Core.Repositories
{
    using MercadoLibre.OperacionQuasar.Core.DataAccess;
    using MercadoLibre.OperacionQuasar.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class SatelliteRepository : ISatelliteRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public SatelliteRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<IEnumerable<SatelliteEntity>> GetAllAsync()
        {
            string storedProcedure = "[dbo].[sp_SatelliteGetAll]";

            return _dataAccess.ExecuteQueryAsync<SatelliteEntity>(storedProcedure);
        }
    }
}
