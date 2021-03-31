using BaseProject.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel model)
        {
            string signKey = _configuration["JWT:SignKey"];

            var jwtSecurityToken = JWTFactory.CreateJWT(model.Account, null, signKey, DateTime.Now.AddDays(3));
            string jwtStrng = JWTFactory.JwtTokenString(jwtSecurityToken);

            return Ok(new JWTModel
            {
                Result= jwtStrng
            });
        }
    }

    public class JWTModel
    {
        public string Result { get; set; }
    }

    public class LoginModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
