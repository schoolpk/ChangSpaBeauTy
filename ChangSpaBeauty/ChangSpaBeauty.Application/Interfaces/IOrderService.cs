using ChangSpaBeauty.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.Interfaces
{
    public interface IOrderService
    {
        Task<int> PlaceOrderAsync(int userId, OrderDto dto); 
        Task CancelOrderAsync(int orderId);
        Task<OrderDto?> GetOrderAsync(int orderId, int userId);
        Task<List<OrderDto>> GetUserOrderAsync(int userId);
        Task<(bool success, string message)> CancelOrderAsync(int orderId, int userId);
    }
}
