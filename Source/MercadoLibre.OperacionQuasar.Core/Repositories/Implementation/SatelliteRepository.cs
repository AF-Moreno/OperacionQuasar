namespace MercadoLibre.OperacionQuasar.Core.Repositories
{
    using MercadoLibre.OperacionQuasar.Core.DataAccess;
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class SatelliteRepository : ISatelliteRepository
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly ICacheDataAccess _cacheDataAccess;


        public SatelliteRepository(ISqlDataAccess sqlDataAccess, ICacheDataAccess cacheDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
            _cacheDataAccess = cacheDataAccess;
        }

        public bool AddOrUpdateInCache(SatelliteDto satelliteDto)
        {
            return _cacheDataAccess.TryAddOrUpdate(satelliteDto.Name.ToLower(), satelliteDto);
        }

        public Task<IEnumerable<SatelliteEntity>> GetAllAsync()
        {
            string storedProcedure = "[dbo].[sp_SatelliteGetAll]";

            return _sqlDataAccess.ExecuteQueryAsync<SatelliteEntity>(storedProcedure);
        }

        public SatelliteDto GetInCache(string satelliteName)
        {
            _cacheDataAccess.TryGet(satelliteName, out SatelliteDto satelite);

            return satelite;
        }
    }
}
