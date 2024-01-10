using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Application;

public class CustomerService : ICustomerService
{
    public bool IsEmailDuplicated(CustomerId id, string email)
    {
        return default;
    }

    public bool IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(string firstName, string lastName,
        DateTime dateOfBirth)
    {
        return default;
    }
}