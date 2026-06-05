using SimpleInventory.Domain.Enums;
using SimpleInventory.Domain.Orders;

namespace SimpleInventory.Domain.Customers;

public sealed class Customer
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public PricingRegion PricingRegion { get; set; }

    public ICollection<Order> Orders { get; set; } = [];
}
