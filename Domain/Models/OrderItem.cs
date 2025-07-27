using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int ProductId { get; set; }//fk
        public Product Product { get; set; } = null!;
        public int OrderId { get; set; } //fk
        public Order Order { get; set; } = null!;
    }
}
