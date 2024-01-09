using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Domain.CustomerManagers;

public partial class Customer
{
    public override void Apply(DomainEvent @event)
    {
        When((dynamic)@event);
    }


    private void When(CustomerDefined @event)
    {
        Id = @event.Id;
    }

    private void When(CustomerModified @event)
    {
    }

    private void When(CustomerRemoved @event)
    {
    }
}