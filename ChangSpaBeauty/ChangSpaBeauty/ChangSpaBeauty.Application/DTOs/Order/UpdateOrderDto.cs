using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Application.DTOs.Order
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<UpdateOrderItemDto> Items { get; set; } = new();
    }
    public class UpdateOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
