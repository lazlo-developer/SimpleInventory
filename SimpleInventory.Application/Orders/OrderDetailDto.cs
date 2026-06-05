using SimpleInventory.Domain.Enums;

namespace SimpleInventory.Application.Orders;

public sealed record OrderDetailDto(
    Guid Id,
    Guid CustomerId,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset PricedAtUtc,
    PricingRegion CustomerPricingRegion,
    decimal RegionalPriceAdjustmentRate,
    DiscountType AppliedDiscountType,
    decimal AppliedDiscountRate,
    decimal BaseSubtotal,
    decimal RegionalSubtotal,
    decimal DiscountAmount,
    decimal Total,
    IReadOnlyCollection<OrderLineDto> Lines);
