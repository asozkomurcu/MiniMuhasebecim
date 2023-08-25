using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Persistence.Mappings
{
    public class CustomerImageMapping : AuditableEntityMapping<CustomerImage>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<CustomerImage> builder)
        {
            builder.Property(x => x.CustomerId)
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.Path)
                .HasColumnName("PATH")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(3);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerImages)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("CUSTOMER_IMAGE_CUSTUMER_CUSTOMER_ID");

            builder.ToTable("CUSTOMER_IMAGES");
        }
    }
}
