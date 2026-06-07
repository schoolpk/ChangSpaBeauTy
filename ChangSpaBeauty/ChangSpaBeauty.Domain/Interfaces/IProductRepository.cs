using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Domain.Interfaces;
namespace ChangSpaBeauty.Application.Interfaces;
public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task<List<Category>> GetAllCategoryAsync();
    Task<IEnumerable<Product>> GetPopularProductsAsync();
    Task<IEnumerable<Product>> GetNewestProductsAsync();
    Task<IEnumerable<Product>> GetBestSellingProductsAsync();
    Task<IEnumerable<Product>> SearchAsync(string keyword);
    Task DeleteWithCartItemAsync(int productId);
}
