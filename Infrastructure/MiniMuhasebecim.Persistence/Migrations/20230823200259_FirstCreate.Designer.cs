﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniMuhasebecim.Persistence.Context;

#nullable disable

namespace MiniMuhasebecim.Persistence.Migrations
{
    [DbContext(typeof(MiniMuhasebecimContext))]
    [Migration("20230823200259_FirstCreate")]
    partial class FirstCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMER_ID")
                        .HasColumnOrder(2);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("LAST_LOGIN_DATE")
                        .HasColumnOrder(5);

                    b.Property<string>("LastUserIp")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LAST_LOGIN_IP")
                        .HasColumnOrder(6);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PASSWORD")
                        .HasColumnOrder(4);

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("ROLE_ID")
                        .HasColumnOrder(7);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("USER_NAME")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("ACCOUNTS", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CATEGORY_NAME")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(26);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CREATED_BY")
                        .HasColumnOrder(27);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(29);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(28);

                    b.HasKey("Id");

                    b.ToTable("CATEGORIES", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birtdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BIRTHDATE")
                        .HasColumnOrder(9);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(26);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CREATED_BY")
                        .HasColumnOrder(27);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("EMAIL")
                        .HasColumnOrder(7);

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("GENDER")
                        .HasColumnOrder(10);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(29);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(28);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NAME")
                        .HasColumnOrder(5);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nchar(13)")
                        .HasColumnName("PHONE")
                        .HasColumnOrder(8);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("SURNAME")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.ToTable("CUSTOMERS", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.CustomerImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(26);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CREATED_BY")
                        .HasColumnOrder(27);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMER_ID")
                        .HasColumnOrder(2);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(29);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(28);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("PATH")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CUSTOMER_IMAGES", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Debt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(26);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CREATED_BY")
                        .HasColumnOrder(27);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(29);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(28);

                    b.Property<decimal>("OrderDebt")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ORDER_DEBT")
                        .HasColumnOrder(3);

                    b.Property<decimal?>("TotalDebt")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TOTAL_DEBT")
                        .HasColumnOrder(4);

                    b.Property<int?>("WholesalerId")
                        .HasColumnType("int")
                        .HasColumnName("WHOLESALER_ID")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("WholesalerId");

                    b.ToTable("DEBTS", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CASH")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(26);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CREATED_BY")
                        .HasColumnOrder(27);

                    b.Property<decimal>("CreditCard1")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CREDIT_CARD1")
                        .HasColumnOrder(4);

                    b.Property<decimal?>("CreditCard2")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CREDIT_CARD2")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE")
                        .HasColumnOrder(2)
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(29);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(28);

                    b.Property<decimal?>("TotalIncome")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TOTAL_INCOME")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.ToTable("INCOMES", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(26);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CREATED_BY")
                        .HasColumnOrder(27);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(29);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(28);

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ORDER_PRICE")
                        .HasColumnOrder(3);

                    b.Property<decimal?>("TotalOrderPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TOTAL_ORDER_PRICE")
                        .HasColumnOrder(4);

                    b.Property<int?>("WholesalerId")
                        .HasColumnType("int")
                        .HasColumnName("WHOLESALER_ID")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("WholesalerId");

                    b.ToTable("ORDERS", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATE_DATE")
                        .HasColumnOrder(26);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CREATED_BY")
                        .HasColumnOrder(27);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MODIFIED_BY")
                        .HasColumnOrder(29);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("MODIFIED_DATE")
                        .HasColumnOrder(28);

                    b.Property<decimal>("OrderPayment")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ORDER_PAYMENT")
                        .HasColumnOrder(3);

                    b.Property<int>("PaymentType")
                        .HasColumnType("int")
                        .HasColumnName("PAYMENT_TYPE")
                        .HasColumnOrder(5);

                    b.Property<decimal?>("TotalPayment")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TOTAL_PAYMENT")
                        .HasColumnOrder(4);

                    b.Property<int?>("WholesalerId")
                        .HasColumnType("int")
                        .HasColumnName("WHOLESALER_ID")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("WholesalerId");

                    b.ToTable("PAYMENTS", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Wholesaler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("WholesalerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("WHOLESALER_NAME")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("WHOLESALERS", (string)null);
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Account", b =>
                {
                    b.HasOne("MiniMuhasebecim.Domain.Entities.Customer", "Customer")
                        .WithOne("Account")
                        .HasForeignKey("MiniMuhasebecim.Domain.Entities.Account", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.CustomerImage", b =>
                {
                    b.HasOne("MiniMuhasebecim.Domain.Entities.Customer", "Customer")
                        .WithMany("CustomerImages")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CUSTOMER_IMAGE_CUSTUMER_CUSTOMER_ID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Debt", b =>
                {
                    b.HasOne("MiniMuhasebecim.Domain.Entities.Wholesaler", "Wholesaler")
                        .WithMany("Debts")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("DEBT_WHOLESALER_WHOLESALER_ID");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Order", b =>
                {
                    b.HasOne("MiniMuhasebecim.Domain.Entities.Wholesaler", "Wholesaler")
                        .WithMany("Orders")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ORDER_WHOLESALER_WHOLESALER_ID");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Payment", b =>
                {
                    b.HasOne("MiniMuhasebecim.Domain.Entities.Wholesaler", "Wholesaler")
                        .WithMany("Payments")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PEYMENT_WHOLESALER_WHOLESALER_ID");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("CustomerImages");
                });

            modelBuilder.Entity("MiniMuhasebecim.Domain.Entities.Wholesaler", b =>
                {
                    b.Navigation("Debts");

                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
