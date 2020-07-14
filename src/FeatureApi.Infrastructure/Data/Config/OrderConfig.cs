using FeatureApi.Core.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeatureApi.Infrastructure.Data.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);
            builder.OwnsOne(e => e.Policy)
                .ToTable("OrderPolicy");
            builder.OwnsOne(e => e.Property)
                .ToTable("OrderProperty");
        }
    }
}
