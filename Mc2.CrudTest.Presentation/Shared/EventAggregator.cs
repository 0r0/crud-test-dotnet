using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.CrudTest.Presentation.Server.Handlers;

public class EventAggregator : IEventAggregator
{
    private readonly List<object> _subscriberList = new();

    public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
    {
        _subscriberList.Add(eventHandler);
    }

    public async Task Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
    {
        var list = _subscriberList.OfType<IEventHandler<TEvent>>().ToList();
        foreach (IEventHandler<TEvent> eventHandler in list) eventHandler.Handle(eventToPublish);
    }
}