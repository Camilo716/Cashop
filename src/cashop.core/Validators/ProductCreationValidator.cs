using cashop.core.Entities;
using cashop.core.Exceptions;
using FluentValidation;

namespace cashop.core.Validators;

public class ProductCreationValidator : AbstractValidator<Product>
{
    public ProductCreationValidator()
    {
        RuleFor(product => product.Price)
            .Must(BePositiveAmount);
    }

    private bool BePositiveAmount(double price)
    {
        if(price < 0)
            throw new NegativeProductPriceException($"Price can't be negative: {price}");
        return true;
    }
}