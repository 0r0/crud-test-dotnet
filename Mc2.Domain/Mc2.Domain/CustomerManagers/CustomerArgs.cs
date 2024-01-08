using FizzWare.NBuilder;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Domain.CustomerManagers;

public class CustomerArgs
{
    public CustomerId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
    
    public static ISingleObjectBuilder<CustomerArgs> Builder
        => new Builder().CreateNew<CustomerArgs>();
}