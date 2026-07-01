using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChangSpaBeauty.Application.Services;

public class ProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> AddProductAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Image = productDto.Image,
            Sold = productDto.Sold,
            CategoryId = productDto.CategoryId,
            Stock = productDto.Stock,
            Description = productDto.Description,
            Trademark = productDto.Trademark,
        };
        await _unitOfWork.Products.AddAsync(product);

        var category = await _unitOfWork.Categories.GetByIdAsync(productDto.CategoryId);
        if(category!= null)
        {
            category.Total += 1;
        }
        await SyncTrademarkToCategoryAsync(productDto.CategoryId, productDto.Trademark);

        await _unitOfWork.SaveChangesAsync();
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Price = p.Price,
            Image = p.Image,
            CategoryId = p.CategoryId,
            CategoryName = p.Category?.Name ?? "",
            Sold = p.Sold,
            Stock = p.Stock,
            Description = p.Description,
            Trademark = p.Trademark,
        });
    }
    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _unitOfWork.Products.GetByIdAsync(productId);
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
            Image = p.Image
        });
    }

    public async Task UpdateProductStockAsync(Product product)
    {
        _unitOfWork.Products.UpdateAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }
  

    public async Task UpdateProductAsync(ProductDto productDto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(productDto.ProductId);
        if (product == null) return;

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.CategoryId = productDto.CategoryId;
        product.Stock = productDto.Stock;
        product.Description = productDto.Description;
        product.Trademark = productDto.Trademark;
        if (productDto.Image != null)
            product.Image = productDto.Image;

        await SyncTrademarkToCategoryAsync(productDto.CategoryId, productDto.Trademark);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product != null)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(product.CategoryId);
            if (category != null && category.Total > 0)
            {
                category.Total -= 1;
            }
            await _unitOfWork.SaveChangesAsync();
        }
        await _unitOfWork.Products.DeleteWithCartItemAsync(id);
    }

    private async Task SyncTrademarkToCategoryAsync(int categoryId, string? trademark)
    {
        if (string.IsNullOrWhiteSpace(trademark)) return;

        var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
        if (category == null) return;

        // Split trademark hiện tại của category thành list
        var existing = (category.Trademark ?? "")
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(t => t.Trim())
            .ToList();

        // Nếu chưa có trademark này → thêm vào
        if (!existing.Contains(trademark.Trim(), StringComparer.OrdinalIgnoreCase))
        {
            existing.Add(trademark.Trim());
            category.Trademark = string.Join(", ", existing);
            _unitOfWork.Categories.UpdateAsync(category);
        }
    }
}

