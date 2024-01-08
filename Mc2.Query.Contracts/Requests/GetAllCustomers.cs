using Mc2.CrudTest.Presentation.Shared;
using Mc2.Query.Contracts.Responses;

namespace Mc2.Query.Contracts.Requests;

public class GetAllCustomers : IQuery<IReadOnlyCollection<CustomerResponse>>
{
    
}