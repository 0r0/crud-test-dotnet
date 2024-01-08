namespace Mc2.Application.Contracts.CustomerManagers;

public class ModifyCustomerCommand
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    public long PhoneNumber { get; }
    public string Email { get; }
    public string BankAccountNumber { get; }
    public long Version { get; set; }
}