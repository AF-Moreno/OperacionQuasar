namespace MercadoLibre.OperacionQuasar.Core.DTOs
{
    /// <summary>
    /// Defines the <see cref="SatelliteDto" />.
    /// </summary>
    public class SatelliteDto
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Distance.
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        public string[] Message { get; set; }
    }
}
