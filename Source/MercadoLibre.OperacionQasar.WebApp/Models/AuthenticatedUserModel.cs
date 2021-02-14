using System.Security.Principal;

namespace MercadoLibre.OperacionQasar.WebApp.Models
{
    public class AuthenticatedUserModel : IIdentity
    {
        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }
    }
}
