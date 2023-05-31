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
    }
}
