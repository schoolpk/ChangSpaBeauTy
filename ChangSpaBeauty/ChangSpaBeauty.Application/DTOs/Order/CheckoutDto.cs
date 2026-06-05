using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.DTOs.Order
{
    public class CheckoutDto
    {
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Phone { get; set; } = string.Empty;
    }
}
