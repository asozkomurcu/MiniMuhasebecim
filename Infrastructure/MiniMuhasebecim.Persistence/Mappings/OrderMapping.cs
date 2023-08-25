using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Persistence.Mappings
{
    public class OrderMapping : AuditableEntityMapping<Order>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.WholesalerId)
                .IsRequired(false)
                .HasColumnName("WHOLESALER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.OrderPrice)
               .IsRequired()
               .HasColumnName("ORDER_PRICE")
               .HasColumnOrder(3);

            builder.Property(x => x.TotalOrderPrice)
                .IsRequired(false)
                .HasColumnName("TOTAL_ORDER_PRICE")
                .HasColumnOrder(4);

            builder.HasOne(x => x.Wholesaler)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.WholesalerId)
                .HasConstraintName("ORDER_WHOLESALER_WHOLESALER_ID");

            builder.ToTable("ORDERS");
        }
    }

}

