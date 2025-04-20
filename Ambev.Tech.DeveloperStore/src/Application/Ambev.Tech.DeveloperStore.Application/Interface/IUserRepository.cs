using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> GetByUsernameAsync(string username);
        Task<UserDto> CreateAsync(UserDto userDto);
        Task<UserDto> UpdateAsync(int id, UserDto userDto);
        Task<bool> DeleteAsync(int id);
    }
}
