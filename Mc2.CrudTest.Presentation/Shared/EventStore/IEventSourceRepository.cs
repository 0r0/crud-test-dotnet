using DDDFramework.Core;

namespace Mc2.CrudTest.Presentation.Shared.EventStore;

public interface IEventSourceRepository<T, TKey> : IRepository where T : AggregateRoot<TKey>
{
   T GetById(TKey id);
    void AppendEvents(T aggregate);
}