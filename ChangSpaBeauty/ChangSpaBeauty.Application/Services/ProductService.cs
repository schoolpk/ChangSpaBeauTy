using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Application.Interfaces;
namespace ChangSpaBeauty.Application.Services;
public class ProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Price = p.Price,
            Image = p.Image,
            CategoryName = p.Category?.Name ?? "",
            Sold = p.Sold,

        });
    }
    public async Task<IEnumerable<ProductDto>> GetPopularProductsAsync()
    {
        var products = await _unitOfWork.Products.GetPopularProductsAsync();

        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Price = p.Price,
            Sold = p.Sold,
            CategoryName = p.Category?.Name ?? "",
            Image = p.Image,

        });
    }
}
