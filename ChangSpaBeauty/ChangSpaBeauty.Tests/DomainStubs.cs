// ============================================================
//  Stubs – bản rút gọn của Domain entities & Application DTOs
//  Dùng để test project có thể chạy độc lập (không reference
//  các project gốc, tránh phụ thuộc DB / EF Core).
// ============================================================
namespace ChangSpaBeauTy.Tests.Stubs;

// ── Domain Entities ─────────────────────────────────────────
public class User
{
    public int    Id       { get; set; }
    public string Role     { get; set; } = string.Empty;
    public string Name     { get; set; } = string.Empty;
    public string Email    { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Phone   { get; set; }
    public string? Address { get; set; }
}

public class Category
{
    public int     CategoryId { get; set; }
    public string  Name       { get; set; } = string.Empty;
    public int     Total      { get; set; }
    public string? Trademark  { get; set; }
    public ICollection<Product>? Products { get; set; }
}

public class Product
{
    public int      ProductId   { get; set; }
    public string   Name        { get; set; } = string.Empty;
    public decimal  Price       { get; set; }
    public string?  Image       { get; set; }
    public int      CategoryId  { get; set; }
    public Category? Category   { get; set; }
    public int      Sold        { get; set; }
    public int      Stock       { get; set; }
    public string?  Description { get; set; }
    public DateTime? CreatedAt  { get; set; }
}

public class ShoppingCart
{
    public int   ShoppingCartId { get; set; }
    public int   UserId         { get; set; }
    public User? User           { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
}

public class CartItem
{
    public int           Id             { get; set; }
    public int           ShoppingCartId { get; set; }
    public int           ProductId      { get; set; }
    public int           Quantity       { get; set; }
    public ShoppingCart? ShoppingCart   { get; set; }
    public Product?      Product        { get; set; }
}

public class Order
{
    public int      OrderId    { get; set; }
    public int      UserId     { get; set; }
    public decimal  TotalPrice { get; set; }
    public string   Status     { get; set; } = "pending";
    public string   Address    { get; set; } = string.Empty;
    public string   Phone      { get; set; } = string.Empty;
    public DateTime CreatedAt  { get; set; } = DateTime.Now;
    public User?    User       { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

public class OrderDetail
{
    public int      Id        { get; set; }
    public int      OrderId   { get; set; }
    public int      ProductId { get; set; }
    public int      Quantity  { get; set; }
    public decimal  UnitPrice { get; set; }
    public Order?   Order     { get; set; }
    public Product? Product   { get; set; }
}

// ── Application DTOs ────────────────────────────────────────
public class UserRegisterDTO
{
    public string Name            { get; set; } = string.Empty;
    public string Email           { get; set; } = string.Empty;
    public string Password        { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public string Phone           { get; set; } = string.Empty;
    public string Address         { get; set; } = string.Empty;
}

public class UserLoginDTO
{
    public string Email    { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool   RememberMe { get; set; }
}

public class ProductDto
{
    public int     ProductId    { get; set; }
    public string  Name         { get; set; } = string.Empty;
    public decimal Price        { get; set; }
    public string? Image        { get; set; }
    public int     CategoryId   { get; set; }
    public string  CategoryName { get; set; } = string.Empty;
    public int     Sold         { get; set; }
    public int     Stock        { get; set; }
    public string? Description  { get; set; }
    public string? Trademark    { get; set; }
}

public class ShoppingCartDTO
{
    public int   ShoppingCartId { get; set; }
    public List<ShoppingCartItemDTO> Items { get; set; } = new();
    public decimal GrandTotal  => Items.Sum(i => i.Total);
    public int     TotalItems  => Items.Sum(i => i.Quantity);
}

public class ShoppingCartItemDTO
{
    public int     CartItemId   { get; set; }
    public int     ProductId    { get; set; }
    public string  ProductName  { get; set; } = string.Empty;
    public string  ProductImage { get; set; } = string.Empty;
    public decimal Price        { get; set; }
    public int     Quantity     { get; set; } = 1;
    public int     Stock        { get; set; }
    public decimal Total        => Price * Quantity;
}

public class OrderDto
{
    public int     OrderId    { get; set; }
    public decimal TotalPrice { get; set; }
    public string  Status     { get; set; } = string.Empty;
    public string  Address    { get; set; } = string.Empty;
    public string  Phone      { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<OrderDetailDto> Items { get; set; } = new();
}

public class OrderDetailDto
{
    public string  ProductName  { get; set; } = string.Empty;
    public string  ProductImage { get; set; } = string.Empty;
    public int     Quantity     { get; set; }
    public decimal UnitPrice    { get; set; }
    public decimal Subtotal     => UnitPrice * Quantity;
}
