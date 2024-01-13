using System.Reflection;
using Mc2.CrudTest.Presentation.Shared.AggregateRootFactory;

namespace Mc2.CrudTest.Presentation.Shared.EventStore;

/// <summary>
/// load aggregate form repository of events
/// </summary>
public class EventSourceRepository<T, TKey> : IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
{
    private readonly IEventStore _eventStore;
    private readonly IAggregateRootFactory _aggregateRootFactory;
    private readonly IEventBus _eventBus;


    public EventSourceRepository(IEventStore eventStore, IAggregateRootFactory aggregateRootFactory, IEventBus eventBus)
    {
        _eventStore = eventStore;
        _aggregateRootFactory = aggregateRootFactory;
        _eventBus = eventBus;
    }


    public T GetById(TKey id)
    {
        var eventsList = _eventStore.GetEvents(GetStreamId(id));
        return _aggregateRootFactory.Create<T>(eventsList.Result);
    }

    public void AppendEvents(T aggregate)
    {
        var events = aggregate.GetUncommittedEvents();
        _eventStore.Append(GetStreamId(aggregate.Id), events);
        foreach (IDomainEvent domainEvent in events)
        {
            var dispatchMethod = _eventBus.GetType()
                .GetMethod(nameof(IEventBus.Publish))
                .MakeGenericMethod(domainEvent.GetType());
            dispatchMethod.Invoke(_eventBus, new[] { domainEvent });
        }
    }

    private string GetStreamId(TKey id)
    {
        return
            $"{typeof(T).Name}-{id.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).First().GetValue(id)}";
    }
}