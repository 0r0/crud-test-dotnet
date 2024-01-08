namespace Mc2.CrudTest.Presentation.Shared;

public interface ICommandBus
{
    public void Dispatch<T>(T command);
}