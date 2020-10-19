namespace Dotnext.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }

        public decimal CalculatePrice()
        {
            return UnitPrice * Quantity;
        }
    }
}
