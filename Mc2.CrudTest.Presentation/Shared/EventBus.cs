// using Autofac;
// using Mc2.CrudTest.Presentation.Shared;
//
// namespace Mc2.CrudTest.Presentation.Server.Handlers;
//
// public class EventBus : IEventBus
// {
//     private readonly ILifetimeScope _lifetimeScope;
//
//     public EventBus(ILifetimeScope lifetimeScope)
//     {
//         _lifetimeScope = lifetimeScope;
//     }
//
//     public void Publish<T>(T @event) where T : IDomainEvent
//     {
//         using var scope = _lifetimeScope.BeginLifetimeScope();
//         var handlers = (IEventHandler<T>) scope.Resolve(typeof(IEventHandler<T>));
//         var handlerContainer = new List<IEventHandler<T>>() {handlers};
//         foreach (var handler in handlerContainer)
//         {
//             handler.Handle(@event);
//         }
//     }
// }


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
        //
        // public async Task<bool> Dispatch<T>(T @event) where T : IDomainEvent
        // {
        //     // _logger.LogInformation($"handling event: {@event.GetType().FullName}");
        //     // await using var scope = _scope.BeginLifetimeScope();
        //     // var handler = (IGenericEventHandlers<T>)scope.Resolve(typeof(IGenericEventHandlers<>)
        //     //     .MakeGenericType(@event.GetType()));
        //     // return await handler.Handle(@event).ConfigureAwait(false);
        // }

        public void Publish<T>(T @event) where T : IDomainEvent
        {
            // _logger.LogInformation($"handling event: {@event.GetType().FullName}");
            using var scope = _scope.BeginLifetimeScope();
            var handler =
                (IGenericEventHandlers<T>) scope.Resolve(
                    typeof(IGenericEventHandlers<>).MakeGenericType(@event.GetType()));

            handler.Handle(@event);
        }
    }
}