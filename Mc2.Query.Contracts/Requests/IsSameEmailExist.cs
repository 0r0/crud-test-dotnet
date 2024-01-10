using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Query.Contracts.Requests;

public class IsSameEmailExist : IQuery<bool>
{
    public string Email { get; }

    public IsSameEmailExist(string email)
    {
        Email = email;
    }
}