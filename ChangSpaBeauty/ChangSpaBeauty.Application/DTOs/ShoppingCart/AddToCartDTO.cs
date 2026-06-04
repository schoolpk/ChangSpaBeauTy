using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.DTOs.ShoppingCart
{
    public class AddToCartDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
