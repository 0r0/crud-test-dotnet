using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using Mc2.CrudTest.AcceptanceTests.Shared;
using Suzianna.Core.Screenplay;

namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.RestApiTask;

public class CustomerRestApiCommandHandler : ICommandHandler<DefineCustomerManagerCommand>,
    ICommandHandler<ModifyCustomerManagerCommand>,
    ICommandHandler<RemoveCustomerManagerCommand>
{
    public ITask Handle(DefineCustomerManagerCommand command)
        => new DefineCustomerRestApiTask(command);

    public ITask Handle(ModifyCustomerManagerCommand command)
        => new ModifyCustomerRestApiTask(command);

    public ITask Handle(RemoveCustomerManagerCommand command)
        => new RemoveCustomerRestApiTask(command);
}