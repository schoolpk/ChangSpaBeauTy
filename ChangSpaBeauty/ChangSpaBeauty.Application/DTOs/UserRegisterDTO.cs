using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.DTOs
{
    public class UserRegisterDTO
    {
        //nhập tên
        [Required(ErrorMessage = "Vui long nhap ho ten")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        //nhập email
        [Required(ErrorMessage = "Vui long nhap email")]
        [EmailAddress(ErrorMessage = "Email khong hop le")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Vui long nhap mat khau")]
        [MinLength(6, ErrorMessage = "Toi thieu 6 ky tu tro len")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty.ToString();

        [Required(ErrorMessage = "Vui long xac nhan mat khau")]
        [Compare("Password", ErrorMessage = "Mat khau khong khop")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui long nhap so dien thoai")]
        public string Phone {  get; set; }
        public string Address { get; set; }

    }
}
