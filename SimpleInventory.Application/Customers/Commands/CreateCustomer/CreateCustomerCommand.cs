using MediatR;
using SimpleInventory.Domain.Enums;

namespace SimpleInventory.Application.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand(string Name, PricingRegion PricingRegion) : IRequest<CustomerDto>;
