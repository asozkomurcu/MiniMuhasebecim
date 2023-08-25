using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Persistence.Mappings
{
    public class IncomeMapping : AuditableEntityMapping<Income>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Income> builder)
        {
            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("DATE")
                .HasDefaultValueSql("getdate()")
                .HasColumnOrder(2);

            builder.Property(x => x.Cash)
                .IsRequired()
                .HasColumnName("CASH")
                .HasColumnOrder(3);

            builder.Property(x => x.CreditCard1)
                .IsRequired()
                .HasColumnName("CREDIT_CARD1")
                .HasColumnOrder(4);

            builder.Property(x => x.CreditCard2)
                .IsRequired(false)
                .HasColumnName("CREDIT_CARD2")
                .HasColumnOrder(5);

            builder.Property(x => x.TotalIncome)
                .IsRequired(false)
                .HasColumnName("TOTAL_INCOME")
                .HasColumnOrder(6);

            builder.ToTable("INCOMES");

        }
    }
}
