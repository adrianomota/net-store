using FluentValidation;

namespace NetStore.Catalog.Domain.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
        .NotNull()
        .NotEmpty()
        .WithMessage("Product name can't be blank");
        
        RuleFor(product => product.Price)
        .NotNull()
        .GreaterThan(0)
        .WithMessage("Product price sbould be greater than 0");

        RuleFor(product => product.Dimensions).SetValidator(new DimensionsValidator());
    }
}
