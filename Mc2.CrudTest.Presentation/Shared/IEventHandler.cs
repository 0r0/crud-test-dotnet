

namespace Mc2.CrudTest.Presentation.Server.Handlers;

public interface IEventHandler<in T>
{
    void Handle(T @event);
}

