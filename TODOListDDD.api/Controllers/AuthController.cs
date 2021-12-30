using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TODOListDDD.api.Data.Converter.Implementations;
using TODOListDDD.api.Data.VO;
using TODOListDDD.api.Services.Interfaces;
using TODOListDDD.application.Interfaces;

namespace TODOListDDD.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserAppService _AppService;
        private readonly ITokenService _tokenService;
        private const string DATE_FORMAT = "dd/MM/yyyy hh:mm:ss";

        public AuthController(ILogger<AuthController> logger, IUserAppService appService, ITokenService tokenService)
        {
            _logger = logger;
            _AppService = appService;
            _tokenService = tokenService;
        }


        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserVO user)
        {
            if (user is null) return BadRequest("Invalid request");
            var userCtd = _AppService.CreateUser(user.Email, user.Password, user.Name);

            return Ok(userCtd);
        }

        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] UserVO userCredentials)
        {
            var user = _AppService.ValidateCredentials(userCredentials.Email, userCredentials.Password);
            if (user is null) return Unauthorized();

            var token = _tokenService.GenerateToken(user);

            var result = new TokenVO()
            {
                Token = token,
                Expiration = DateTime.Now.AddHours(3).ToString(DATE_FORMAT)
            };
            return Ok(result);
        }
    }
}
