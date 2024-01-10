using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Domain.Contracts.CustomerManagers.Exceptions;

public class CustomerWithSameEmailExistException : BusinessException
{
    public CustomerWithSameEmailExistException() : base(Customer_Error.CS_1005)
    {
    }
}