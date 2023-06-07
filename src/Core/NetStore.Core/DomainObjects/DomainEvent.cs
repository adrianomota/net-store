namespace NetStore.Core.DomainObjects;

using NetStore.Core.Messages;

public class DomainEvent : Event
{
    public DomainEvent( Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}