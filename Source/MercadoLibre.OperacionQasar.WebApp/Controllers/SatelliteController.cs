namespace MercadoLibre.OperacionQasar.WebApp.Controllers
{
    using MercadoLibre.OperacionQuasar.Core.Domain;
    using MercadoLibre.OperacionQuasar.Core.DTOs;
    using MercadoLibre.OperacionQuasar.Core.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Constants.BASIC_AUTHENTICATION_SCHEMA)]

    public class SatelliteController : Controller
    {
        private readonly ISatelliteDomain _topSecretDomain;

        public SatelliteController(ISatelliteDomain topSecretDomain)
        {
            _topSecretDomain = topSecretDomain;
        }

        [HttpPost]
        [Route("topsecret")]
        public async Task<ActionResult<SpacecraftModel>> GetSpacecraftDetailsAsync(TopSecretDto topSecretDto)
        {
            try
            {
                var result = await _topSecretDomain.GetSpacecraftDetailsAsync(topSecretDto);

                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound(Constants.NOT_ENOUGH_INFORMATION_MESSAGE);
            }
        }

        [HttpPost]
        [Route("topsecret_split/{satellite_name}")]
        public async Task<ActionResult<bool>> AddOrUpdateSatelliteRequestedAsync([FromRoute] string satellite_name, [FromBody] SatelliteDto satelliteDto)
        {
            try
            {
                if (satelliteDto != null)
                {
                    satelliteDto.Name = satellite_name;
                }
                var result = await _topSecretDomain.AddOrUpdateSatelliteRequestedAsync(satelliteDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Route("topsecret_split")]
        [Route("topsecret_split/{satellite_name}")]
        public async Task<ActionResult<SpacecraftModel>> GetSpacecraftDetailsBySatellitesCachedAsync()
        {
            try
            {
                var result = await _topSecretDomain.GetSpacecraftDetailsBySatellitesCachedAsync();

                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound(Constants.NOT_ENOUGH_INFORMATION_MESSAGE);
            }
        }
    }
}
