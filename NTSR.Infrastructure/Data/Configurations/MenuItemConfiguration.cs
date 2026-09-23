using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTSR.Domain.Entities;

namespace NTSR.Infrastructure.Data.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
        builder.HasIndex(m => m.Name).IsUnique();
        builder.Property(m => m.Category).HasMaxLength(50).IsRequired();
        builder.Property(m => m.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.ImageUrl).HasMaxLength(255);
        builder.Property(m => m.IsAvailable).HasDefaultValue(true);
    }
}