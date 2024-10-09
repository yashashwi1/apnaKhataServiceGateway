using ApnaKhata.DataModels;
using GatewayInteractionContracts.Requests;
using GatewayInteractionContracts.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Text;

namespace ApnaKhataServiveGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name ="GetUserDetails")]        
        public GetUserResponse GetUserDetails([FromQuery] GetUserRequest request)
        {
            var userResponse = new GetUserResponse();
            userResponse.User = new User();
            userResponse.User.FirstName = "asasasas";

            return userResponse;
        }
        public CreateUserResponse CreateUserDetails([FromBody] CreateUserRequest request)
        {
            var userResponse = new GetUserResponse();
            userResponse.User = new User();
            userResponse.User.FirstName = "asasasas";

            return userResponse;
        }
    }
}
