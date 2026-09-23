using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTSR.Domain.Entities;

namespace NTSR.Infrastructure.Data.Configurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TableNumber).HasMaxLength(10).IsRequired();
        builder.HasIndex(t => t.TableNumber).IsUnique();
        builder.Property(t => t.Capacity).IsRequired();
        builder.Property(t => t.QRCodeToken).HasMaxLength(100);
        builder.HasIndex(t => t.QRCodeToken).IsUnique().HasFilter("[QRCodeToken] IS NOT NULL");
        builder.Property(t => t.Status).HasMaxLength(20).IsRequired();
    }
}