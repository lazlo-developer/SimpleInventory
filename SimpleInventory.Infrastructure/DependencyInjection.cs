using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInventory.Infrastructure.Persistence;
using SimpleInventory.Infrastructure.Persistence.Seeding;

namespace SimpleInventory.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        services.AddDbContext<SimpleInventoryDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<DevelopmentDataSeeder>();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this IServiceProvider services, bool isDevelopment)
    {
        await using var scope = services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SimpleInventoryDbContext>();

        await dbContext.Database.EnsureCreatedAsync();

        if (!isDevelopment)
        {
            return;
        }

        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var enableSeedData = bool.TryParse(configuration["Features:EnableDevelopmentSeedData"], out var value) && value;

        if (!enableSeedData)
        {
            return;
        }

        var seeder = scope.ServiceProvider.GetRequiredService<DevelopmentDataSeeder>();
        await seeder.SeedAsync();
    }
}
