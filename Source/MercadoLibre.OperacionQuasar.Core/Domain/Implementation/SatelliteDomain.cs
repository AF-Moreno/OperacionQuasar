namespace MercadoLibre.OperacionQuasar.Core.Domain
{
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Entities;
    using MercadoLibre.OperacionQuasar.Core.Models;
    using MercadoLibre.OperacionQuasar.Core.Repositories;
    using MercadoLibre.OperacionQuasar.Core.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class SatelliteDomain : ISatelliteDomain
    {
        private readonly ISatelliteRepository _satelliteRepository;


        public SatelliteDomain(ISatelliteRepository satelliteRepository)
        {
            _satelliteRepository = satelliteRepository;
        }

        public async Task<SpacecraftModel> GetSpacecraftDetailsAsync(TopSecretDto topSecretDto)
        {
            var baseSatellites = await _satelliteRepository.GetAllAsync();
            var satellitesRequested = topSecretDto.Satellites;

            ValidateSatellitesRequested(baseSatellites, satellitesRequested);

            return GetSpacecraftDetails(baseSatellites, satellitesRequested);
        }

        public async Task<SpacecraftModel> GetSpacecraftDetailsBySatellitesCachedAsync()
        {
            var baseSatellites = await _satelliteRepository.GetAllAsync();
            var satellitesRequested = baseSatellites.Select(x => _satelliteRepository.GetInCache(x.Name))
                                                    .ToArray();

            return GetSpacecraftDetails(baseSatellites, satellitesRequested);
        }

        public async Task<bool> AddOrUpdateSatelliteRequestedAsync(SatelliteDto satelliteDto)
        {
            var baseSatellites = await _satelliteRepository.GetAllAsync();
            var satellitesRequested = new List<SatelliteDto>() { satelliteDto };

            ValidateSatellitesRequested(baseSatellites, satellitesRequested);

            return _satelliteRepository.AddOrUpdateInCache(satelliteDto);
        }

        private void ValidateSatellitesRequested(IEnumerable<SatelliteEntity> baseSatellites, IEnumerable<SatelliteDto> satellitesRequested)
        {
            var satellitesNotFound = satellitesRequested
                                        .Where(
                                            x => !baseSatellites.Any(y => string.Equals(y.Name, x.Name, StringComparison.OrdinalIgnoreCase)))
                                        .Select(x => x.Name)
                                        .ToArray();

            if (satellitesNotFound.Count() > 0)
            {
                var errorMessages = satellitesNotFound.Count() == 1
                                  ? $"The satellite '{satellitesNotFound.FirstOrDefault()}' not found"
                                  : $"The satellites [{string.Join(", ", satellitesNotFound)}] were not found";

                throw new Exception(errorMessages);
            }
        }

        private SpacecraftModel GetSpacecraftDetails(IEnumerable<SatelliteEntity> baseSatellites, IEnumerable<SatelliteDto> satellitesRequested)
        {
            var spacecraft = new SpacecraftModel()
            {
                Position = GetSpacecraftPosition(baseSatellites, satellitesRequested),
                Message = GetSpacecraftMessage(satellitesRequested)
            };

            return spacecraft;
        }

        private PositionModel GetSpacecraftPosition(IEnumerable<SatelliteEntity> baseSatellites, IEnumerable<SatelliteDto> satellitesRequested)
        {
            var trilaterationPoints = baseSatellites
               .Join(
                   satellitesRequested,
                   baseSatellite => baseSatellite?.Name.Trim().ToLower(),
                   requested => requested?.Name.Trim().ToLower(),
                   (baseSatellite, requested) =>
                       new TrilaterationPointModel()
                       {
                           X = baseSatellite.PositionX,
                           Y = baseSatellite.PositionY,
                           Distance = requested.Distance
                       })
               .Where(point => point.Distance != 0)
               .ToArray();


            return TrilaterationUtils.GetLocation(trilaterationPoints);
        }

        private string GetSpacecraftMessage(IEnumerable<SatelliteDto> satellitesRequested)
        {
            var messages = satellitesRequested.Select(x => x.Message).ToArray();

            return MessageUtils.GetMessage(messages);
        }
    }
}
