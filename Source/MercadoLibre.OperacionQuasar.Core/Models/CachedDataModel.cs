namespace MercadoLibre.OperacionQuasar.Core.Models
{
    using System;

    /// <summary>
    /// Defines the <see cref="CachedDataModel" />.
    /// </summary>
    public class CachedDataModel
    {
        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets the CacheExpiration.
        /// </summary>
        public TimeSpan CacheExpiration => TimeSpan.FromHours(CacheHours);

        /// <summary>
        /// Gets or sets the CacheHours.
        /// </summary>
        public double CacheHours { get; set; }
    }
}