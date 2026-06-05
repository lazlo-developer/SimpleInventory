namespace SimpleInventory.Application.Orders.Commands.CreateOrder;

public sealed record CreateOrderProductRequest(Guid ProductId, int Quantity);
