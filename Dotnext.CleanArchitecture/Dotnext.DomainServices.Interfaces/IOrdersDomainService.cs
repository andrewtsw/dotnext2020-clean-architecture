using Dotnext.Entities;
using System;

namespace Dotnext.DomainServices.Interfaces
{
    public interface IOrdersDomainService
    {
        decimal CalculateSubTotal(Order order);

        decimal CalculateTotalPrice(Order order);

        decimal CalculateDiscount(Order order);

        decimal CalculateTax(Order order);
    }
}
