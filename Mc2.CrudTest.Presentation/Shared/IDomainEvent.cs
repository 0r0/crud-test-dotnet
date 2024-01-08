namespace Mc2.CrudTest.Presentation.Shared;

public interface IDomainEvent
{
    Guid EventId { get; }

    DateTime PublishDateTime { get; }

    Guid UserId { get; }
}