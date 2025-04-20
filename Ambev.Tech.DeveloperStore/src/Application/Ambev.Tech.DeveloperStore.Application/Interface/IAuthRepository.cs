using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Interface
{
    public interface IAuthRepository
    {
        Task<AuthTokenDto> LoginAsync(LoginDto authDto);
        Task<bool> ValidateTokenAsync(string token);
    }
}
