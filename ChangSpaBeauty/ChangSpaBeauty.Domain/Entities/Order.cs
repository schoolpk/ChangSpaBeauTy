using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice {  get; set; }
        public string Status { get; set; } = "pending";
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User? User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
