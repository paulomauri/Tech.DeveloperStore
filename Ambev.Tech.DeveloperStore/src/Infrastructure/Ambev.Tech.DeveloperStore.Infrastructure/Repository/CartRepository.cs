using Ambev.Tech.DeveloperStore.Domain.Entities;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Infrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddAsync(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return false;
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _context.Carts
                .Include(c => c.Items)
                .ToListAsync();
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cart?>> GetByUserIdAsync(int userId)
        {
            return await _context.Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.Items)
                .ToListAsync();
        }

        public async Task<Cart> UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();

            return cart;
        }
    }
}
