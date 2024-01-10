using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Application.CustomerManagers.Validators;

public class PhoneNumberIsNotValidException : BusinessException
{
    public PhoneNumberIsNotValidException() : base(Customer_Error.CS_1001)
    {
    }
}