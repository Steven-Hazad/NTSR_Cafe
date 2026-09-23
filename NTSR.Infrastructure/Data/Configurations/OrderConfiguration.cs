using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTSR.Domain.Entities;

namespace NTSR.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.OrderNumber).HasMaxLength(20).IsRequired();
        builder.Property(o => o.OrderType).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");
        builder.Property(o => o.TaxAmount).HasColumnType("decimal(18,2)");
        builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(o => o.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(o => o.PaymentStatus).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(o => o.PaymentMethod).HasConversion<string>().HasMaxLength(20);
        builder.Property(o => o.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(o => o.Table)
            .WithMany(t => t.Orders)
            .HasForeignKey(o => o.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Cashier)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.CashierId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}