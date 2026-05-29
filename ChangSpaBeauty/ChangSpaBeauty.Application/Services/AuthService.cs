using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.VisualBasic;

namespace ChangSpaBeauty.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            return await _userRepository.EmailExistAsync(email);
        }

        public async Task<(bool Success, string Message, User?)> LoginAsync(UserLoginDTO dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null)
            {
                return (false, "Email khong ton tai", null);
            }
            bool isVaild = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isVaild)
            {
                return (false, "Mat khau khong dung", null);
            }
            return (true, "Dang nhap thanh cong", user);
        }

        public async Task<(bool Success, string Message)> RegisterAsync(UserRegisterDTO dto)
        {
            if (await _userRepository.EmailExistAsync(dto.Email))
            {
                return (false, "Email da duoc su dung");
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = hashPassword,
                Phone = dto.Phone,
                Address = dto.Address,
                Role = "Customer"
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangeAsync();

            return (true, "Dang ky thanh cong");
        }
    }
}
