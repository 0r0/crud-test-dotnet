using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Query.Contracts.Requests;

public class IsCustomerWithSameFirstNameLastNameAndBirthDateExist : IQuery<bool>
{
    public IsCustomerWithSameFirstNameLastNameAndBirthDateExist(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public DateTime DateOfBirth { get; }
}