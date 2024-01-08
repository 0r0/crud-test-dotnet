using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Query.Contracts.Responses;

namespace Mc2.Query.Contracts.Requests;

public class GetCustomerById :IQuery<CustomerResponse>
{
    public GetCustomerById(CustomerId id)
    {
        Id = id;
    }

    public CustomerId Id { get; private set; }
}