namespace Mc2.CrudTest.Presentation.Shared;

public interface IEventBus
{
    void Publish<T>(T @event) where T : IDomainEvent;

}