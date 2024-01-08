namespace Mc2.CrudTest.Presentation.Shared;

public abstract class DomainEvent :IDomainEvent, IEvent
{
    public Guid EventId { get; protected set; }

    public DateTime PublishDateTime { get; protected set; }

    public Guid UserId { get; internal set; }

    public long Version { get; set; }

    protected DomainEvent()
    {
        this.EventId = Guid.NewGuid();
        this.PublishDateTime = DateTime.Now;
    }


}