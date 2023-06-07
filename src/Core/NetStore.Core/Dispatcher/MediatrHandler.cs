namespace NetStore.Core.Dispatcher;

using MediatR;
using NetStore.Core.Messages;

public class MediatrHandler : IMediatrHandler
{
    private readonly IMediator _mediator;

    public MediatrHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task PublishEvent<T>(T currentEvent) where T : Event
    {
        await _mediator.Publish(currentEvent);
    }
}
