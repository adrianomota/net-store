namespace NetStore.Catalog.Domain;

using NetStore.Catalog.Domain.Validators;
using NetStore.Core.DomainObjects;

public class Category : Entity
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }
    public void ChangeName(string value) => Name = value;

    public override bool IsValid()
    {
       var productValidator = new CategoryValidator();
       ValidationResult = productValidator.Validate(this);
       return ValidationResult.IsValid;
    }
}
