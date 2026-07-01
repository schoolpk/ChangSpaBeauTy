using ChangSpaBeauty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.Interfaces
{
    public interface IUserRepository
    {
        
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetAdminAsync();
        Task AddAsync(User user);
        Task DeteleAsync(int userId);
        Task SaveChangeAsync();
        Task<bool> EmailExistAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();

    }
}
