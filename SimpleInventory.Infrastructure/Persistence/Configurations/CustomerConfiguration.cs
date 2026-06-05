using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleInventory.Domain.Customers;

namespace SimpleInventory.Infrastructure.Persistence.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(customer => customer.Orders)
            .WithOne(order => order.Customer)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
