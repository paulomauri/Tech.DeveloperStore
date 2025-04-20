using Ambev.Tech.DeveloperStore.Domain.Entities;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using Ambev.Tech.DeveloperStore.Infrastructure.Services;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;


namespace Ambev.Tech.DeveloperStore.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        private readonly JwtTokenGenerator _jwtService;

        public AuthRepository(AppDbContext context, JwtTokenGenerator jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthTokenDto> LoginAsync(LoginDto login)
        {

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

            if (user == null) return null;

            var token = _jwtService.GenerateToken(user);

            return new AuthTokenDto
            {
                Token = token
            };
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            return _jwtService.ValidateToken(token);
        }
    }
}
