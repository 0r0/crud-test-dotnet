using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.CrudTest.Presentation.Server.Handlers;

public class EventPublisher : IEventPublisher
{
    private readonly List<object> _publishedEvents;
    private readonly IEventAggregator _aggregator;

    public EventPublisher(IEventAggregator aggregator)
    {
        _publishedEvents = new();
        _aggregator = aggregator;
    }

    public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        if (@event is DomainEvent domainEvent)

            _publishedEvents.Add(@event);
        await _aggregator?.Publish(@event);
    }

    public List<object> GetPublishedEvents()
    {
        return _publishedEvents.ToList();
    }

    public void ClearHistory()
    {
        _publishedEvents.Clear();
    }
}