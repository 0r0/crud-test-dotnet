namespace Mc2.CrudTest.AcceptanceTests.Shared;

public interface ICommandBus
{
    public void Dispatch<T>(T command) where T : ICommand;

}