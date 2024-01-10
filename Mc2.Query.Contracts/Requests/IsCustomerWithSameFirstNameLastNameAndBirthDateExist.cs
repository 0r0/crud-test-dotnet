using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Query.Contracts.Requests;

public class IsCustomerWithSameFirstNameLastNameAndBirthDateExist : IQuery<bool>
{
    public IsCustomerWithSameFirstNameLastNameAndBirthDateExist(CustomerId id,string firstName, string lastName, DateTime dateOfBirth)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public CustomerId Id { get; }
    public string FirstName { get; }

    public string LastName { get; }

    public DateTime DateOfBirth { get; }
}