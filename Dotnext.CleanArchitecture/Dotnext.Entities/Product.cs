using System.Collections.Generic;

namespace Dotnext.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
