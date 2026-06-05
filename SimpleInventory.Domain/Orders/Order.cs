using SimpleInventory.Domain.Customers;
using SimpleInventory.Domain.Enums;

namespace SimpleInventory.Domain.Orders;

public sealed class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public DateTimeOffset CreatedAtUtc { get; set; }

    public DateTimeOffset PricedAtUtc { get; set; }

    public PricingRegion CustomerPricingRegion { get; set; }

    public decimal RegionalPriceAdjustmentRate { get; set; }

    public DiscountType AppliedDiscountType { get; set; }

    public decimal AppliedDiscountRate { get; set; }

    public decimal BaseSubtotal { get; set; }

    public decimal RegionalSubtotal { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal Total { get; set; }

    public ICollection<OrderLine> Lines { get; set; } = [];
}
