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
            ExternalId = order.ExternalId;

            //SubTotal = order.CalculateSubTotal();
            //Tax = order.CalculateTax();
            //Discount = order.CalculateDiscount();
            //Total = order.CalculateTotal(SubTotal, Discount, Tax);
        }

        public int Id { get; set; }

        public string Comment { get; set; }

        public string ExternalId { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }
    }
}
