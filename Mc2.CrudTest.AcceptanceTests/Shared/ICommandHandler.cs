using Suzianna.Core.Screenplay;

namespace Mc2.CrudTest.AcceptanceTests.Shared;

public interface ICommandHandler<in T> where T:ICommand
{
    public ITask Handle(T command);
}