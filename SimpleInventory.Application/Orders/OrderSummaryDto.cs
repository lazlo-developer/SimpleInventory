using SimpleInventory.Domain.Enums;

namespace SimpleInventory.Application.Orders;

public sealed record OrderSummaryDto(
    Guid Id,
    Guid CustomerId,
    DateTimeOffset CreatedAtUtc,
    PricingRegion CustomerPricingRegion,
    DiscountType AppliedDiscountType,
    decimal Total);
