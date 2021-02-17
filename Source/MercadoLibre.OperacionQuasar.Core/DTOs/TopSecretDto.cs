namespace MercadoLibre.OperacionQuasar.Core.DTOs
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="TopSecretDto" />.
    /// </summary>
    public class TopSecretDto
    {
        /// <summary>
        /// Gets or sets the Satellites.
        /// </summary>
        public IEnumerable<SatelliteDto> Satellites { get; set; }
    }
}
