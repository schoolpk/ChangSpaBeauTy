using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Application.DTOs.Order;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    ProductId = od.ProductId,
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
                {
                    return (false, "Không có đơn hàng nào");
                }

                if (order.Status == "shipping" || order.Status == "done")
                {
                    return (false, "Không thể hủy đơn hàng khi đang giao hoặc đã hoàn thành");
                }
                
                if(order.Status == "cancelled")
                {
                    return (false, "Đơn hàng đã bị hủy trước đó");
                }

                await _orderRepo.UpdateOrderAsync(orderId, "cancelled");

                foreach(var detail in order.OrderDetails)
                {
                    var product = await _productRepo.GetByIdAsync(detail.ProductId);
                    if (product != null)
                    {
                        product.Sold -= detail.Quantity;
                        product.Stock += detail.Quantity;
                        if(product.Sold < 0)
                        {
                            product.Sold = 0;
                        }
                        _productRepo.UpdateAsync(product);
                    }
                }

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
                    ProductId = od.ProductId,
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

            foreach(var item in cart.CartItems)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if(product == null)
                {
                    throw new InvalidOperationException("Sản phẩm không tồn tại");
                }
                if(item.Quantity > product.Stock)
                {
                    throw new InvalidOperationException(
                        $"Sản phẩm \"{product.Name}\" chỉ còn {product.Stock} trong kho +" +
                        $"bạn đang đặt {item.Quantity}");
                }
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

        public async Task<(bool success, string message)> UpdateOrderAsync(int userId, UpdateOrderDto dto)
        {
            try
            {
                // Lấy order kèm details, đảm bảo đúng user
                var order = await _orderRepo.GetOrderAsync(dto.OrderId, userId);
                if (order == null)
                    return (false, "Không tìm thấy đơn hàng");

                // Chỉ cho sửa khi pending
                if (order.Status != "pending")
                    return (false, "Chỉ có thể sửa đơn hàng khi đang chờ xác nhận");

                if (!dto.Items.Any())
                    return (false, "Đơn hàng phải có ít nhất 1 sản phẩm");

                // Lấy lại order có tracking (vì GetOrderAsync dùng AsNoTracking)
                var trackedOrder = await _orderRepo.GetOrderWithDetailAsync(dto.OrderId);
                if (trackedOrder == null)
                    return (false, "Không tìm thấy đơn hàng");

                // Hoàn lại stock cũ trước khi áp dụng số lượng mới
                foreach (var oldDetail in trackedOrder.OrderDetails)
                {
                    var product = await _productRepo.GetByIdAsync(oldDetail.ProductId);
                    if (product != null)
                    {
                        product.Stock += oldDetail.Quantity;
                        product.Sold -= oldDetail.Quantity;
                        if (product.Sold < 0) product.Sold = 0;
                        _productRepo.UpdateAsync(product);
                    }
                }

                // Validate stock đủ cho số lượng mới
                foreach (var item in dto.Items)
                {
                    var product = await _productRepo.GetByIdAsync(item.ProductId);
                    if (product == null)
                        return (false, "Sản phẩm không tồn tại");
                    if (item.Quantity > product.Stock)
                        return (false, $"Sản phẩm \"{product.Name}\" chỉ còn {product.Stock} trong kho");
                }

                // Xóa hết OrderDetails cũ, thêm lại theo số lượng mới
                trackedOrder.OrderDetails.Clear();
                decimal newTotal = 0;

                foreach (var item in dto.Items)
                {
                    var product = await _productRepo.GetByIdAsync(item.ProductId);
                    if (product == null) continue;

                    trackedOrder.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price
                    });

                    newTotal += product.Price * item.Quantity;

                    // Trừ lại stock theo số lượng mới
                    product.Stock -= item.Quantity;
                    product.Sold += item.Quantity;
                    _productRepo.UpdateAsync(product);
                }

                trackedOrder.Address = dto.Address;
                trackedOrder.Phone = dto.Phone;
                trackedOrder.TotalPrice = newTotal;

                await _orderRepo.UpdateOrderDetailsAsync(trackedOrder);

                return (true, "Cập nhật đơn hàng thành công");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }
    }
}
