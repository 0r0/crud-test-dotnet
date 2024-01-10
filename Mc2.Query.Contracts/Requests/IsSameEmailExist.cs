using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Query.Contracts.Requests;

public class IsSameEmailExist : IQuery<bool>
{
    public IsSameEmailExist(CustomerId id,string email)
    {
        Id = id;
        Email = email;
    }

    public CustomerId Id { get; }

    public string Email { get; }
}