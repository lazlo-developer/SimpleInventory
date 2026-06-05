using SimpleInventory.Domain.Orders;

namespace SimpleInventory.Domain.Products;

public sealed class Product
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public ICollection<OrderLine> OrderLines { get; set; } = [];
}
