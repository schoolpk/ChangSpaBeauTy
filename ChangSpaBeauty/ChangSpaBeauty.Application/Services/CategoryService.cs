using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Infrastructure.Repositories;

namespace ChangSpaBeauty.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepo;
    private readonly IProductRepository _productRepo;

    public CategoryService(ICategoryRepository categoryRepo, IProductRepository productRepo)
    {
        _categoryRepo = categoryRepo;
        _productRepo = productRepo;
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

        // ── KIỂM TRA TRADEMARK BỊ XÓA ──
        if (!string.IsNullOrWhiteSpace(category.Trademark))
        {
            // Trademark cũ của category
            var oldTrademarks = category.Trademark
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .ToList();

            // Trademark mới admin vừa nhập
            var newTrademarks = (trademark ?? "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .ToList();

            // Tìm trademark bị xóa khỏi category
            var removedTrademarks = oldTrademarks
                .Except(newTrademarks, StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (removedTrademarks.Any())
            {
                // Lấy sản phẩm thuộc category này
                var products = await _productRepo.GetAllAsync();
                var productsInCategory = products
                    .Where(p => p.CategoryId == id)
                    .ToList();

                // Kiểm tra có sản phẩm nào đang dùng trademark bị xóa không
                var affectedProducts = productsInCategory
                    .Where(p => !string.IsNullOrEmpty(p.Trademark) &&
                                removedTrademarks.Any(tm =>
                                    tm.Equals(p.Trademark.Trim(), StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                if (affectedProducts.Any())
                {
                    var affectedNames = string.Join(", ", affectedProducts.Select(p => $"\"{p.Name}\""));
                    var removedNames = string.Join(", ", removedTrademarks);
                    return (false,
                        $"Không thể xóa thương hiệu [{removedNames}] vì còn {affectedProducts.Count} sản phẩm đang dùng: {affectedNames}. " +
                        $"Vui lòng cập nhật thương hiệu của các sản phẩm đó trước.");
                }
            }
        }

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