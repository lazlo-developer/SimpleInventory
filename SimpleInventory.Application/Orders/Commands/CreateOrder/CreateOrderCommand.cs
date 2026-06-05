using MediatR;

namespace SimpleInventory.Application.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(Guid CustomerId, IReadOnlyCollection<CreateOrderProductRequest> Products) : IRequest<OrderDetailDto>;
