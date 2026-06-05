using SimpleInventory.Domain.Products;

namespace SimpleInventory.Domain.Orders;

public sealed class OrderLine
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Order? Order { get; set; }

    public Guid ProductId { get; set; }

    public Product? Product { get; set; }

    public required string ProductName { get; set; }

    public int Quantity { get; set; }

    public int DiscountedQuantity { get; set; }

    public decimal BaseUnitPrice { get; set; }

    public decimal RegionalUnitPrice { get; set; }

    public decimal AppliedDiscountRate { get; set; }

    public decimal LineSubtotal { get; set; }

    public decimal LineDiscountAmount { get; set; }

    public decimal LineTotal { get; set; }
}
