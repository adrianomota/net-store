namespace NetStore.Catalog.Domain.ValueObjects;

using NetStore.Catalog.Domain.Validators;
using NetStore.Core.DomainObjects;

public class Dimensions : ValueObject
{
    public Dimensions(int height, int width, int depth)
    {
        Height = height;
        Width = width;
        Depth = depth;
    }
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int Depth { get; private set; }
    public string FormatedDescription()
        => $"LxAxP: {this.Width} x {this.Height} x {this.Depth}";
    public override string ToString() => FormatedDescription();
    public override bool IsValid()
    {
         var dimensionValidator = new DimensionsValidator();
         ValidationResult = dimensionValidator.Validate(this);
         return ValidationResult.IsValid;
    }
}
