using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Infrastructure.Repositories;

namespace ChangSpaBeauty.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepo;

    public CategoryService(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public Task<IEnumerable<Category>> GetAllAsync() =>
        _categoryRepo.GetAllAsync();

    public Task<Category?> GetByIdAsync(int id) =>
        _categoryRepo.GetByIdAsync(id);

    public async Task<(bool Success, string Message)> CreateAsync(string name, string tradeMark)
    {
        if (await _categoryRepo.NameExistsAsync(name))
            return (false, $"Danh mục \"{name}\" đã tồn tại.");

        var category = new Category
        {
            Name = name.Trim(),
            Trademark = tradeMark.Trim()
        };
        await _categoryRepo.AddAsync(category);
        await _categoryRepo.SaveChangeAsync();
        return (true, "Thêm danh mục thành công.");
    }

    public async Task<(bool Success, string Message)> UpdateAsync(int id, string name, string trademark)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null)
            return (false, "Không tìm thấy danh mục.");

        if (await _categoryRepo.NameExistsAsync(name, excludeId: id))
            return (false, $"Tên \"{name}\" đã được dùng bởi danh mục khác.");

        category.Name = name.Trim();
        category.Trademark = trademark?.Trim() ?? "";
        _categoryRepo.UpdateAsync(category);
        await _categoryRepo.SaveChangeAsync();
        return (true, "Cập nhật danh mục thành công.");
    }

    public async Task<(bool Success, string Message)> DeleteAsync(int id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null)
            return (false, "Không tìm thấy danh mục.");

        if (category.Products != null && category.Products.Any())
            return (false, $"Không thể xóa: danh mục đang có {category.Products.Count()} sản phẩm.");

        _categoryRepo.DeleteAsync(category);
        await _categoryRepo.SaveChangeAsync();
        return (true, "Đã xóa danh mục thành công.");
    }
}