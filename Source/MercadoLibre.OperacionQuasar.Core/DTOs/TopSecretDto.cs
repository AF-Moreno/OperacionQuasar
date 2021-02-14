using System.Collections.Generic;

namespace MercadoLibre.OperacionQuasar.Core.DTOs
{
    public class TopSecretDto
    {
        public IEnumerable<TopSecretSatelliteDto> Satellites { get; set; }
    }
}
