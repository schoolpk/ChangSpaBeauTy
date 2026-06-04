using ChangSpaBeauty.Domain.Entities;
using ChangSpaBeauty.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> NameExistsAsync(string name, int? excludeId = null);
        Task SaveChangeAsync();
    }
}
