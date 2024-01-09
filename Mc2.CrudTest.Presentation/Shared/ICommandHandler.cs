namespace Mc2.CrudTest.Presentation.Shared;

public interface ICommandHandler<in T>
{
    void Handle(T command);
}