using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Username can not empty")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password can not empty")]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }

    }
}
