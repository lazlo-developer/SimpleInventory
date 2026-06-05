using MediatR;

namespace SimpleInventory.Application.Products.Queries.GetProducts;

public sealed record GetProductsQuery : IRequest<IReadOnlyCollection<ProductDto>>;
