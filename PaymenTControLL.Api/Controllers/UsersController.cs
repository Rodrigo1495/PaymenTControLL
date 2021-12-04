using Microsoft.AspNetCore.Mvc;
using PaymenTControLL.Api.Auth;
using PaymenTControLL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymenTControLL.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public UsersController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Users user)
        {
            var token = jwtAuthenticationManager.Authenticate(user.Name, user.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
