using SimpleInventory.Domain.Enums;

namespace SimpleInventory.Application.Customers;

public sealed record CustomerDto(Guid Id, string Name, PricingRegion PricingRegion);
