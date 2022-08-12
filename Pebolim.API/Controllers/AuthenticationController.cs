using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Requests;
using Pebolim.Service.Responses;

namespace Pebolim.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthenticationRequest request)
        {
            if (request.Username == null || request.Password == null) return BadRequest();
            var (success, content) = await _authenticationService.Register(request.Username, request.Password);
            if(!success) return BadRequest(content);

            return await Login(request);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            if (request.Username == null || request.Password == null) return BadRequest();
            var (success, content) = await _authenticationService.Login(request.Username, request.Password);
            if (!success) return BadRequest(content);

            return Ok(new AuthenticationResponse() { Token = content});
        }
    }
}
