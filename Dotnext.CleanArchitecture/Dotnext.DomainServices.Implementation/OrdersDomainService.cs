using Dotnext.DomainServices.Interfaces;
using Dotnext.Entities;
using System.Linq;

namespace Dotnext.DomainServices.Implementation
{
    public class OrdersDomainService : IOrdersDomainService
    {
        public decimal CalculateDiscount(Order order)
        {
            // TODO
            return 0;
        }

        public decimal CalculateSubTotal(Order order)
        {
            return order.OrderItems.Sum(x => x.Quantity * x.UnitPrice);
        }

        public decimal CalculateTax(Order order)
        {
            // TODO
            return 0;
        }

        public decimal CalculateTotalPrice(Order order)
        { 
            var subTotal = CalculateSubTotal(order);
            var discount = CalculateDiscount(order);
            var tax = CalculateTax(order);
            return subTotal - discount + tax;
        }
    }
}
