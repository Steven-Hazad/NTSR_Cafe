using NTSR.Domain.Entities;
using NTSR.Domain.Interfaces;
using NTSR.Infrastructure.Data;

namespace NTSR.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private IRepository<Order>? _orders;
    private IRepository<OrderItem>? _orderItems;
    private IRepository<MenuItem>? _menuItems;
    private IRepository<Table>? _tables;
    private IRepository<ApplicationUser>? _users;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);
    public IRepository<OrderItem> OrderItems => _orderItems ??= new Repository<OrderItem>(_context);
    public IRepository<MenuItem> MenuItems => _menuItems ??= new Repository<MenuItem>(_context);
    public IRepository<Table> Tables => _tables ??= new Repository<Table>(_context);
    public IRepository<ApplicationUser> Users => _users ??= new Repository<ApplicationUser>(_context);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}