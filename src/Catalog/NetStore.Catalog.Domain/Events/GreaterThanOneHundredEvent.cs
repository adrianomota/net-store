namespace NetStore.Catalog.Domain.Events;

using NetStore.Core.DomainObjects;

public class GreaterThanOneHundredEvent : DomainEvent
{
    public GreaterThanOneHundredEvent(Guid aggregateId) 
        : base(aggregateId)
    {
        
    }
}
