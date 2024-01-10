using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;
using Neo4j.Driver;

namespace Mc2.DBProjection.Handlers;

public class CustomerEventHandlers :IEventHandler<CustomerDefined>,
    IEventHandler<CustomerModified>,
    IEventHandler<CustomerRemoved>
{
    private readonly IAsyncTransaction _transaction;

    public CustomerEventHandlers(IAsyncTransaction transaction)
    {
        _transaction = transaction;
    }

    public void Handle(CustomerDefined @event)
    {
        throw new NotImplementedException();
    }

    public void Handle(CustomerModified @event)
    {
        throw new NotImplementedException();
    }

    public void Handle(CustomerRemoved @event)
    {
        throw new NotImplementedException();
    }
}