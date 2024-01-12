using Mc2.CrudTest.AcceptanceTests.Shared;

namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;

public class RemoveCustomerManagerCommand : ICommand
{
    public RemoveCustomerManagerCommand(Guid id, long version)
    {
        Id = id;
        Version = version;
    }

    public Guid Id { get; set; }
    public long Version { get; set; }
    
}