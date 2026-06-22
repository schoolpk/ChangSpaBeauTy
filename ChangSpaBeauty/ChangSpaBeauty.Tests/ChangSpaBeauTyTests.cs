// ============================================================
//  ChangSpaBeauTyTests.cs
//  20 Unit Tests – NUnit 4 – ChangSpaBeauTy
//
//  Nhóm:
//    [1–5]  Auth / User
//    [6–10] Product
//    [11–15] Cart
//    [16–20] Order
// ============================================================
using NUnit.Framework;
using ChangSpaBeauTy.Tests.Helpers;
using ChangSpaBeauTy.Tests.Stubs;

namespace ChangSpaBeauTy.Tests.Tests;

[TestFixture]
public class ChangSpaBeauTyTests
{
    // ══════════════════════════════════════════════════════════
    //  NHÓM 1 – AUTH / USER (TC01–TC05)
    // ══════════════════════════════════════════════════════════

    /// <summary>
    /// TC01 – Email hợp lệ phải được chấp nhận.
    /// </summary>
    [Test]
    public void TC01_ValidEmail_ShouldReturnTrue()
    {
        // Arrange
        string email = "user@example.com";

        // Act
        bool result = AuthLogic.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True,
            "Email hợp lệ phải trả về true");
    }

    /// <summary>
    /// TC02 – Email thiếu ký tự '@' phải bị từ chối.
    /// </summary>
    [Test]
    public void TC02_InvalidEmail_MissingAt_ShouldReturnFalse()
    {
        // Arrange
        string email = "userexample.com";

        // Act
        bool result = AuthLogic.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.False,
            "Email thiếu '@' phải trả về false");
    }

    /// <summary>
    /// TC03 – Password đủ 6 ký tự phải hợp lệ.
    /// </summary>
    [Test]
    public void TC03_PasswordMinLength_ShouldBeValid()
    {
        // Arrange
        string password = "abc123";

        // Act
        bool result = AuthLogic.IsValidPassword(password);

        // Assert
        Assert.That(result, Is.True,
            "Password đúng 6 ký tự phải hợp lệ");
    }

    /// <summary>
    /// TC04 – Password dưới 6 ký tự phải bị từ chối.
    /// </summary>
    [Test]
    public void TC04_PasswordTooShort_ShouldBeInvalid()
    {
        // Arrange
        string password = "12345";   // 5 ký tự

        // Act
        bool result = AuthLogic.IsValidPassword(password);

        // Assert
        Assert.That(result, Is.False,
            "Password dưới 6 ký tự phải trả về false");
    }

    /// <summary>
    /// TC05 – BCrypt hash & verify phải khớp.
    /// </summary>
    [Test]
    public void TC05_HashAndVerifyPassword_ShouldMatch()
    {
        // Arrange
        string plainPassword = "SecurePass@123";

        // Act
        string hashed = AuthLogic.HashPassword(plainPassword);
        bool   valid  = AuthLogic.VerifyPassword(plainPassword, hashed);

        // Assert
        Assert.That(valid, Is.True,
            "Verify phải trả về true khi plain text khớp hash");
    }

    // ══════════════════════════════════════════════════════════
    //  NHÓM 2 – PRODUCT (TC06–TC10)
    // ══════════════════════════════════════════════════════════

    /// <summary>
    /// TC06 – Lọc sản phẩm theo danh mục phải trả về đúng kết quả.
    /// </summary>
    [Test]
    public void TC06_FilterByCategory_ShouldReturnCorrectProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { ProductId = 1, Name = "Kem dưỡng A", CategoryId = 1 },
            new() { ProductId = 2, Name = "Son môi B",   CategoryId = 2 },
            new() { ProductId = 3, Name = "Serum C",     CategoryId = 1 },
        };

        // Act
        var result = ProductLogic.FilterByCategory(products, categoryId: 1).ToList();

        // Assert
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.All(p => p.CategoryId == 1), Is.True);
    }

    /// <summary>
    /// TC07 – Tìm kiếm sản phẩm theo từ khóa (không phân biệt hoa thường).
    /// </summary>
    [Test]
    public void TC07_SearchProduct_CaseInsensitive_ShouldWork()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { ProductId = 1, Name = "Kem dưỡng ẩm" },
            new() { ProductId = 2, Name = "Son Môi hồng" },
            new() { ProductId = 3, Name = "KEM chống nắng" },
        };

        // Act
        var result = ProductLogic.Search(products, "kem").ToList();

        // Assert
        Assert.That(result.Count, Is.EqualTo(2),
            "Phải tìm thấy 2 sản phẩm chứa 'kem' (không phân biệt hoa thường)");
    }

    /// <summary>
    /// TC08 – Sắp xếp theo giá tăng dần (price-asc).
    /// </summary>
    [Test]
    public void TC08_SortByPriceAsc_ShouldOrderCorrectly()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { ProductId = 1, Name = "A", Price = 500_000m },
            new() { ProductId = 2, Name = "B", Price = 100_000m },
            new() { ProductId = 3, Name = "C", Price = 300_000m },
        };

        // Act
        var sorted = ProductLogic.SortBy(products, "price-asc").ToList();

        // Assert
        Assert.That(sorted[0].Price, Is.EqualTo(100_000m));
        Assert.That(sorted[2].Price, Is.EqualTo(500_000m));
    }

    /// <summary>
    /// TC09 – CalcStockPercent khi hết hàng phải trả về 100.
    /// </summary>
    [Test]
    public void TC09_CalcStockPercent_OutOfStock_ShouldReturn100()
    {
        // Arrange / Act
        int percent = ProductLogic.CalcStockPercent(sold: 50, stock: 0);

        // Assert
        Assert.That(percent, Is.EqualTo(100),
            "Khi stock = 0 phải trả về 100%");
    }

    /// <summary>
    /// TC10 – CalcStockPercent không được vượt quá 95.
    /// </summary>
    [Test]
    public void TC10_CalcStockPercent_NeverExceeds95()
    {
        // Arrange – bán cực nhiều, stock còn rất ít
        int percent = ProductLogic.CalcStockPercent(sold: 9999, stock: 1);

        // Assert
        Assert.That(percent, Is.LessThanOrEqualTo(95),
            "StockPercent phải <= 95 để vẫn hiện thanh còn hàng");
    }

    // ══════════════════════════════════════════════════════════
    //  NHÓM 3 – CART (TC11–TC15)
    // ══════════════════════════════════════════════════════════

    /// <summary>
    /// TC11 – Thêm vào giỏ khi sản phẩm hết hàng phải thất bại.
    /// </summary>
    [Test]
    public void TC11_AddToCart_OutOfStock_ShouldFail()
    {
        // Arrange
        var product = new Product { Name = "Kem A", Stock = 0, Price = 200_000m };

        // Act
        var (ok, msg) = CartLogic.ValidateAddToCart(product, currentQty: 0, addQty: 1);

        // Assert
        Assert.That(ok, Is.False);
        Assert.That(msg, Does.Contain("hết hàng"));
    }

    /// <summary>
    /// TC12 – Thêm vào giỏ vượt quá stock phải thất bại.
    /// </summary>
    [Test]
    public void TC12_AddToCart_ExceedsStock_ShouldFail()
    {
        // Arrange
        var product = new Product { Name = "Serum B", Stock = 5, Price = 300_000m };

        // Act – đã có 4 trong giỏ, muốn thêm 3 nữa → tổng 7 > stock 5
        var (ok, msg) = CartLogic.ValidateAddToCart(product, currentQty: 4, addQty: 3);

        // Assert
        Assert.That(ok, Is.False);
        Assert.That(msg, Does.Contain("5"));   // thông báo chứa số stock
    }

    /// <summary>
    /// TC13 – Thêm vào giỏ hợp lệ phải thành công.
    /// </summary>
    [Test]
    public void TC13_AddToCart_ValidQuantity_ShouldSucceed()
    {
        // Arrange
        var product = new Product { Name = "Son C", Stock = 10, Price = 150_000m };

        // Act
        var (ok, _) = CartLogic.ValidateAddToCart(product, currentQty: 2, addQty: 3);

        // Assert
        Assert.That(ok, Is.True);
    }

    /// <summary>
    /// TC14 – GrandTotal của giỏ hàng phải bằng tổng (price × qty) từng item.
    /// </summary>
    [Test]
    public void TC14_CartDTO_GrandTotal_ShouldBeCorrect()
    {
        // Arrange
        var cart = new ShoppingCartDTO
        {
            Items =
            [
                new() { Price = 200_000m, Quantity = 2 },  // 400 000
                new() { Price = 150_000m, Quantity = 1 },  // 150 000
            ]
        };

        // Act
        decimal total = cart.GrandTotal;

        // Assert
        Assert.That(total, Is.EqualTo(550_000m));
    }

    /// <summary>
    /// TC15 – ClampQuantity không được nhỏ hơn 1 và không lớn hơn stock.
    /// </summary>
    [Test]
    public void TC15_ClampQuantity_ShouldRespectBounds()
    {
        // Giới hạn trên
        int clamped = CartLogic.ClampQuantity(requested: 99, stock: 10);
        Assert.That(clamped, Is.EqualTo(10), "Phải clamp về stock khi vượt quá");

        // Giới hạn dưới
        int min = CartLogic.ClampQuantity(requested: 0, stock: 10);
        Assert.That(min, Is.EqualTo(1), "Số lượng tối thiểu là 1");
    }

    // ══════════════════════════════════════════════════════════
    //  NHÓM 4 – ORDER (TC16–TC20)
    // ══════════════════════════════════════════════════════════

    /// <summary>
    /// TC16 – Trạng thái 'pending' được phép hủy.
    /// </summary>
    [Test]
    public void TC16_CancelOrder_PendingStatus_ShouldBeAllowed()
    {
        bool canCancel = OrderLogic.CanCancel("pending");
        Assert.That(canCancel, Is.True);
    }

    /// <summary>
    /// TC17 – Trạng thái 'shipping' không được phép hủy.
    /// </summary>
    [Test]
    public void TC17_CancelOrder_ShippingStatus_ShouldBeForbidden()
    {
        bool canCancel = OrderLogic.CanCancel("shipping");
        Assert.That(canCancel, Is.False);
    }

    /// <summary>
    /// TC18 – Trạng thái 'done' không được phép hủy.
    /// </summary>
    [Test]
    public void TC18_CancelOrder_DoneStatus_ShouldBeForbidden()
    {
        bool canCancel = OrderLogic.CanCancel("done");
        Assert.That(canCancel, Is.False);
    }

    /// <summary>
    /// TC19 – Tính tổng tiền đơn hàng từ các CartItem.
    /// </summary>
    [Test]
    public void TC19_CalcOrderTotal_FromCartItems_ShouldBeCorrect()
    {
        // Arrange
        var items = new List<CartItem>
        {
            new() { Quantity = 2, Product = new Product { Price = 300_000m } },
            new() { Quantity = 1, Product = new Product { Price = 150_000m } },
        };

        // Act
        decimal total = OrderLogic.CalcTotal(items);

        // Assert
        Assert.That(total, Is.EqualTo(750_000m));
    }

    /// <summary>
    /// TC20 – GetStatusLabel phải trả về nhãn hiển thị đúng.
    /// </summary>
    [Test]
    public void TC20_GetStatusLabel_ShouldReturnCorrectLabel()
    {
        Assert.Multiple(() =>
        {
            Assert.That(OrderLogic.GetStatusLabel("pending"),   Does.Contain("Chờ xác nhận"));
            Assert.That(OrderLogic.GetStatusLabel("confirmed"), Does.Contain("Đã xác nhận"));
            Assert.That(OrderLogic.GetStatusLabel("shipping"),  Does.Contain("Đang giao"));
            Assert.That(OrderLogic.GetStatusLabel("done"),      Does.Contain("Hoàn thành"));
            Assert.That(OrderLogic.GetStatusLabel("cancelled"), Does.Contain("Đã hủy"));
        });
    }
}
