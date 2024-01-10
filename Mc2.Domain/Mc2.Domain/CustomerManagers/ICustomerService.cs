using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Domain.CustomerManagers;

public interface ICustomerService : IDomainService
{
    public bool IsEmailDuplicated(CustomerId id, string email);

    public bool IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(CustomerId customerId,string firstName, string lastName,
        DateTime dateOfBirth);
}