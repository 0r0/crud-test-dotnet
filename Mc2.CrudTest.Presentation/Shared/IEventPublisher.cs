namespace Mc2.CrudTest.Presentation.Shared;

public interface IEventPublisher
{
    Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    List<object> GetPublishedEvents();
    void ClearHistory();
}