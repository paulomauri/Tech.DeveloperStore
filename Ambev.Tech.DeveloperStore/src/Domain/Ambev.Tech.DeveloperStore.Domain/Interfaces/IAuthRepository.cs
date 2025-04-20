using Ambev.Tech.DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthToken> GenerateTokenAsync(int userId, string username);
        Task<bool> ValidateTokenAsync(string token);
        Task InvalidateTokenAsync(string token);
    }
}
