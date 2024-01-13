using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.RestApiTask;

public class ModifyCustomerRestApiTask : ITask
{
    private readonly ModifyCustomerManagerCommand _command;

    public ModifyCustomerRestApiTask(ModifyCustomerManagerCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        ;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Put.DataAsJson(_command).To($"/api/customermanager/{_command.Id}"));
    }
}