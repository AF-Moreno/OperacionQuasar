namespace MercadoLibre.OperacionQasar.WebApp.Models
{
    using System.Security.Principal;

    /// <summary>
    /// Defines the <see cref="AuthenticatedUserModel" />.
    /// </summary>
    public class AuthenticatedUserModel : IIdentity
    {
        /// <summary>
        /// Gets or sets the AuthenticationType.
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsAuthenticated.
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }
    }
}
