namespace NetStore.Catalog.Domain.Events;

using MediatR;
using NetStore.Catalog.Domain.Contracts;

public class ProductEventHandler : INotificationHandler<GreaterThanOneHundredEvent>
{
    private readonly IProductRepository _repo;

    public ProductEventHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(GreaterThanOneHundredEvent message, CancellationToken cancellationToken)
    {
        var productExists = await _repo.GetById(message.AggregateId);

        // Send some email to customer informing about the discount earned
        
    }
}
