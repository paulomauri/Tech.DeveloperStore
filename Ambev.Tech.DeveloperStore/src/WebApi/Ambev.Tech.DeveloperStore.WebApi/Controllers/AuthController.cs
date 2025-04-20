using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Tech.DeveloperStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<AuthTokenDto>> Login([FromBody] LoginDto loginDto)
        {
            var token = await _authRepository.LoginAsync(loginDto);
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
            var isValid = await _authRepository.ValidateTokenAsync(token);
            if (!isValid)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
