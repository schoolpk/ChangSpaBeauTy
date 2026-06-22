// ============================================================
//  AuthLogic – logic thuần túy từ AuthService (không phụ thuộc DB)
//  Dùng để unit test mà không cần mock EF / repository.
// ============================================================
using BCrypt.Net;
using ChangSpaBeauTy.Tests.Stubs;

namespace ChangSpaBeauTy.Tests.Helpers;

public static class AuthLogic
{
    // Validate email format đơn giản
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        var parts = email.Split('@');
        if (parts.Length != 2) return false;
        if (string.IsNullOrEmpty(parts[0])) return false;
        if (!parts[1].Contains('.')) return false;
        return true;
    }

    // Validate password tối thiểu 6 ký tự
    public static bool IsValidPassword(string password) =>
        !string.IsNullOrEmpty(password) && password.Length >= 6;

    // Hash & verify password
    public static string HashPassword(string plain) =>
        BCrypt.Net.BCrypt.HashPassword(plain);

    public static bool VerifyPassword(string plain, string hash) =>
        BCrypt.Net.BCrypt.Verify(plain, hash);

    // Validate register DTO
    public static (bool ok, string msg) ValidateRegister(UserRegisterDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return (false, "Họ tên không được để trống");
        if (!IsValidEmail(dto.Email))
            return (false, "Email không hợp lệ");
        if (!IsValidPassword(dto.Password))
            return (false, "Mật khẩu tối thiểu 6 ký tự");
        if (dto.Password != dto.ConfirmPassword)
            return (false, "Mật khẩu xác nhận không khớp");
        return (true, "OK");
    }
}

// ── OrderLogic – business rules từ OrderService / CancelOrderAsync ──
public static class OrderLogic
{
    public static bool CanCancel(string status) =>
        status is "pending" or "confirmed";

    public static decimal CalcTotal(IEnumerable<CartItem> items) =>
        items.Sum(ci => ci.Quantity * (ci.Product?.Price ?? 0m));

    public static string GetStatusLabel(string status) => status switch
    {
        "pending"   => "⏳ Chờ xác nhận",
        "confirmed" => "✅ Đã xác nhận",
        "shipping"  => "🚚 Đang giao",
        "done"      => "✔️ Hoàn thành",
        "cancelled" => "❌ Đã hủy",
        _           => status
    };
}

// ── CartLogic – business rules từ ShoppingCartService ───────────────
public static class CartLogic
{
    public static (bool ok, string msg) ValidateAddToCart(
        Product product, int currentQty, int addQty)
    {
        if (product.Stock <= 0)
            return (false, $"Sản phẩm \"{product.Name}\" đã hết hàng");

        int newQty = currentQty + addQty;
        if (newQty > product.Stock)
            return (false, $"Sản phẩm \"{product.Name}\" chỉ còn {product.Stock} trong kho");

        return (true, "OK");
    }

    public static int ClampQuantity(int requested, int stock) =>
        requested > stock ? stock : Math.Max(1, requested);

    public static ShoppingCartDTO ToCartDTO(ShoppingCart cart) => new()
    {
        ShoppingCartId = cart.ShoppingCartId,
        Items = cart.CartItems.Select(ci => new ShoppingCartItemDTO
        {
            CartItemId   = ci.Id,
            ProductId    = ci.ProductId,
            ProductName  = ci.Product?.Name  ?? string.Empty,
            ProductImage = ci.Product?.Image ?? string.Empty,
            Price        = ci.Product?.Price ?? 0m,
            Stock        = ci.Product?.Stock ?? 0,
            Quantity     = ci.Quantity
        }).ToList()
    };
}

// ── ProductLogic – business rules từ ProductService ─────────────────
public static class ProductLogic
{
    public static IEnumerable<Product> FilterByCategory(
        IEnumerable<Product> products, int categoryId) =>
        products.Where(p => p.CategoryId == categoryId);

    public static IEnumerable<Product> Search(
        IEnumerable<Product> products, string keyword) =>
        products.Where(p =>
            p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));

    public static IEnumerable<Product> SortBy(
        IEnumerable<Product> products, string sort) => sort switch
    {
        "newest"      => products.OrderByDescending(p => p.ProductId),
        "bestselling" => products.OrderByDescending(p => p.Sold),
        "price-asc"   => products.OrderBy(p => p.Price),
        "price-desc"  => products.OrderByDescending(p => p.Price),
        _             => products.OrderByDescending(p => p.Sold)
    };

    public static int CalcStockPercent(int sold, int stock)
    {
        if (stock <= 0) return 100;
        return Math.Min((int)((double)sold / (sold + stock) * 100), 95);
    }
}
