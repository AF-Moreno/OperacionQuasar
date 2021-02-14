namespace MercadoLibre.OperacionQuasar.Core.Repositories
{
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
    }
}
