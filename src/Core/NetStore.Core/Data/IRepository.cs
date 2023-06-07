namespace NetStore.Core.Data;

using NetStore.Core.DomainObjects;
public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
      IUnitOfWork UnitOfWork { get; }    
}
