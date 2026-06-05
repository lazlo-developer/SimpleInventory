using MediatR;

namespace SimpleInventory.Application.Customers.Queries.GetCustomers;

public sealed record GetCustomersQuery : IRequest<IReadOnlyCollection<CustomerDto>>;
