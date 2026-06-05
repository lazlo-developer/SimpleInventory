using FluentValidation;

namespace SimpleInventory.Application.Orders.Commands.CreateOrder;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(command => command.CustomerId)
            .NotEmpty();

        RuleFor(command => command.Products)
            .NotEmpty();

        RuleForEach(command => command.Products)
            .SetValidator(new CreateOrderProductRequestValidator());
    }
}
