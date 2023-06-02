namespace NetStore.Core.DomainObjects;

using FluentValidation.Results;

public class ValueObject
{
    public ValidationResult? ValidationResult { get; set; }
    public virtual bool IsValid()
        => throw new NotImplementedException();
    public void Validate() => IsValid();
}
