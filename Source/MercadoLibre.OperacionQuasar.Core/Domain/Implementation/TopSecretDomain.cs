namespace MercadoLibre.OperacionQuasar.Core.Domain
{
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Models;
    using MercadoLibre.OperacionQuasar.Core.Repositories;
    using System.Threading.Tasks;

    internal class TopSecretDomain : ITopSecretDomain
    {
        private readonly ISatelliteRepository _satelliteRepository;

        public TopSecretDomain(ISatelliteRepository satelliteRepository)
        {
            _satelliteRepository = satelliteRepository;
        }

        public async Task<SpacecraftModel> GetSpacecraftDetailsAsync(TopSecretDto topSecretDto)
        {
            var satellites = await _satelliteRepository.GetAllAsync();


            throw new System.NotImplementedException();
        }

        public Task<SpacecraftModel> GetSpacecraftDetailsAsync(TopSecretSatelliteDto satelliteDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
