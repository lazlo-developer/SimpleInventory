namespace SimpleInventory.Application.Orders;

public sealed record OrderLineDto(
    Guid ProductId,
    string ProductName,
    int Quantity,
    int DiscountedQuantity,
    decimal BaseUnitPrice,
    decimal RegionalUnitPrice,
    decimal AppliedDiscountRate,
    decimal LineSubtotal,
    decimal LineDiscountAmount,
    decimal LineTotal);
