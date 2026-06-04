using ChangSpaBeauty.Application.DTOs.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDTO> GetCartAsync(int userId);
        Task AddToCartAsync(int userId, int productId, int quantity = 1);
        Task UpdateQuantityAsync(int userId, int cartItemId, int quantity);
        Task DeleteAsync(int userId,int cartItemId);
        Task ClearCartAsync(int userId);
        Task<int> GetCartItemCountAsync(int userId);
    }
}
