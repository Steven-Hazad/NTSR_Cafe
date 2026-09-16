using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NTSR.Domain.Entities;

namespace NTSR.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Order> Orders { get; }
    IRepository<OrderItem> OrderItems { get; }
    IRepository<MenuItem> MenuItems { get; }
    IRepository<Table> Tables { get; }
    IRepository<ApplicationUser> Users { get; }

    Task<int> SaveChangesAsync();
}