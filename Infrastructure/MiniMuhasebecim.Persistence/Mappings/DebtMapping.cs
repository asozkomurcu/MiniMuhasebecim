using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Persistence.Mappings
{
    public class DebtMapping : AuditableEntityMapping<Debt>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Debt> builder)
        {
            builder.Property(x => x.WholesalerId)
                .IsRequired(false)
                .HasColumnName("WHOLESALER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.OrderDebt)
                .IsRequired()
                .HasColumnName("ORDER_DEBT")
                .HasColumnOrder(3);

            builder.Property(x => x.TotalDebt)
                .IsRequired(false)
                .HasColumnName("TOTAL_DEBT")
                .HasColumnOrder(4);

            builder.HasOne(x => x.Wholesaler)
                .WithMany(x => x.Debts)
                .HasForeignKey(x => x.WholesalerId)
                .HasConstraintName("DEBT_WHOLESALER_WHOLESALER_ID");

            builder.ToTable("DEBTS");
        }
    }
}

