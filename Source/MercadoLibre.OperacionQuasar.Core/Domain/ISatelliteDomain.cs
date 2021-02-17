namespace MercadoLibre.OperacionQuasar.Core.Domain
{
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ISatelliteDomain" />.
    /// </summary>
    public interface ISatelliteDomain : IDomain
    {
        /// <summary>
        /// The GetSpacecraftDetailsAsync.
        /// </summary>
        /// <param name="topSecretDto">The topSecretDto<see cref="TopSecretDto"/>.</param>
        /// <returns>The <see cref="Task{SpacecraftModel}"/>.</returns>
        Task<SpacecraftModel> GetSpacecraftDetailsAsync(TopSecretDto topSecretDto);

        /// <summary>
        /// The GetSpacecraftDetailsAsync.
        /// </summary>
        /// <returns>The <see cref="Task{SpacecraftModel}"/>.</returns>
        Task<SpacecraftModel> GetSpacecraftDetailsBySatellitesCachedAsync();

        /// <summary>
        /// The AddOrUpdateSatelliteRequestedAsync.
        /// </summary>
        /// <param name="satelliteDto">The satelliteDto<see cref="SatelliteDto"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> AddOrUpdateSatelliteRequestedAsync(SatelliteDto satelliteDto);
    }
}
