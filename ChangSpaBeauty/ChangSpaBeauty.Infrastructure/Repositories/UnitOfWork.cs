using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Infrastructure.Persistence;
namespace ChangSpaBeauty.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IProductRepository Products { get; }
    public UnitOfWork(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        Products = productRepository;
    }
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}
