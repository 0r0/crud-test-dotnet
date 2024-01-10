using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Domain.Contracts.CustomerManagers.Exceptions;

public class CustomerWithSameFirstNameLastNameAndDateOfBirthExistException : BusinessException
{
    public CustomerWithSameFirstNameLastNameAndDateOfBirthExistException():base(Customer_Error.CS_1004)
    {
    }
}