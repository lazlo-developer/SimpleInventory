using FluentValidation;

namespace SimpleInventory.Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(command => command.Price)
            .GreaterThan(0m);

        RuleFor(command => command.Stock)
            .GreaterThanOrEqualTo(0);
    }
}
