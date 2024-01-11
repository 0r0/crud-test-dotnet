// using Autofac;
//
// namespace Mc2.CrudTest.Presentation.Shared;
//
// public class AriusEventBus : IEventBus
// {
//     private readonly ILifetimeScope _scope;
//
//
//     public AriusEventBus(ILifetimeScope scope)
//     {
//         _scope = scope;
//     }
//
//
//     public void Publish<T>(T @event) where T : DomainEvent
//     {
//         using var scope = _scope.BeginLifetimeScope();
//         var handler = (IEventHandler<T>) scope.Resolve(typeof(IEventHandler<>)
//             .MakeGenericType(@event.GetType()));
//         handler.Handle(@event);
//     }
// }