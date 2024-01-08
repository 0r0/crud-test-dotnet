namespace Mc2.CrudTest.Presentation.Shared;

public interface ICommandHandler<in T>
{
    Task Handle(T command);
}