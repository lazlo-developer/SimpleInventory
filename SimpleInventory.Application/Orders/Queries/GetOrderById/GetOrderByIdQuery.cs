using MediatR;

namespace SimpleInventory.Application.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(Guid Id) : IRequest<OrderDetailDto>;
