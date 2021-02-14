namespace MercadoLibre.OperacionQuasar.Core.Entities
{
    /// <summary>
    /// Defines the <see cref="BaseEntity" />.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Enable.
        /// </summary>
        public bool Enable { get; set; }
    }
}
