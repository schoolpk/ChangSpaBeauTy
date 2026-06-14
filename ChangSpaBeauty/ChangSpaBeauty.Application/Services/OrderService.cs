using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Application.DTOs.Order;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IShoppingCartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly IUserRepository _userRepo;
        private readonly INotificationRepository _notificationRepo;

        public OrderService(IShoppingCartRepository cartRepo,
            IOrderRepository orderRepo,
            IProductRepository productRepo,
            IUserRepository userRepo,
            INotificationRepository notificationRepo)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _userRepo = userRepo;
            _notificationRepo = notificationRepo;
        }

        public async Task<OrderDto?> GetOrderAsync(int orderId, int userId)
        {
            var order = await _orderRepo.GetOrderAsync(orderId, userId);
            if(order == null)
            {
                return null;
            }
            return new OrderDto
            {
                OrderId = orderId,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                Address = order.Address,
                Phone = order.Phone,
                CreatedAt = order.CreatedAt,
                Items = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductName = od.Product?.Name ?? "",
                    ProductImage = od.Product?.Image ?? "",
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                }).ToList()
            };
        }

        public async Task<(bool success, string message)> CancelOrderAsync(int orderId, int userId)
        {
            try
            {
                var order = await _orderRepo.GetOrderAsync(orderId, userId);
                if (order == null)
                    return (false, "Không có đơn hàng nào");

                if (order.Status == "shipping" || order.Status == "done")
                    return (false, "Không thể hủy đơn hàng khi đang giao hoặc đã hoàn thành");

                await _orderRepo.UpdateOrderAsync(orderId, "cancelled");

                Console.WriteLine($"[DEBUG] Order {orderId} cancelled");

                var adminUser = await _userRepo.GetAdminAsync();
                Console.WriteLine($"[DEBUG] Admin: {adminUser?.Id} - {adminUser?.Name}");

                if (adminUser != null)
                {
                    var customer = await _userRepo.GetByIdAsync(userId);
                    await _notificationRepo.AddAsync(new Notification
                    {
                        UserId = adminUser.Id,
                        Message = $"❌ Khách hàng {customer?.Name ?? "N/A"} vừa hủy đơn #{orderId} ({order.TotalPrice.ToString("N0")} ₫)",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    });
                    Console.WriteLine($"[DEBUG] Notification saved!");
                }

                return (true, "Đã hủy đơn hàng thành công");
            }
            catch (Exception ex)
            {
                // In toàn bộ lỗi ra Output
                Console.WriteLine($"[ERROR] CancelOrderAsync: {ex.Message}");
                Console.WriteLine($"[ERROR] StackTrace: {ex.StackTrace}");
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<List<OrderDto>> GetUserOrderAsync(int userId)
        {
            var orders = await _orderRepo.GetOrdersByUserAsync(userId);
            return orders.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                TotalPrice = o.TotalPrice,
                Status = o.Status,
                Address = o.Address,
                Phone = o.Phone,
                CreatedAt = o.CreatedAt,
                Items = o.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductName = od.Product?.Name ?? "",
                    ProductImage = od.Product?.Image ?? "",
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                }).ToList()
            }).ToList();
        }

        public async Task<int> PlaceOrderAsync(int userId, OrderDto dto)
        {
            var cart = await _cartRepo.GetShoppingCartByUserAsync(userId);
            if(cart == null || !cart.CartItems.Any())
            {
                throw new InvalidOperationException("Không có sản phẩm");
            }
            var order = new Order
            {
                UserId = userId,
                Address = dto.Address,
                Phone= dto.Phone,
                Status = "pending",
                CreatedAt = DateTime.Now,
                TotalPrice = cart.CartItems.Sum(ci=>ci.Quantity * (ci.Product?.Price ?? 0)),
                OrderDetails = cart.CartItems.Select(ci=>new OrderDetail
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Product?.Price ?? 0
                }).ToList()
            };
            await _orderRepo.CreateOrderAsync(order);
            foreach (var item in cart.CartItems)
            {
                if (item.Product != null)
                {
                    item.Product.Sold += item.Quantity;
                    item.Product.Stock -= item.Quantity;
                    _productRepo.UpdateAsync(item.Product);
                }
            }

            await _cartRepo.ClearCartAsync(cart.ShoppingCartId);
            await _cartRepo.SaveChangeAsync();

            return order.OrderId;
        }
    }
}
