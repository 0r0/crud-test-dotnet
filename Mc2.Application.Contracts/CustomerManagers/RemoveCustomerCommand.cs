namespace Mc2.Application.Contracts.CustomerManagers;

public class RemoveCustomerCommand
{
    public Guid Id { get; set; }
    public long Version { get; set; }
}