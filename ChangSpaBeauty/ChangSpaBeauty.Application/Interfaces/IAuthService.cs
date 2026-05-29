using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, string Message, User?)> LoginAsync(UserLoginDTO dto);
        Task<(bool Success, string Message)> RegisterAsync(UserRegisterDTO dto);
        Task<bool> EmailExistAsync(string email);
    }
}
