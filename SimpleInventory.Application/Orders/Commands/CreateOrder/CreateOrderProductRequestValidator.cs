using FluentValidation;

namespace SimpleInventory.Application.Orders.Commands.CreateOrder;

public sealed class CreateOrderProductRequestValidator : AbstractValidator<CreateOrderProductRequest>
{
    public CreateOrderProductRequestValidator()
    {
        RuleFor(request => request.ProductId)
            .NotEmpty();

        RuleFor(request => request.Quantity)
            .GreaterThan(0);
    }
}
