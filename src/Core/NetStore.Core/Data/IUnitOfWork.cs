namespace NetStore.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
