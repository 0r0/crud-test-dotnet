namespace Mc2.CrudTest.Presentation.Shared;

public interface IEventAggregator
{
    void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

    Task Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent;
}