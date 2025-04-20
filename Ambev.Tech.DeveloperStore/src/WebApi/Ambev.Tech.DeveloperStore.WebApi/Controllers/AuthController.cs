using Ambev.Tech.DeveloperStore.Application.Auth.Commands;
using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<AuthTokenDto>> Login([FromBody] LoginDto loginDto)
        {
            var command = new LoginCommand(loginDto.Username, loginDto.Password);
            var token = await _mediator.Send(command);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        // POST api/auth/validate
        [HttpPost("validate")]
        public async Task<ActionResult> ValidateToken([FromBody] string token)
        {
            var command = new ValidateTokenCommand(token);
            var isValid = await _mediator.Send(command);

            if (!isValid)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
