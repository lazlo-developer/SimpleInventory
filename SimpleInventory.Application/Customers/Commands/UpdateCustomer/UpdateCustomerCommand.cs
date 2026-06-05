using MediatR;
using SimpleInventory.Domain.Enums;

namespace SimpleInventory.Application.Customers.Commands.UpdateCustomer;

public sealed record UpdateCustomerCommand(Guid Id, string Name, PricingRegion PricingRegion) : IRequest<CustomerDto>;
