// ChangSpaBeauty.Application/Services/ShoppingCartService.cs
using ChangSpaBeauty.Application.DTOs.ShoppingCart;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;

namespace ChangSpaBeauty.Application.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepo;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepo)
    {
        _shoppingCartRepo = shoppingCartRepo;
    }

    public async Task AddToCartAsync(int userId, int productId, int quantity = 1)
    {
        var cart = await _shoppingCartRepo.GetShoppingCartByUserAsync(userId);
        if (cart == null)
            cart = await _shoppingCartRepo.CreateCartAsync(userId);

        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
            await _shoppingCartRepo.UpdateCartItemAsync(existingItem);
        }
        else
        {
            var newItem = new CartItem
            {
                ShoppingCartId = cart.ShoppingCartId,
                ProductId = productId,
                Quantity = quantity
            };
            await _shoppingCartRepo.AddCartItemAsync(newItem);
        }

        await _shoppingCartRepo.SaveChangeAsync();
    }

    public async Task<ShoppingCartDTO> GetCartAsync(int userId)
    {
        var cart = await _shoppingCartRepo.GetShoppingCartByUserAsync(userId);
        if (cart == null)
            cart = await _shoppingCartRepo.CreateCartAsync(userId);

        return new ShoppingCartDTO
        {
            ShoppingCartId = cart.ShoppingCartId,
            Items = cart.CartItems.Select(ci => new ShoppingCartItemDTO
            {
                CartItemId = ci.Id,
                ProductId = ci.ProductId,
                ProductName = ci.Product?.Name ?? string.Empty,
                ProductImage = ci.Product?.Image ?? string.Empty,
                Price = ci.Product?.Price ?? 0,
                Quantity = ci.Quantity
            }).ToList()
        };
    }

    public async Task UpdateQuantityAsync(int userId, int cartItemId, int quantity)
    {
        var cart = await _shoppingCartRepo.GetShoppingCartByUserAsync(userId);
        if (cart == null) return;

        var item = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
        if (item == null) return;

        if (quantity <= 0)
            await _shoppingCartRepo.DeleteCartItemAsync(item);
        else
        {
            item.Quantity = quantity;
            await _shoppingCartRepo.UpdateCartItemAsync(item);
        }

        await _shoppingCartRepo.SaveChangeAsync();
    }

    public async Task DeleteAsync(int userId, int cartItemId)
    {
        var cart = await _shoppingCartRepo.GetShoppingCartByUserAsync(userId);
        if (cart == null) return;

        var item = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
        if (item != null)
        {
            await _shoppingCartRepo.DeleteCartItemAsync(item);
            await _shoppingCartRepo.SaveChangeAsync();
        }
    }

    public async Task ClearCartAsync(int userId)
    {
        var cart = await _shoppingCartRepo.GetShoppingCartByUserAsync(userId);
        if (cart == null) return;

        await _shoppingCartRepo.ClearCartAsync(cart.ShoppingCartId);
        await _shoppingCartRepo.SaveChangeAsync();
    }

    public async Task<int> GetCartItemCountAsync(int userId)
    {
        var cart = await _shoppingCartRepo.GetShoppingCartByUserAsync(userId);
        return cart?.CartItems.Sum(ci => ci.Quantity) ?? 0;
    }
}