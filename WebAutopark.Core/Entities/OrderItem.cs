using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.Core.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; }
        public int OrderId { get; }
        public int ComponentId { get; }
        public int Quantity { get; }
    }
}