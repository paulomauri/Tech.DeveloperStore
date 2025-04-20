using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Interface
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart?> GetByIdAsync(int id);
        Task<IEnumerable<Cart?>> GetByUserIdAsync(int userId);
        Task<CartDto> AddAsync(Cart cart);
        Task<CartDto> UpdateAsync(Cart cart);
        Task<bool> DeleteAsync(int id);
    }
}
