using Mc2.CrudTest.AcceptanceTests.Shared;

namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;

public class DefineCustomerManagerCommand :ICommand
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}