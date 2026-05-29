using ChangSpaBeauty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ChangSpaBeauty.Infrastructure.Persistence;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
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
            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CategoryId);
        });


        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.User)
            .WithOne(u => u.ShoppingCart)
            .HasForeignKey<ShoppingCart>(sc => sc.UserId);

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
    }
}
