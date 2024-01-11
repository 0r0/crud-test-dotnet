using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.CrudTest.Presentation.Server.Handlers;

public interface IGenericEventHandlers<in T> where T : IDomainEvent
{
    void Handle(T @event);
}