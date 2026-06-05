using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleInventory.Domain.Products;

namespace SimpleInventory.Infrastructure.Persistence.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(product => product.Name)
            .HasMaxLength(50);

        builder.Property(product => product.Description)
            .HasMaxLength(50);

        builder.HasMany(product => product.OrderLines)
            .WithOne(orderLine => orderLine.Product)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
