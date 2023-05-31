namespace NetStore.Catalog.Domain;

using NetStore.Catalog.Domain.Validators;
using NetStore.Core.DomainObjects;

public class Product : Entity, IAggregateRoot
{
    public Product(string name, bool active)
    {
        Name = name;
        Active = active;
    }
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public void ChangeName(string value) => Name = value;
    public void ChangeActive(bool value) => Active = value;
    public override bool IsValid()
    {
       var productValidator = new ProductValidator();
       ValidationResult = productValidator.Validate(this);
       return ValidationResult.IsValid;
    }
}
