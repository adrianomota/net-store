namespace NetStore.Catalog.Domain.Contracts;

public interface IPriceService : IDisposable
{
    Task<decimal> ProductWithPriceGreaterThanOneUndredApplyDiscount(Guid productId);
}
