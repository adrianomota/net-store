using MediatR;

namespace NetStore.Core.Messages;
public abstract class Event : Message, INotification
{  
    protected Event()
    {
        TimeStamp = DateTime.UtcNow;
    } 
    public DateTime TimeStamp { get; private set; }
}
