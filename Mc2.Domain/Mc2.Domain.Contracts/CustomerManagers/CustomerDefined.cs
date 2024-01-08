namespace Mc2.Domain.Contracts.CustomerManagers;

public class CustomerDefined
{
    public CustomerDefined(CustomerId id, string firstName, string lastName, DateTime dateOfBirth, long phoneNumber,
        string email, string bankAccountNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public CustomerId Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    public long PhoneNumber { get; }
    public string Email { get; }
    public string BankAccountNumber { get; }
}