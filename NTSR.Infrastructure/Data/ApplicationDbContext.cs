using Microsoft.EntityFrameworkCore;
using NTSR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NTSR.Infrastructure.Data;
      //sTREAK TD I TIRED mate 
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<Table> Tables => Set<Table>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}