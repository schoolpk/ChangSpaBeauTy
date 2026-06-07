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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeteleAsync(int userId)
        {
            var orderDs = await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => o.OrderId)
                .ToListAsync();
            if (orderDs.Any())
            {
                var orderDetails = await _context.OrderDetails
                    .Where(od => orderDs.Contains(od.OrderId))
                    .ToListAsync();
                _context.OrderDetails.RemoveRange(orderDetails);

                var orders = await _context.Orders
                    .Where(o => orderDs.Contains(o.OrderId))
                    .ToListAsync();
                _context.Orders.RemoveRange(orders);
            }

            var cart = await _context.ShoppingCarts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart!=null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);
                _context.ShoppingCarts.Remove(cart);
            }

            var user = await _context.Users.FindAsync(userId);
            if(user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
