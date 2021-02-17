namespace MercadoLibre.OperacionQuasar.Core.Repositories
{
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ISatelliteRepository" />.
    /// </summary>
    internal interface ISatelliteRepository : IRepository
    {
        /// <summary>
        /// Get all satellites.
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{SatelliteEntity}}"/>.</returns>
        Task<IEnumerable<SatelliteEntity>> GetAllAsync();

        /// <summary>
        /// The AddOrUpdateSatelliteRequestedAsync.
        /// </summary>
        /// <param name="satelliteDto">The satelliteDto<see cref="SatelliteDto"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        bool AddOrUpdateInCache(SatelliteDto satelliteDto);

        /// <summary>
        /// The GetInCache.
        /// </summary>
        /// <param name="satelliteName">The satelliteName<see cref="string"/>.</param>
        /// <returns>The <see cref="SatelliteDto"/>.</returns>
        SatelliteDto GetInCache(string satelliteName);
    }
}
