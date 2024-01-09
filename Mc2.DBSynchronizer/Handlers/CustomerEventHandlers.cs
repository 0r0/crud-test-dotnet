using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.DBSynchronizer.Handlers;

public class CustomerEventHandlers :IEventHandler<CustomerDefined>,
    IEventHandler<CustomerModified>
{
    public void Handle(CustomerDefined @event)
    {
        throw new NotImplementedException();
    }

    public void Handle(CustomerModified @event)
    {
        throw new NotImplementedException();
    }
}