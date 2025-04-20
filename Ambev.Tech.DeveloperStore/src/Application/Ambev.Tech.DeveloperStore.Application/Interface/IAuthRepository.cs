using Ambev.Tech.DeveloperStore.Domain.Entities;
using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;

namespace Ambev.Tech.DeveloperStore.Application.Interface
{
    public interface IAuthRepository
    {
        Task<AuthTokenDto> LoginAsync(LoginDto authDto);
        Task<bool> ValidateTokenAsync(string token);
    }
}
