using FluentValidation;

namespace SimpleInventory.Application.Orders.Queries.GetOrderById;

public sealed class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty();
    }
}
