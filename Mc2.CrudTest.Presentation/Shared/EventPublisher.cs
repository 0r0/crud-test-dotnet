namespace Mc2.CrudTest.Presentation.Shared;

public class EventPublisher :IEventPublisher
{
    public Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        throw new NotImplementedException();
    }

    public List<object> GetPublishedEvents()
    {
        throw new NotImplementedException();
    }

    public void ClearHistory()
    {
        throw new NotImplementedException();
    }
}