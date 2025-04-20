using Ambev.Tech.DeveloperStore.Domain.Entities;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using Ambev.Tech.DeveloperStore.Infrastructure.Services;


namespace Ambev.Tech.DeveloperStore.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        private readonly JwtService _jwtService;

        public AuthRepository(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthToken> LoginAsync(LoginDto login)
        {

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == login.Username && u.PasswordHash == login.Password);

            if (user == null) return null;

            var token = _jwtService.GenerateToken(user.Username);

            return new AuthToken
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
