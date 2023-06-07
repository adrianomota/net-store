namespace NetStore.Catalog.Domain.Services;

using NetStore.Catalog.Domain.Contracts;
using NetStore.Catalog.Domain.Events;
using NetStore.Core.Dispatcher;
using NetStore.Core.DomainObjects;

public class PriceService : IPriceService
{   
    private const decimal DiscountOfTenPercent = 10m;
    private readonly IMediatrHandler _bus;
    private readonly IProductRepository _repo;

    public PriceService(IProductRepository repo, IMediatrHandler bus)
    {
        _repo = repo;
        _bus = bus;
    }

    public async Task<decimal> ProductWithPriceGreaterThanOneUndredApplyDiscount(Guid productId)
    {
        var productExists = await _repo.GetById(productId);
        if(productExists == null) throw new DomainException("Product doesn't exists");
        if(productExists.Price > 100)
        {
            await _bus.PublishEvent(new GreaterThanOneHundredEvent(productExists.Id));
            return productExists.Price - ((DiscountOfTenPercent / 100) * productExists.Price);
        }
        return 0m;
    }
    public void Dispose() => _repo.Dispose();
}