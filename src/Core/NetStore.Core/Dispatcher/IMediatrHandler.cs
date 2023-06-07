namespace NetStore.Core.Dispatcher;

using NetStore.Core.Messages;

public interface IMediatrHandler
{
    Task PublishEvent<T>(T currentEvent) where T : Event;
}
