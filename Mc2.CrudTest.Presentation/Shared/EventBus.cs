using Autofac;

namespace Mc2.CrudTest.Presentation.Shared;

public class EventBus : IEventBus
{
    private readonly ILifetimeScope _lifetimeScope;

    public EventBus(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }

    public void Publish<T>(T @event) where T : DomainEvent
    {
        using var scope = _lifetimeScope.BeginLifetimeScope();
        var handler = scope.Resolve<IEventHandler<T>>();
        handler.Handle(@event);
    }
}