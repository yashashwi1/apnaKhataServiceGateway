using ApnaKhata.DataModels;
using ApnaKhataServiveGateway.Controllers;
using ApnaKhataServiveGateway.Services;
using GatewayInteractionContracts.Requests;
using GatewayInteractionContracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ApnaKhataServiveGateway
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly ILogger<GatewayController> _logger;
        private readonly ServiceLocator service;
        public GatewayController(ILogger<GatewayController> logger, ServiceLocator serviceLocator)
        {
            _logger = logger;
            this.service = serviceLocator;
        }


        [HttpPost(Name = "Request")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        public IActionResult Post( [FromBody]Request request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                return Ok(this.service.LocateServiceEndpoint(request).Result);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
