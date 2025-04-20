using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;
using Domain.Entities;

namespace Ambev.Tech.DeveloperStore.Application.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task AddAsync(ProductDto product);
        Task DeleteAsync(int id);
    }
}
