namespace Mc2.CrudTest.Presentation.Shared;



public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    private readonly List<DomainEvent> _uncommittedEvent;
    private IEventPublisher _publisher;

    public long Version { get; private set; }

    protected AggregateRoot()
    {
        _uncommittedEvent = new List<DomainEvent>();
    }

    public void SetPublisher(IEventPublisher publisher)
    {
        _publisher = publisher;
    }
    public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvent.AsReadOnly();


    public void AddEvent(DomainEvent @event)

    {
        if (@event is null) throw new ArgumentNullException($"domain event can  not be null=>{nameof(@event)}");
        _publisher.Publish(@event);
        _uncommittedEvent.Add(@event);
    }

    public virtual void RemoveEvent(DomainEvent @event)
    {
        if (@event is null) throw new ArgumentNullException($"domain event can  not be null=>{nameof(@event)}");

        _uncommittedEvent.Remove(@event);
    }

    public void UpdateVersion() => ++Version;

    public void SetAggregateVersion() => ++Version;
    public void SetDomainEventVersion(DomainEvent @event) => @event.Version = Version + 1L;
    public void ClearUncommittedEvent() => _uncommittedEvent.Clear();

    public abstract void Apply(DomainEvent @event);

    public void ApplyAndPublish(DomainEvent @event)
    {
        _uncommittedEvent.Add(@event);
        Apply(@event);
    }
}