using MediatR;

namespace SimpleInventory.Application.Orders.Queries.GetOrders;

public sealed record GetOrdersQuery : IRequest<IReadOnlyCollection<OrderSummaryDto>>;
