using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDbContext _context;
        public ShoppingCartRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCartItemAsync(CartItem item)
        {
            await _context.CartItems.AddAsync(item);
        }
        
        public async Task ClearCartAsync(int shoppingCartId)
        {
            var items = await _context.CartItems
                .Where(ci => ci.ShoppingCartId == shoppingCartId)
            .ToListAsync();
            _context.CartItems.RemoveRange(items);
        }

        public async Task<ShoppingCart> CreateCartAsync(int userId)
        {
            var cart = new ShoppingCart { UserId = userId};
            await _context.ShoppingCarts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public Task DeleteCartItemAsync(CartItem item)
        {
            _context.CartItems.Remove(item);
            return Task.CompletedTask;
        }

        public async Task<ShoppingCart?> GetShoppingCartByUserAsync(int userId)
        {
            return await _context.ShoppingCarts
                .Include(c=>c.CartItems)
                .ThenInclude(ci=>ci.Product)
                .FirstOrDefaultAsync(c=>c.UserId == userId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateCartItemAsync(CartItem item)
        {
            _context.CartItems.Update(item);
            return Task.CompletedTask;
        }
    }
}
