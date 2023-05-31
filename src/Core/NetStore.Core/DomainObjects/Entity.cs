namespace NetStore.Core.DomainObjects;

using FluentValidation.Results;

public abstract class Entity
{
    protected Entity()
    {
       Id = System.Guid.NewGuid();
       CreatedAt = DateTime.UtcNow;
    }
   public Guid Id { get; private set; }
   public DateTime CreatedAt { get; private set; }
   public DateTime UpdatedAt { get; set; }
   public ValidationResult? ValidationResult { get; set; }

   public override bool Equals(object? obj)
   {
      var compjareTo = obj as Entity;
      if(ReferenceEquals(this, compjareTo)) return true;
      if(ReferenceEquals(null, compjareTo)) return false;
      return Id.Equals(compjareTo.Id);
   }
   public static bool operator == (Entity a, Entity b)
   {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
         return true;
      if(ReferenceEquals(a, null) && ReferenceEquals(b, null))
         return false;
      return object.Equals(a, b);
   }
    public static bool operator != (Entity a, Entity b) 
        => !(a == b);
    public override int GetHashCode() 
        => (GetType().GetHashCode() * 907) + Id.GetHashCode();
    public override string ToString()
        => $"{GetType().Name} [Id={Id}]";
    public virtual bool IsValid() => throw new NotImplementedException();
    public void Validate() => IsValid();
}
