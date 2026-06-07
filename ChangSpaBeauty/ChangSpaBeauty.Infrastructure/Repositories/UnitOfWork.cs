using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Infrastructure.Persistence;

namespace ChangSpaBeauty.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IProductRepository Products { get; }

    public ICategoryRepository Categories { get;}

    public UnitOfWork(AppDbContext context, IProductRepository productRepository, ICategoryRepository categories)
    {
        _context = context;
        Products = productRepository;
        Categories = categories;

    }
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}
