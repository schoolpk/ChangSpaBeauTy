// ChangSpaBeauty.Application/Services/ShoppingCartService.cs
using ChangSpaBeauty.Application.DTOs.ShoppingCart;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;

namespace ChangSpaBeauty.Application.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepo;
    private readonly IProductRepository _productRepo;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepo, IProductRepository productRepo)
    {
        _shoppingCartRepo = shoppingCartRepo;
        _productRepo = productRepo;
    }

    public async Task AddToCartAsync(int userId, int productId, int quantity = 1)
    {
        var product = await _productRepo.GetByIdAsync(productId);
        if(product == null)
        {
            throw new InvalidOperationException("Sản phẩm không tồn tại");
        }
        if(product.Stock <= 0)
        {
            throw new InvalidOperationException($"Sản phẩm \"{product.Name}\" đã hết hàng");
        }

        var cart = await _shoppingCartRepo.GetShoppingCartByUserAsync(userId);
        if (cart == null)
            cart = await _shoppingCartRepo.CreateCartAsync(userId);

        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

        int curentQty = existingItem?.Quantity ?? 0;
        int newQty = curentQty + quantity;
        if(newQty > product.Stock)
        {
            throw new InvalidOperationException(
                $"Sản phẩm \"{product.Name}\" chỉ còn {product.Stock} trong kho" +
                $"(Bạn có {curentQty} trong giỏ");
        }

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
                Stock = ci.Product?.Stock ?? 0,
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

        int stock = item.Product?.Stock ?? 0;
        if (quantity > stock)
        {
            quantity = stock;
        }

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