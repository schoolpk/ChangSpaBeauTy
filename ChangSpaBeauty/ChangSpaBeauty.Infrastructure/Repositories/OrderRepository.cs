using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Domain.Interfaces;
using ChangSpaBeauty.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var orderDetails = await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .ToListAsync();

            if (orderDetails.Any())
            {
                _context.OrderDetails.RemoveRange(orderDetails);
            }

            var order = await _context.Orders.FindAsync(orderId);
            if(order != null)
            {
                _context.Orders.Remove(order);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(u => u.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdWithUserAsync(int orderId)
        {
            return await _context.Orders
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<Order?> GetOrderAsync(int orderId, int userId)
        {
            return await _context.Orders
                .Include(o=>o.OrderDetails)
                .ThenInclude(od=>od.Product)
                .FirstOrDefaultAsync(o=>o.OrderId == orderId && o.UserId == userId);
        }

        public async Task<Order?> GetOrderWithDetailAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od=>od.Product)
                .FirstOrDefaultAsync(o=>o.OrderId == orderId);
        }

        public async Task UpdateOrderAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if(order == null)
            {
                return;
            }
            order.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
