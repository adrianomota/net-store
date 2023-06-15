namespace NetStore.Catalog.Domain;

using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Results;
using NetStore.Catalog.Domain.Validators;
using NetStore.Catalog.Domain.ValueObjects;
using NetStore.Core.DomainObjects;

public class Product : Entity, IAggregateRoot
{
    //EF
    protected Product() {}
    public Product(string name, bool active, decimal price, Dimensions dimensions, Guid categoryId)
    {
        Name = name;
        Active = active;
        Price = price;
        Dimensions = dimensions;
        CategoryId = categoryId;
    }
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public decimal Price { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    
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
