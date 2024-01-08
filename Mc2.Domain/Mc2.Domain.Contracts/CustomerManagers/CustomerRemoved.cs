using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Domain.Contracts.CustomerManagers;

public class CustomerRemoved :DomainEvent
{
    public CustomerRemoved(CustomerId id)
    {
        Id = id;
    }

    public CustomerId Id { get;  }
}