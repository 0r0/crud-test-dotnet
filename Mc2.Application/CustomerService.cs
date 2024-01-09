using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Application;

public class CustomerService : ICustomerService
{
    public bool IsEmailDuplicated(CustomerId id, string email)
    {
        throw new NotImplementedException();
    }

    public bool IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(string firstName, string lastName, DateTime dateOfBirth)
    {
        throw new NotImplementedException();
    }
}