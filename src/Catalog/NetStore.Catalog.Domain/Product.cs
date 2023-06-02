namespace NetStore.Catalog.Domain;

using NetStore.Catalog.Domain.Validators;
using NetStore.Catalog.Domain.ValueObjects;
using NetStore.Core.DomainObjects;

public class Product : Entity, IAggregateRoot
{
    public Product(string name, bool active, decimal price, Dimensions dimensions)
    {
        Name = name;
        Active = active;
        Price = price;
        Dimensions = dimensions;
    }
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public int QuantityInStock { get; private set; }
    public decimal Price { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public void ChangeName(string value) => Name = value;
    public void ChangeActive(bool value) => Active = value;
    public void ChangePrice(decimal value) => Price = value; 
    public void ChangeDimensions(Dimensions value) => Dimensions = value; 
    public override bool IsValid()
    {
       var productValidator = new ProductValidator();
       ValidationResult = productValidator.Validate(this);
       return ValidationResult.IsValid;
    }
}
