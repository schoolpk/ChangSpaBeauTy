using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text;
namespace ChangSpaBeauty.Infrastructure.Persistence;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");
            entity.HasKey(p => p.ProductId);

            entity.Property(p => p.ProductId).HasColumnName("product_id");
            entity.Property(p => p.Name).HasColumnName("name");
            entity.Property(p => p.Price).HasColumnName("price");
            entity.Property(p => p.Image).HasColumnName("image");
            entity.Property(p => p.CategoryId).HasColumnName("category_id");
            entity.Property(p => p.Sold).HasColumnName("sold");
            entity.Property(p => p.Description).HasColumnName("description"); 
            entity.Property(p => p.Stock).HasColumnName("stock");             
            entity.Property(p => p.CreatedAt).HasColumnName("created_at");
            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CategoryId);
        });


        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.ToTable("ShoppingCart");
            entity.HasKey(sc => sc.ShoppingCartId);
            entity.Property(sc => sc.ShoppingCartId).HasColumnName("shoppingcart_id");
            entity.Property(sc=>sc.UserId).HasColumnName("user_id");
            entity.HasOne(sc => sc.User)
                    .WithOne(u=>u.ShoppingCart)
                    .HasForeignKey<ShoppingCart>(sc => sc.UserId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
            entity.HasKey(c => c.CategoryId);
            entity.Property(c=>c.CategoryId).HasColumnName("category_id");
            entity.Property(c => c.Name).HasColumnName("name");
            entity.Property(c => c.Total).HasColumnName("total");
            entity.Property(c => c.Trademark).HasColumnName("trademark");
        });



        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.ToTable("CartItem");
            entity.HasKey(ci => ci.Id);
            entity.Property(ci=>ci.Id).HasColumnName("id");
            entity.Property(ci => ci.ShoppingCartId).HasColumnName("shoppingcart_id");
            entity.Property(ci=>ci.ProductId).HasColumnName("product_id");
            entity.Property(ci => ci.Quantity).HasColumnName("quantity");

            entity.HasOne(ci => ci.ShoppingCart)
                    .WithMany(sc => sc.CartItems)
                    .HasForeignKey(ci => ci.ShoppingCartId);

            entity.HasOne(ci => ci.Product)
                    .WithMany()
                    .HasForeignKey(ci => ci.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");
            entity.HasKey(o => o.OrderId);
            entity.Property(o => o.OrderId).HasColumnName("order_id");
            entity.Property(o => o.UserId).HasColumnName("user_id");
            entity.Property(o => o.TotalPrice).HasColumnName("total_price");
            entity.Property(o => o.Status).HasColumnName("status");
            entity.Property(o => o.Address).HasColumnName("address");
            entity.Property(o => o.Phone).HasColumnName("phone");
            entity.Property(o => o.CreatedAt).HasColumnName("created_at");

            entity.HasOne(o => o.User)
                    .WithMany()
                    .HasForeignKey(o => o.UserId);
        });


        modelBuilder.Entity<OrderDetail>(entity => 
        {
            entity.ToTable("OrderDetail");
            entity.HasKey(od => od.Id);
            entity.Property(od=>od.Id).HasColumnName("id");
            entity.Property(od=>od.OrderId).HasColumnName("order_id");
            entity.Property(od=>od.ProductId).HasColumnName("product_id");
            entity.Property(od=>od.Quantity).HasColumnName("quantity");
            entity.Property(od=>od.UnitPrice).HasColumnName("unit_price");

            entity.HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.OrderId);

            entity.HasOne(od=>od.Product)
                    .WithMany()
                    .HasForeignKey(od => od.ProductId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Email).HasColumnName("email");
            entity.Property(u => u.Role).HasColumnName("role");
            entity.Property(u => u.Name).HasColumnName("name");
            entity.Property(u => u.Password).HasColumnName("password");
            entity.Property(u => u.Address).HasColumnName("address");
            entity.Property(u => u.Phone).HasColumnName("phone");
            //entity.Property(u => u.Create_At).HasColumnName("create_at");

        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");
            entity.HasKey(n => n.Id);

            entity.Property(n=>n.Id).HasColumnName("id");
            entity.Property(n=>n.UserId).HasColumnName("user_id");
            entity.Property(n=>n.Message).HasColumnName("message");
            entity.Property(n=>n.IsRead).HasColumnName("is_read");
            entity.Property(n=>n.CreatedAt).HasColumnName("created_at");

            entity.HasOne(n => n.User)
                    .WithMany()
                    .HasForeignKey(n => n.UserId);
        });
    }
}
