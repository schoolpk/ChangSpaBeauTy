using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Domain.Interfaces;
using ChangSpaBeauty.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o=>o.OrderDetails).ToListAsync();
        }

        public async Task<Order?> GetOrderAsync(int orderId, int userId)
        {
            return await _context.Orders
                .Include(o=>o.OrderDetails)
                .ThenInclude(od=>od.Product)
                .FirstOrDefaultAsync(o=>o.OrderId == orderId && o.UserId == userId);
        }
    }
}
