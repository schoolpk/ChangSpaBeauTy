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
        Task CreateOrderAsync(Order order);
        Task<Order?> GetOrderAsync(int orderId, int userId);
        Task<IEnumerable<Order>> GetAllAsync();
    }
}
