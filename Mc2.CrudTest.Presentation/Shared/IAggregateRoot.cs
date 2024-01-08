namespace Mc2.CrudTest.Presentation.Shared;

public interface IAggregateRoot
{
    void Apply(DomainEvent @event);
}