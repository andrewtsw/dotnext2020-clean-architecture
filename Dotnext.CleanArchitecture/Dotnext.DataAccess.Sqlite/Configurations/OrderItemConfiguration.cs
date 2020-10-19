using Dotnext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnext.DataAccess.Sqlite.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(orderItem => orderItem.Product)
                .WithMany(product => product.OrderItems)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
