namespace NetStore.Catalog.Domain.Validators;

using FluentValidation;

public class CategoryValidator: AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Category name can't be blank");
    }
}
