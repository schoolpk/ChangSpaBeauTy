using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChangSpaBeauty.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
       return await _context.Products.Include(p => p.Category).ToListAsync();
    }
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }
    public void UpdateAsync(Product product)
    {
        _context.Products.Update(product);
    }
    public void DeleteAsync(Product product)
    { 
        _context.Products.Remove(product);
    }
    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId) 
    { 
        return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync(); 
    }
    public async Task<IEnumerable<Product>> GetPopularProductsAsync()
    {
        return await _context.Products.OrderByDescending(p => p.Sold).Take(10).ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetNewestProductsAsync()
    {
       return await _context.Products.OrderByDescending(p => p.ProductId).Take(10).ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetBestSellingProductsAsync()
    {
       return await _context.Products.OrderByDescending(p => p.Sold).ToListAsync();
    }
    public async Task<IEnumerable<Product>> SearchAsync(string keyword)
    {
       return await _context.Products.Where(p => p.Name.Contains(keyword)).ToListAsync();
    }

    public async Task DeleteWithCartItemAsync(int productId)
    {
        var orderDetails = await _context.Set<OrderDetail>()
                                .Where(od => od.ProductId == productId)
                                .ToListAsync();
        if (orderDetails.Any())
        {
            _context.Set<OrderDetail>().RemoveRange(orderDetails);
        }

        
        var cartItems = await _context.Set<CartItem>()
                                    .Where(ci => ci.ProductId == productId)
                                    .ToListAsync();
        if (cartItems.Any())
        {
            _context.Set<CartItem>().RemoveRange(cartItems);
        }
        
        var product = await _context.Set<Product>()
                                    .FindAsync(productId);
        if (product != null)
        {
            _context.Set<Product>().Remove(product);
        }
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllCategoryAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}
