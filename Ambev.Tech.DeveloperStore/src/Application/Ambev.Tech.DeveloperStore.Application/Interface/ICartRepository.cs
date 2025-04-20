using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Interface
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartDto>> GetAllAsync();
        Task<CartDto> GetByIdAsync(int id);
        Task<CartDto> GetByUserIdAsync(int userId);
        Task<CartDto> CreateAsync(CartDto cartDto);
        Task<CartDto> UpdateAsync(int id, CartDto cartDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ClearCartAsync(int id);
        Task<CartDto> AddProductAsync(int cartId, int productId, int quantity);
    }
}
