using SimpleInventory.Domain.Errors;

namespace SimpleInventory.Domain.Exceptions;

public sealed class InsufficientStockException(Guid productId, int requestedQuantity, int availableQuantity)
    : BusinessRuleViolationException(
        DomainErrorCodes.InsufficientStock,
        $"Insufficient stock for product '{productId}'. Requested {requestedQuantity}, available {availableQuantity}.")
{
    public Guid ProductId { get; } = productId;

    public int RequestedQuantity { get; } = requestedQuantity;

    public int AvailableQuantity { get; } = availableQuantity;
}
