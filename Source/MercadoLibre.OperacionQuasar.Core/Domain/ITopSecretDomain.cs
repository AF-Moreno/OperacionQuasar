namespace MercadoLibre.OperacionQuasar.Core.Domain
{
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ITopSecretDomain" />.
    /// </summary>
    public interface ITopSecretDomain : IDomain
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
        /// <param name="satelliteDto">The satelliteDto<see cref="TopSecretSatelliteDto"/>.</param>
        /// <returns>The <see cref="Task{SpacecraftModel}"/>.</returns>
        Task<SpacecraftModel> GetSpacecraftDetailsAsync(TopSecretSatelliteDto satelliteDto);
    }
}
