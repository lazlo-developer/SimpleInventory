using Microsoft.EntityFrameworkCore;
using SimpleInventory.Domain.Customers;
using SimpleInventory.Domain.Enums;
using SimpleInventory.Domain.Products;

namespace SimpleInventory.Infrastructure.Persistence.Seeding;

public sealed class DevelopmentDataSeeder(SimpleInventoryDbContext dbContext)
{
    private static readonly Customer[] Customers =
    [
        new()
        {
            Id = Guid.Parse("17e2a2ae-77a3-4589-a9fd-505b14efa1f4"),
            Name = "Acme US",
            PricingRegion = PricingRegion.US
        },
        new()
        {
            Id = Guid.Parse("05743076-2842-43e0-a454-a8f9da32f0a2"),
            Name = "Euro Retail",
            PricingRegion = PricingRegion.Europe
        },
        new()
        {
            Id = Guid.Parse("62af9af8-f4e9-4d5e-aa61-253ca5d1b528"),
            Name = "Asia Supply",
            PricingRegion = PricingRegion.Asia
        }
    ];

    private static readonly Product[] Products =
    [
        new()
        {
            Id = Guid.Parse("b66ab0e0-17e0-4f0d-9ac0-a20cfd5678ae"),
            Name = "Keyboard",
            Description = "Mechanical keyboard",
            Price = 299.00m,
            Stock = 100
        },
        new()
        {
            Id = Guid.Parse("aa7419d0-3f8f-4dbc-bb84-9a97d02c6a62"),
            Name = "Mouse",
            Description = "Wireless mouse",
            Price = 149.00m,
            Stock = 200
        },
        new()
        {
            Id = Guid.Parse("9f6f90b1-7a6e-48f4-a9a4-2cf0f363ea51"),
            Name = "Monitor",
            Description = "27 inch monitor",
            Price = 899.00m,
            Stock = 50
        }
    ];

    public async Task SeedAsync()
    {
        await SeedCustomersAsync();
        await SeedProductsAsync();
    }

    private async Task SeedCustomersAsync()
    {
        foreach (var customer in Customers)
        {
            if (await dbContext.Customers.AnyAsync(existing => existing.Id == customer.Id))
            {
                continue;
            }

            dbContext.Customers.Add(customer);
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task SeedProductsAsync()
    {
        foreach (var product in Products)
        {
            if (await dbContext.Products.AnyAsync(existing => existing.Id == product.Id))
            {
                continue;
            }

            dbContext.Products.Add(product);
        }

        await dbContext.SaveChangesAsync();
    }
}
