namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Responses;

public class CustomerResponse
{
  
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }  
}