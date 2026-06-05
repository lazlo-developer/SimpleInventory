using MediatR;

namespace SimpleInventory.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string Description, decimal Price, int Stock) : IRequest<ProductDto>;
