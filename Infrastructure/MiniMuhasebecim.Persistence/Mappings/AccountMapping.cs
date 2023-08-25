﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Persistence.Mappings
{
    public class AccountMapping : BaseEntityMapping<Account>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.CustomerId)
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(10)")
                .HasColumnName("USER_NAME")
                .HasColumnOrder(3);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasColumnName("PASSWORD")
                .HasColumnOrder(4);

            builder.Property(x => x.LastLoginDate)
                .HasColumnName("LAST_LOGIN_DATE")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder.Property(x => x.LastUserIp)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("LAST_LOGIN_IP")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder.Property(x => x.Role)
                .HasColumnName("ROLE_ID")
                .HasColumnOrder(7);

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Account)
                .HasForeignKey<Account>(x => x.CustomerId);

            builder.ToTable("ACCOUNTS");
        }
    }
}
