using System.Collections.Generic;

namespace Dotnext.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
