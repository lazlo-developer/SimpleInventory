using Microsoft.EntityFrameworkCore;
using SimpleInventory.Domain.Customers;
using SimpleInventory.Domain.Orders;
using SimpleInventory.Domain.Products;

namespace SimpleInventory.Infrastructure.Persistence;

public sealed class SimpleInventoryDbContext(DbContextOptions<SimpleInventoryDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderLine> OrderLines => Set<OrderLine>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimpleInventoryDbContext).Assembly);
    }
}
