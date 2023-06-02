namespace NetStore.Catalog.Domain.Validators;

using FluentValidation;
using NetStore.Catalog.Domain.ValueObjects;

public class DimensionsValidator : AbstractValidator<Dimensions>
{
      public DimensionsValidator()
    {
        RuleFor(dimension => dimension.Height)
            .GreaterThan(0)
            .WithMessage("Should be greather than 0");
        RuleFor(dimension => dimension.Width)
            .GreaterThan(0)
            .WithMessage("Should be greather than 0");
        RuleFor(dimension => dimension.Depth)
            .GreaterThan(0)
            .WithMessage("Should be greather than 0");
                
    }    
}
