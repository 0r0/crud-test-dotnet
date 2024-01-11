using Mc2.CrudTest.Presentation.Server.Handlers;

namespace Mc2.CrudTest.Presentation.Shared
{
    public class EventBus : IEventBus
    {
        private readonly IServiceRegistryLifetimeScope _scope;


        public EventBus(IServiceRegistryLifetimeScope scope)
        {
            _scope = scope;
        }


        public void Publish<T>(T @event) where T : IDomainEvent
        {
            using var scope = _scope.BeginLifetimeScope();
            var handler =
                (IGenericEventHandlers<T>) scope.Resolve(
                    typeof(IGenericEventHandlers<>).MakeGenericType(@event.GetType()));

            handler.Handle(@event);
        }
    }
}