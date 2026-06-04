using ChangSpaBeauty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart?> GetShoppingCartByUserAsync(int userId);
        Task<ShoppingCart> CreateCartAsync(int userId);
        Task AddCartItemAsync(CartItem item);
        Task UpdateCartItemAsync(CartItem item);
        Task DeleteCartItemAsync(CartItem item);
        Task ClearCartAsync(int shoppingCartId);
        Task SaveChangeAsync();

    }
}
