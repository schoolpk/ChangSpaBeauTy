using ChangSpaBeauty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdWithUserAsync(int orderId);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(int  orderId, string status);
        Task<Order?> GetOrderAsync(int orderId, int userId);
        Task DeleteOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllAsync();
    }
}
