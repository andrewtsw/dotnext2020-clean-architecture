using Dotnext.Entities;

namespace Dotnext.UseCases
{
    public class OrderDto
    {
        public OrderDto()
        {

        }

        public OrderDto(Order order)
        {
            Id = order.Id;
            Comment = order.Comment;
        }

        public int Id { get; set; }

        public string Comment { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }
    }
}
