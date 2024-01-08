using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Domain.CustomerManagers;

public partial class Customer:AggregateRoot<CustomerId>
{
    public override void Apply(DomainEvent @event)
    {
        throw new NotImplementedException();
    }
}