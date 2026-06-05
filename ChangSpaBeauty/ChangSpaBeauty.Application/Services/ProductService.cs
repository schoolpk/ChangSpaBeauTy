using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChangSpaBeauty.Application.Services;

public class ProductService
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly AppDbContext _context;   // ← thêm để xử lý FK

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
            Description = productDto.Description
        };
        await _unitOfWork.Products.AddAsync(product);
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
            Description = p.Description
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

    public async Task UpdateProductAsync(ProductDto productDto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(productDto.ProductId);
        if (product == null) return;

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.CategoryId = productDto.CategoryId;
        product.Stock = productDto.Stock;
        product.Description = productDto.Description;
        if (productDto.Image != null)
            product.Image = productDto.Image;

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {


        //await _context.Set<CartItem>()
        //              .Where(ci => ci.ProductId == id)
        //              .ExecuteDeleteAsync();
        await _unitOfWork.Products.DeleteWithCartItemAsync(id);
    }
}