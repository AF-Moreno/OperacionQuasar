namespace MercadoLibre.OperacionQasar.WebApp.Controllers
{
    using MercadoLibre.OperacionQuasar.Core.Domain;
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Constants.BASIC_AUTHENTICATION_SCHEMA)]

    public class TopSecretController : Controller
    {
        private readonly ITopSecretDomain _topSecretDomain;

        public TopSecretController(ITopSecretDomain topSecretDomain)
        {
            _topSecretDomain = topSecretDomain;
        }

        [HttpPost]
        public Task<SpacecraftModel> Index(TopSecretDto topSecretDto)
        {
            return _topSecretDomain.GetSpacecraftDetailsAsync(topSecretDto);
        }
    }
}
