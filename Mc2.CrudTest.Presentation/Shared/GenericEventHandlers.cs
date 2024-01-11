using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.CrudTest.Presentation.Server.Handlers
{
    public class GenericEventHandlers<T> : IGenericEventHandlers<T> where T : IDomainEvent
    {
        private readonly IEnumerable<IEventHandler<T>> _handlers;

        public GenericEventHandlers(IEnumerable<IEventHandler<T>> handlers)
        {
            _handlers = handlers;
        }
        public  void Handle(T @event)
        {
            foreach (var handler in _handlers.ToList())  handler.Handle(@event);
        }
    }
}