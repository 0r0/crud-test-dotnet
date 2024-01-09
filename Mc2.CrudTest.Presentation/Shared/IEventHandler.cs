namespace Mc2.CrudTest.Presentation.Shared;

public interface IEventHandler<in T>
{
    void Handle(T @event);
}