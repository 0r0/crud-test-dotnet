using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;
using Mc2.Query.Contracts.Requests;

namespace Mc2.Application;

public class CustomerService : ICustomerService
{
    private readonly IQueryBus _queryBus;

    public CustomerService(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }

    public bool IsEmailDuplicated(CustomerId id, string email)
    {
        return _queryBus.Execute<IsSameEmailExist, bool>(new IsSameEmailExist(email));
    }

    public bool IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(string firstName, string lastName,
        DateTime dateOfBirth)
    {
        return _queryBus.Execute<IsCustomerWithSameFirstNameLastNameAndBirthDateExist, bool>(
            new IsCustomerWithSameFirstNameLastNameAndBirthDateExist(firstName, lastName, dateOfBirth));
    }
}