using ChangSpaBeauty.Infrastructure.Repositories;

namespace ChangSpaBeauty.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    ICategoryRepository Categories { get; }
    Task<int> SaveChangesAsync();
}
