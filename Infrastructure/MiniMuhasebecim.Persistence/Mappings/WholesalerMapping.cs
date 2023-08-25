using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Persistence.Mappings
{
    public class WholesalerMapping : BaseEntityMapping<Wholesaler>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.Property(x => x.WholesalerName)
                .IsRequired()
                .HasColumnName("WHOLESALER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2);


            builder.ToTable("WHOLESALERS");


        }
    }
}
